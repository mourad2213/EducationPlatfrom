using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class InstructorEmail
{
    public int InstructorId { get; set; }

    public string Email { get; set; } = null!;

    public virtual Instructor Instructor { get; set; } = null!;
}
