using Domain.Entities;
namespace Domain;
public class BaseIssuesDto
{
    public int StudentId { get; set; }
    public string Type { get; set; }
    public string Details { get; set; }
    public bool IsResolved { get; set; }
}
