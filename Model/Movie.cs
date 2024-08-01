using System.ComponentModel.DataAnnotations;

namespace movies_api.Model;

public class Movie
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public int Duration { get; set; }
    public float Rating { get; set; }

    //public Movie(int id, string title, int year, string genre, string director, int duration, float rating)
    //{
    //    Id = id;
    //    Title = title;
    //    Year = year;
    //    Genre = genre;
    //    Director = director;
    //    Duration = duration;
    //    Rating = rating;
    //}
}
