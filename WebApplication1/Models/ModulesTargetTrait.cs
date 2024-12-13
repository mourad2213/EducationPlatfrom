using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ModulesTargetTrait
{
    public int ModuleId { get; set; }

    public string TargetTrait { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;
}
