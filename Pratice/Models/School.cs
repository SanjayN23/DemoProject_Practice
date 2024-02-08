using System;
using System.Collections.Generic;

namespace Pratice.Models;

public partial class School
{
    public int SchoolId { get; set; }

    public string SchoolName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? PostCode { get; set; }

    public string? PostAddress { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
