using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CW_9_S29916.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medicaments", x => new { x.IdMedicament, x.IdPrescription });
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "doctor1@hospital.com", "DoctorFirst1", "DoctorLast1" },
                    { 2, "doctor2@hospital.com", "DoctorFirst2", "DoctorLast2" },
                    { 3, "doctor3@hospital.com", "DoctorFirst3", "DoctorLast3" },
                    { 4, "doctor4@hospital.com", "DoctorFirst4", "DoctorLast4" },
                    { 5, "doctor5@hospital.com", "DoctorFirst5", "DoctorLast5" },
                    { 6, "doctor6@hospital.com", "DoctorFirst6", "DoctorLast6" },
                    { 7, "doctor7@hospital.com", "DoctorFirst7", "DoctorLast7" },
                    { 8, "doctor8@hospital.com", "DoctorFirst8", "DoctorLast8" },
                    { 9, "doctor9@hospital.com", "DoctorFirst9", "DoctorLast9" },
                    { 10, "doctor10@hospital.com", "DoctorFirst10", "DoctorLast10" },
                    { 11, "doctor11@hospital.com", "DoctorFirst11", "DoctorLast11" },
                    { 12, "doctor12@hospital.com", "DoctorFirst12", "DoctorLast12" },
                    { 13, "doctor13@hospital.com", "DoctorFirst13", "DoctorLast13" },
                    { 14, "doctor14@hospital.com", "DoctorFirst14", "DoctorLast14" },
                    { 15, "doctor15@hospital.com", "DoctorFirst15", "DoctorLast15" },
                    { 16, "doctor16@hospital.com", "DoctorFirst16", "DoctorLast16" },
                    { 17, "doctor17@hospital.com", "DoctorFirst17", "DoctorLast17" },
                    { 18, "doctor18@hospital.com", "DoctorFirst18", "DoctorLast18" },
                    { 19, "doctor19@hospital.com", "DoctorFirst19", "DoctorLast19" },
                    { 20, "doctor20@hospital.com", "DoctorFirst20", "DoctorLast20" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Description for Medicament 1", "Medicament1", "Type1" },
                    { 2, "Description for Medicament 2", "Medicament2", "Type2" },
                    { 3, "Description for Medicament 3", "Medicament3", "Type3" },
                    { 4, "Description for Medicament 4", "Medicament4", "Type4" },
                    { 5, "Description for Medicament 5", "Medicament5", "Type0" },
                    { 6, "Description for Medicament 6", "Medicament6", "Type1" },
                    { 7, "Description for Medicament 7", "Medicament7", "Type2" },
                    { 8, "Description for Medicament 8", "Medicament8", "Type3" },
                    { 9, "Description for Medicament 9", "Medicament9", "Type4" },
                    { 10, "Description for Medicament 10", "Medicament10", "Type0" },
                    { 11, "Description for Medicament 11", "Medicament11", "Type1" },
                    { 12, "Description for Medicament 12", "Medicament12", "Type2" },
                    { 13, "Description for Medicament 13", "Medicament13", "Type3" },
                    { 14, "Description for Medicament 14", "Medicament14", "Type4" },
                    { 15, "Description for Medicament 15", "Medicament15", "Type0" },
                    { 16, "Description for Medicament 16", "Medicament16", "Type1" },
                    { 17, "Description for Medicament 17", "Medicament17", "Type2" },
                    { 18, "Description for Medicament 18", "Medicament18", "Type3" },
                    { 19, "Description for Medicament 19", "Medicament19", "Type4" },
                    { 20, "Description for Medicament 20", "Medicament20", "Type0" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1981, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst1", "PatientLast1" },
                    { 2, new DateTime(1982, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst2", "PatientLast2" },
                    { 3, new DateTime(1983, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst3", "PatientLast3" },
                    { 4, new DateTime(1984, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst4", "PatientLast4" },
                    { 5, new DateTime(1985, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst5", "PatientLast5" },
                    { 6, new DateTime(1986, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst6", "PatientLast6" },
                    { 7, new DateTime(1987, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst7", "PatientLast7" },
                    { 8, new DateTime(1988, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst8", "PatientLast8" },
                    { 9, new DateTime(1989, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst9", "PatientLast9" },
                    { 10, new DateTime(1990, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst10", "PatientLast10" },
                    { 11, new DateTime(1991, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst11", "PatientLast11" },
                    { 12, new DateTime(1992, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst12", "PatientLast12" },
                    { 13, new DateTime(1993, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst13", "PatientLast13" },
                    { 14, new DateTime(1994, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst14", "PatientLast14" },
                    { 15, new DateTime(1995, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst15", "PatientLast15" },
                    { 16, new DateTime(1996, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst16", "PatientLast16" },
                    { 17, new DateTime(1997, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst17", "PatientLast17" },
                    { 18, new DateTime(1998, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst18", "PatientLast18" },
                    { 19, new DateTime(1999, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst19", "PatientLast19" },
                    { 20, new DateTime(1980, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "PatientFirst20", "PatientLast20" }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "Take 2 times daily", 2 },
                    { 2, 2, "Take 3 times daily", 3 },
                    { 3, 3, "Take 4 times daily", 4 },
                    { 4, 4, "Take 5 times daily", 5 },
                    { 5, 5, "Take 1 times daily", 1 },
                    { 6, 6, "Take 2 times daily", 2 },
                    { 7, 7, "Take 3 times daily", 3 },
                    { 8, 8, "Take 4 times daily", 4 },
                    { 9, 9, "Take 5 times daily", 5 },
                    { 10, 10, "Take 1 times daily", 1 },
                    { 11, 11, "Take 2 times daily", 2 },
                    { 12, 12, "Take 3 times daily", 3 },
                    { 13, 13, "Take 4 times daily", 4 },
                    { 14, 14, "Take 5 times daily", 5 },
                    { 15, 15, "Take 1 times daily", 1 },
                    { 16, 16, "Take 2 times daily", 2 },
                    { 17, 17, "Take 3 times daily", 3 },
                    { 18, 18, "Take 4 times daily", 4 },
                    { 19, 19, "Take 5 times daily", 5 },
                    { 20, 20, "Take 1 times daily", 1 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 5, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 },
                    { 6, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6 },
                    { 7, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7 },
                    { 8, new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8 },
                    { 9, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 9 },
                    { 10, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10 },
                    { 11, new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 11 },
                    { 12, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 12 },
                    { 13, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 13 },
                    { 14, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 14 },
                    { 15, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 15 },
                    { 16, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 16 },
                    { 17, new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 17 },
                    { 18, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 18 },
                    { 19, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 19 },
                    { 20, new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Prescription_Medicaments");

            migrationBuilder.DropTable(
                name: "Prescriptions");
        }
    }
}
