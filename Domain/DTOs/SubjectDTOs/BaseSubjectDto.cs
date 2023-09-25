using System.ComponentModel.DataAnnotations;

namespace Domain;
public class BaseSubjectDto
{
    public int SubjectId { get; set; }
    public string Name { get; set; }
    public int Grade { get; set; }
    public string Description { get; set; }
}
