using System;
using System.Collections.Generic;

namespace Pratice.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public int ClassId { get; set; }

    public string CourseName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual School Class { get; set; } = null!;
}
