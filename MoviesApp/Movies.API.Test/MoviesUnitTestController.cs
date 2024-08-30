using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movies_api.DTOs.Mappings;
using movies_api.Infra;
using movies_api.Interfaces;
using movies_api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.API.Test;

public class MoviesUnitTestController
{
    public IUnitOfWork repository;
    public IMapper mapper;
    public static DbContextOptions<ApplicationDbContext> dbContextOptions {  get; }

    public static string connectionString =
        "Server=127.0.0.1;Port= 3306;User ID=root;Password=jvp_04022005;Database=movie_db";

    static MoviesUnitTestController()
    {
        dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .Options;
    }

    public MoviesUnitTestController()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MovieDTOMappingProfile());
        });

        mapper = config.CreateMapper();
        var context = new ApplicationDbContext(dbContextOptions);
        repository = new UnitOfWork(context);
    }
}
