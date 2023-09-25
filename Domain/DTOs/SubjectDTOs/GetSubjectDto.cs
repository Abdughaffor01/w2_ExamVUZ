namespace Domain;
public class GetSubjectDto:BaseSubjectDto
{
    public List<Result> Results { get; set; }= new List<Result>();
}
