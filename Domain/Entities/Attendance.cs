using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Attendance
{
    [Key]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}
