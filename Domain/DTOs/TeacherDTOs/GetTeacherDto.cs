namespace Domain;
public class GetTeacherDto:BaseTeacherDto
{
    public string Date_Of_Join { get; set; }
    public Attendance Attendance { get; set; }
    public List<Classroom> Classrooms { get; set; }
}
