using CW_9_S29916.Data;
using CW_9_S29916.DTOs;
using CW_9_S29916.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CW_9_S29916.Services;

public interface IDBService
{
    public Task<PatientPerscriptionDTO> GetPatientPerscriptionsAsync(int id);
    public Task PostPerscriptionAsync(PerscriptionPostDTO perscription);
}

public class DBService(AppDbContext context) : IDBService
{
    public async Task<PatientPerscriptionDTO> GetPatientPerscriptionsAsync(int id)
    {
        var dto = await context.Patients
            .Select(pt => new PatientPerscriptionDTO
            {
                IdPatient = pt.IdPatient,
                LastName = pt.LastName,
                BirthDate = pt.Birthdate,
                Prescriptions =  context.Prescriptions
                    .Where(pr => pr.IdPatient == id)
                    .Select(pr => new PerscRiptionWIthDOctorDTO
                    {
                        IdPerscription = pr.IdPrescription,
                        Date = pr.Date,
                        DueDate = pr.DueDate,
                        Doctor = context.Doctors
                            // .Where(dr => dr.IdDoctor == pr.IdDoctor)
                            .Select(dr => new DoctorDTO
                            {

                            }).FirstOrDefault(dr => dr.IdDoctor == pr.IdDoctor)

                    }).ToList()
            }).FirstOrDefaultAsync(pt => pt.IdPatient == id);

        if (dto == null)
            throw new NoSuchPatientException("");
        
        return dto;

    }

    public async Task PostPerscriptionAsync(PerscriptionPostDTO perscription)
    {
        if (perscription.DueDate <= perscription.Date)
            throw new IllegalArgumentException("DueDate must be grater than Date");

    }
}