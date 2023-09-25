using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Result
{
    [Key]
    public int ExamId { get; set; }
    public Exam Exam { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}
