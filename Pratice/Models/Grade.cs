using System;
using System.Collections.Generic;

namespace Pratice.Models;

public partial class Grade
{
    public int? GradeId { get; set; }

    public int StudentId { get; set; }

    public int? CourseId { get; set; }

    public int? Grade1 { get; set; }
}
