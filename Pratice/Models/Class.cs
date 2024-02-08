using System;
using System.Collections.Generic;

namespace Pratice.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int SchoolId { get; set; }

    public string ClassName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual School School { get; set; } = null!;
}
