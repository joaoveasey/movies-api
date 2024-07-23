using Microsoft.EntityFrameworkCore;
using movies_api.Model;


namespace movies_api.Infra;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
}
