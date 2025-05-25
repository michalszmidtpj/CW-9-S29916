using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_9_S29916.Models;

[Table("Medicament")]
public class Medicament
{
    [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdMedicament { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    
    [MaxLength(100)]
    public string Description { get; set; }
    
    [MaxLength(100)]
    public string Type { get; set; }
}