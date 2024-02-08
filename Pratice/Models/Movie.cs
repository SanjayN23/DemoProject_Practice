using System;
using System.Collections.Generic;

namespace Pratice.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Language { get; set; }

    public string? Hero { get; set; }

    public string? Director { get; set; }

    public string? MusicDirector { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public decimal? Cost { get; set; }

    public decimal? Collection { get; set; }

    public decimal? Review { get; set; }
}
