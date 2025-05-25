namespace CW_9_S29916.DTOs;

public class PerscriptionPostDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public IEnumerable<MedicamentPostDTO> medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
    public int IdDoctor { get; set; }
}