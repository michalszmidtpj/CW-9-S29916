namespace CW_9_S29916.DTOs;

public class PatientPerscriptionDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public IEnumerable<PerscRiptionWIthDOctorDTO> Prescriptions { get; set; }
}