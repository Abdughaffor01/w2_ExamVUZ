namespace Domain.Entities;
public class Teacher :Person
{
    public List<Classroom> Classrooms { get; set; }
    public Attendance Attendance { get; set; }
}
