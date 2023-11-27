using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Oefening_09_01_CourseManager.Entities;
public class Teacher
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public required string Name { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();

    public Teacher()
    {
    }

    [SetsRequiredMembers]
    public Teacher(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
