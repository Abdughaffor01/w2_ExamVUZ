using Domain.Entities;
using System.ComponentModel.DataAnnotations;
namespace Domain;
public class Issues
{
    [Key]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    [MaxLength(50)]
    public string Type { get; set; }
    [MaxLength(50)]
    public string Details { get; set; }
    public bool IsResolved { get; set; }
}
