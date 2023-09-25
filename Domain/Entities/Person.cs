using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public abstract  class Person
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(50)]
    public string Password { get; set; }
    [DataType("date")]
    public DateTime DOB { get; set; }
    [MaxLength(100)]
    public string Address { get; set; }
    [MaxLength(13)]
    public string Phone { get; set; }
    [MaxLength(50)]
    public string Date_Of_Join { get; set; }

}
