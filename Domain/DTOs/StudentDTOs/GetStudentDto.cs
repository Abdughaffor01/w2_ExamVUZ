namespace Domain;
public class GetStudentDto:BaseStudentDto
{
    public string Date_Of_Join { get; set; }
    public List<ClassroomStudent> ClassroomStudents { get; set; }=new List<ClassroomStudent>();
    public List<Result> Results { get; set; } = new List<Result>();
    public List<Issues> Issueses { get; set; } = new List<Issues>();
}
