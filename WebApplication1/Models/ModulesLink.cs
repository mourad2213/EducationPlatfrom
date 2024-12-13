using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ModulesLink
{
    public int ModuleId { get; set; }

    public string Link { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;
}
