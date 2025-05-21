using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CW_9_S29916.Models;


[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class Prescription_Medicament
{
    [ForeignKey("IdMedicament")]
    public int IdMedicament { get; set; }
    
    [ForeignKey("IdPrescription")]
    public int IdPrescription { get; set; }

    public int? Dose { get; set; }
    
    [MaxLength(100)]
    public string Details { get; set; }
}