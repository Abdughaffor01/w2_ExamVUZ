using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Exam
{
    [Key]
    public int ExamId { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int Type { get; set; }
    public List<Result> Results { get; set; }
}
