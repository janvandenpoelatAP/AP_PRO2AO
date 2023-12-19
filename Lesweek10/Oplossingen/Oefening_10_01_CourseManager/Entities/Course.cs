using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Oefening_10_01_CourseManager.Entities;
public class Course
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public required string Name { get; set; }

    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public Course()
    {
    }

    [SetsRequiredMembers]
    public Course(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
