using System;
using System.Collections.Generic;

namespace Pratice.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int CustomerNumber { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public int? AreaCode { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
}
