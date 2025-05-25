using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_9_S29916.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    [ForeignKey("IdPatient")]
    public int IdPatient { get; set; }
    
    [ForeignKey("IdDoctor")]
    public int IdDoctor { get; set; }
}