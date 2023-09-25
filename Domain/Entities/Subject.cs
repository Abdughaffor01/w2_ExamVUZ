using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Subject
{
    [Key]
    public int SubjectId { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    public int Grade { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
    public List<Result> Results { get; set; }
}