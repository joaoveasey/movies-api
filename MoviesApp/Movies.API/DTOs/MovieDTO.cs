using System.ComponentModel.DataAnnotations;

namespace movies_api.DTOs;

public class MovieDTO
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    public int Year { get; set; }
    public string? Genre { get; set; }
    public string? Director { get; set; }
    public int Duration { get; set; }
    public float Rating { get; set; }
}
