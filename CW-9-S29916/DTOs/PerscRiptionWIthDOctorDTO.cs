namespace CW_9_S29916.DTOs;

public class PerscRiptionWIthDOctorDTO
{
    public int IdPerscription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public IEnumerable<MeidcamentDTO> Medicaments { get; set; }
    public DoctorDTO Doctor { get; set; }
}