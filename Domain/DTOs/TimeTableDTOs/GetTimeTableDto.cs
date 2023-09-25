namespace Domain;
public class GetTimeTableDto:BaseTimeTableDto
{
    public string SubjectName { get; set; }
    public List<Classroom> Classrooms { get; set; }
}
