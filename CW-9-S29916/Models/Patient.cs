using System.ComponentModel.DataAnnotations;

namespace CW_9_S29916.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [MaxLength(100)]
    public DateTime Birthdate { get; set; }
}