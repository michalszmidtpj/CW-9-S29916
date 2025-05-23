using CW_9_S29916.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_9_S29916.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Doctor Seed
        modelBuilder.Entity<Doctor>().HasData(
            Enumerable.Range(1, 20).Select(i => new Doctor
            {
                IdDoctor = i,
                FirstName = $"DoctorFirst{i}",
                LastName = $"DoctorLast{i}",
                Email = $"doctor{i}@hospital.com"
            }).ToArray()
        );

        // Patient Seed
        modelBuilder.Entity<Patient>().HasData(
            Enumerable.Range(1, 20).Select(i => new Patient
            {
                IdPatient = i,
                FirstName = $"PatientFirst{i}",
                LastName = $"PatientLast{i}",
                Birthdate = new DateTime(1980 + (i % 20), (i % 12) + 1, (i % 28) + 1)
            }).ToArray()
        );

        // Medicament Seed
        modelBuilder.Entity<Medicament>().HasData(
            Enumerable.Range(1, 20).Select(i => new Medicament
            {
                IdMedicament = i,
                Name = $"Medicament{i}",
                Description = $"Description for Medicament {i}",
                Type = $"Type{i % 5}"
            }).ToArray()
        );

        // Prescription Seed
        modelBuilder.Entity<Prescription>().HasData(
            Enumerable.Range(1, 20).Select(i => new Prescription
            {
                IdPrescription = i,
                Date = new DateTime(2025, (i % 12) + 1, (i % 28) + 1),
                DueDate = new DateTime(2025, ((i + 1) % 12) + 1, ((i + 5) % 28) + 1),
                IdPatient = ((i - 1) % 20) + 1,
                IdDoctor = ((i - 1) % 20) + 1
            }).ToArray()
        );

        // Prescription_Medicament Seed
        modelBuilder.Entity<Prescription_Medicament>().HasData(
            Enumerable.Range(1, 20).Select(i => new Prescription_Medicament
            {
                IdMedicament = ((i - 1) % 20) + 1,
                IdPrescription = ((i - 1) % 20) + 1,
                Dose = (i % 5) + 1,
                Details = $"Take {((i % 5) + 1)} times daily"
            }).ToArray()
        );
    }
}