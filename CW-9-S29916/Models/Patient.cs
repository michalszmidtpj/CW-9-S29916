using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_9_S29916.Models;

[Table("Patient")]
public class Patient
{
    [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPatient { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [MaxLength(100)]
    public DateTime Birthdate { get; set; }
}