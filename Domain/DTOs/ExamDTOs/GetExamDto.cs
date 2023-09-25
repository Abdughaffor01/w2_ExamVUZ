namespace Domain;
public class GetExamDto:BaseExamDto
{
    public List<Result> Results { get; set; }=new List<Result>();
}
