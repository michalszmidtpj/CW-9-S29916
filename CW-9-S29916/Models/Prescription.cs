using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_9_S29916.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    [ForeignKey("IdPatient")]
    public int IdPatient { get; set; }
    
    [ForeignKey("IdDoctor")]
    public int IdDoctor { get; set; }
}