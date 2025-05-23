using CW_9_S29916.Data;
using CW_9_S29916.DTOs;
using CW_9_S29916.Exceptions;
using CW_9_S29916.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_9_S29916.Services;

public interface IDbService
{
    public Task<PatientPerscriptionDTO> GetPatientPrescriptionsAsync(int id);
    public Task PostPrescriptionAsync(PerscriptionPostDTO prescription);
}

public class DbService(AppDbContext context) : IDbService
{
    public async Task<PatientPerscriptionDTO> GetPatientPrescriptionsAsync(int id)
    {
        var dto = await context.Patients
            .Select(pt => new PatientPerscriptionDTO
            {
                IdPatient = pt.IdPatient,
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

    public async Task PostPrescriptionAsync(PerscriptionPostDTO prescription)
    {
        if (prescription.DueDate <= prescription.Date || prescription.medicaments.ToList().Count > 10)
            throw new IllegalArgumentException("date or medicaments size is invalid");

        foreach (var med in prescription.medicaments)
        {
            if (!await context.Medicaments.Where(x => x.IdMedicament == med.Idmedicament).AnyAsync())
            {
                throw new IllegalArgumentException("invalid medicament");
            }
        }

        if (!await context.Patients.Where(x => x.IdPatient == prescription.IdPatient).AnyAsync())
        {
            await context.Patients.AddAsync(new Patient
            {
                IdPatient = prescription.IdPatient,
                FirstName = prescription.FirstName,
                LastName = prescription.LastName,
                Birthdate = prescription.BirthDate
            });
        }
    }
}