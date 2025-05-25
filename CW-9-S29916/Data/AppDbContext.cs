using CW_9_S29916.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_9_S29916.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> Prescription_Medicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Doctor>()
            .Property(d => d.IdDoctor)
            .ValueGeneratedNever();

        modelBuilder.Entity<Patient>()
            .Property(p => p.IdPatient)
            .ValueGeneratedNever();

        modelBuilder.Entity<Medicament>()
            .Property(m => m.IdMedicament)
            .ValueGeneratedNever();

        modelBuilder.Entity<Prescription>()
            .Property(p => p.IdPrescription)
            .ValueGeneratedNever();

        modelBuilder.Entity<PrescriptionMedicament>()
            .Property(pm => pm.IdMedicament)
            .ValueGeneratedNever();

        modelBuilder.Entity<PrescriptionMedicament>()
            .Property(pm => pm.IdPrescription)
            .ValueGeneratedNever();


        modelBuilder.Entity<Prescription>()
            .HasOne<Patient>()
            .WithMany()
            .HasForeignKey(p => p.IdPatient)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Prescription>()
            .HasOne<Doctor>()
            .WithMany()
            .HasForeignKey(p => p.IdDoctor)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<PrescriptionMedicament>(entity =>
        {
            entity.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });


            entity.HasOne<Medicament>()
                .WithMany()
                .HasForeignKey(pm => pm.IdMedicament)
                .OnDelete(DeleteBehavior.Cascade);


            entity.HasOne<Prescription>()
                .WithMany()
                .HasForeignKey(pm => pm.IdPrescription)
                .OnDelete(DeleteBehavior.Cascade);
        });


        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
            new Doctor { IdDoctor = 2, FirstName = "Emily", LastName = "Clark", Email = "emily.clark@example.com" },
            new Doctor
            {
                IdDoctor = 3, FirstName = "Michael", LastName = "Anderson", Email = "michael.anderson@example.com"
            }
        );


        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                IdPatient = 1, FirstName = "Robert", LastName = "Marley", Birthdate = new DateTime(1980, 6, 15)
            },
            new Patient
            {
                IdPatient = 2, FirstName = "Sophia", LastName = "Williams", Birthdate = new DateTime(1992, 11, 3)
            },
            new Patient
            {
                IdPatient = 3, FirstName = "Daniel", LastName = "Lopez", Birthdate = new DateTime(1975, 2, 20)
            },
            new Patient
            {
                IdPatient = 4, FirstName = "Olivia", LastName = "Taylor", Birthdate = new DateTime(1988, 9, 12)
            }
        );


        modelBuilder.Entity<Medicament>().HasData(
            new Medicament
            {
                IdMedicament = 1,
                Name = "Aspirin",
                Description = "Pain reliever and anti-inflammatory",
                Type = "Analgesic"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "Amoxicillin",
                Description = "Broad-spectrum antibiotic",
                Type = "Antibiotic"
            },
            new Medicament
            {
                IdMedicament = 3,
                Name = "Metformin",
                Description = "Used to treat type 2 diabetes",
                Type = "Antidiabetic"
            },
            new Medicament
            {
                IdMedicament = 4,
                Name = "Lisinopril",
                Description = "ACE inhibitor for blood pressure control",
                Type = "Antihypertensive"
            }
        );


        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                IdPrescription = 1,
                Date = new DateTime(2025, 5, 1),
                DueDate = new DateTime(2025, 5, 15),
                IdPatient = 1,
                IdDoctor = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = new DateTime(2025, 5, 3),
                DueDate = new DateTime(2025, 5, 17),
                IdPatient = 2,
                IdDoctor = 2
            },
            new Prescription
            {
                IdPrescription = 3,
                Date = new DateTime(2025, 5, 5),
                DueDate = new DateTime(2025, 5, 20),
                IdPatient = 3,
                IdDoctor = 3
            },
            new Prescription
            {
                IdPrescription = 4,
                Date = new DateTime(2025, 5, 6),
                DueDate = new DateTime(2025, 5, 21),
                IdPatient = 4,
                IdDoctor = 1
            }
        );


        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 100,
                Details = "Take 1 tablet every 8 hours after meals"
            },
            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 1,
                Dose = 500,
                Details = "Take 1 capsule every 12 hours until course ends"
            },
            new PrescriptionMedicament
            {
                IdMedicament = 3,
                IdPrescription = 2,
                Dose = 1000,
                Details = "Take 1 tablet twice daily with food"
            },
            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 3,
                Dose = 500,
                Details = "Take 1 capsule every 8 hours for 7 days"
            },
            new PrescriptionMedicament
            {
                IdMedicament = 4,
                IdPrescription = 3,
                Dose = 20,
                Details = "Take 1 tablet once daily in the morning"
            },
            new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 4,
                Dose = 100,
                Details = "Take 1 tablet every 6 hours as needed for pain"
            }
        );
    }
}