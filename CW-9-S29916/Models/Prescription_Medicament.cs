using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CW_9_S29916.Models;

[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class PrescriptionMedicament
{
    [ForeignKey("IdMedicament")]
    public int IdMedicament { get; set; }
    
    [ForeignKey("IdPrescription")]
    public int IdPrescription { get; set; }

    public int? Dose { get; set; }
    
    [MaxLength(100)]
    public string Details { get; set; }
}