namespace movies_api.Pagination;

public class MovieFilteredByYear
{
    public int? Year { get; set; }
    public string? Criterion { get; set; } // 'older', 'newer' or 'equal'
}
