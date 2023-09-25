using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;
public class Student:Person
{
    [MaxLength(30)]
    public string Parent_Name { get; set; }
    public List<ClassroomStudent> ClassroomStudents { get; set; }
    public List<Result> Results { get; set; }
    public List<Issues> Issueses { get; set; }
}
