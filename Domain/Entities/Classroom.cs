using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Classroom
{
    [Key]
    public int ClassroomId { get; set; }
    [MaxLength(100)]
    public int Grade { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public List<Subject> Subjects { get; set; }
    public List<ClassroomStudent> ClassroomStudents { get; set; }
}
