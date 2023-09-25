namespace Domain;
public class GetClassroomDto:BaseClassroomDto
{
    public List<Subject> Subjects { get; set; }=new List<Subject>();
    public List<ClassroomStudent> ClassroomStudents { get; set; }= new List<ClassroomStudent>();
}
