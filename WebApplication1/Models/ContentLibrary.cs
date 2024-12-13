using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ContentLibrary
{
    public int ContentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? ContentType { get; set; }

    public int? ModuleId { get; set; }

    public virtual Module? Module { get; set; }
}
