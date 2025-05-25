using System.Transactions;
using CW_9_S29916.Data;
using CW_9_S29916.DTOs;
using CW_9_S29916.Exceptions;
using CW_9_S29916.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_9_S29916.Services;

public interface IDbService
{
    public Task<PatientPerscriptionDTO> GetPatientPrescriptionsAsync(int id);
    public Task<int> PostPrescriptionAsync(PerscriptionPostDTO prescription);
}

public class DbService(AppDbContext context) : IDbService
{
    public async Task<PatientPerscriptionDTO> GetPatientPrescriptionsAsync(int id)
    {
        var dto = await context.Patients
            .Select(pt => new PatientPerscriptionDTO
            {
                IdPatient = pt.IdPatient,
                FirstName = pt.FirstName,
                LastName = pt.LastName,
                BirthDate = pt.Birthdate,
                Prescriptions = context.Prescriptions
                    .Where(pr => pr.IdPatient == id)
                    .OrderBy(pr => pr.DueDate)
                    .Select(pr => new PerscRiptionWIthDOctorDTO
                    {
                        IdPerscription = pr.IdPrescription,
                        Date = pr.Date,
                        DueDate = pr.DueDate,
                        Medicaments = context.Prescription_Medicaments
                            .Where(prm => prm.IdMedicament == pr.IdPrescription).Select(x => new MeidcamentDTO
                            {
                                Idmedicament = x.IdMedicament,
                                Name = context.Medicaments.FirstOrDefault(y => y.IdMedicament == x.IdMedicament).Name,
                                Description = context.Medicaments.FirstOrDefault(y => y.IdMedicament == x.IdMedicament)
                                    .Description,
                                Type = context.Medicaments.FirstOrDefault(y => y.IdMedicament == x.IdMedicament).Type
                            }).ToList(),
                        Doctor = context.Doctors
                            .Select(dr => new DoctorDTO
                            {
                                IdDoctor = dr.IdDoctor,
                                FirstName = dr.FirstName
                            }).FirstOrDefault(dr => dr.IdDoctor == pr.IdDoctor)
                    }).ToList()
            }).FirstOrDefaultAsync(pt => pt.IdPatient == id);
        // dto
        // sout
        if (dto == null)
            throw new NoSuchPatientException("");

        return dto;
    }

    public async Task<int> PostPrescriptionAsync(PerscriptionPostDTO prescription)
    {
        if (prescription.DueDate <= prescription.Date || prescription.medicaments.ToList().Count > 10 ||
            !await context.Doctors.AnyAsync(x => x.IdDoctor == prescription.IdDoctor))
            throw new IllegalArgumentException("date or medicaments size is invalid");

        foreach (var med in prescription.medicaments)
        {
            if (!await context.Medicaments.Where(x => x.IdMedicament == med.Idmedicament).AnyAsync())
            {
                throw new IllegalArgumentException("invalid medicament");
            }
        }


        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            if (!await context.Patients.Where(x => x.IdPatient == prescription.IdPatient).AnyAsync())
            {
                var pat = new Patient
                {
                    IdPatient = prescription.IdPatient,
                    FirstName = prescription.FirstName,
                    LastName = prescription.LastName,
                    Birthdate = prescription.BirthDate
                };
                await context.Patients.AddAsync(pat);


                await context.SaveChangesAsync();
            }

            // Console.WriteLine(await context.Patients.Where(x => x.IdPatient == prescription.IdPatient).AnyAsync());
            var per = new Prescription
            {
                IdPrescription = (await context.Prescriptions.MaxAsync(x => x.IdPrescription)) + 1,
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                IdPatient = prescription.IdPatient,
                IdDoctor = prescription.IdDoctor,
            };
            await context.Prescriptions.AddAsync(per);
            await context.SaveChangesAsync();

            // Console.WriteLine($"{prescription.IdPatient}: {newpa.State}");

            // var id = (await  context.Prescriptions.FirstOrDefaultAsync(x =>
            // x.Date == prescription.Date && x.DueDate == prescription.DueDate && x.DueDate)).IdPrescription;

            foreach (var prm in prescription.medicaments)
            {
                await context.Prescription_Medicaments.AddAsync(new PrescriptionMedicament
                {
                    IdMedicament = prm.Idmedicament,
                    Dose = prm.Dose,
                    IdPrescription = per.IdPrescription,
                    Details = prm.Description,
                });
            }

            scope.Complete();
        }

        await context.SaveChangesAsync();
        return prescription.IdPatient;
    }
}