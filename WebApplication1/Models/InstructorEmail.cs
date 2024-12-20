using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

public class InstructorEmail
{
    public int InstructorEmailId { get; set; } // Primary key, auto-increment
    [Required]
    public string Email { get; set; }
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; }
}
