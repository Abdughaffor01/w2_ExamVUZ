using System.ComponentModel.DataAnnotations;

namespace Domain;
public class TimeTable
{
    [Key]
    public int TT_Id { get; set; }
    [MaxLength(50)]
    public string Day { get; set; }
    [MaxLength(30)]
    public string Time { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public List<Classroom> Classrooms { get; set; }

}
