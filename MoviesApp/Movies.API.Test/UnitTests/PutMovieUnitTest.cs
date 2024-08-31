using movies_api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using movies_api.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Movies.API.Test.UnitTests;

public class PutMovieUnitTest : IClassFixture<MoviesUnitTestController>
{
    private readonly MovieController _controller;

    public PutMovieUnitTest(MoviesUnitTestController controller)
    {
        _controller = new MovieController(controller.repository, controller.mapper);
    }

    [Fact]
    public async Task PutMovie_OkResult()
    {
        var movie = new MovieDTO
        {
            Id = 1,
            Title = "The Matrix",
            Year = 1999,
            Director = "Lana Wachowski",
            Duration = 136,
            Genre = "Action, Sci-Fi",
            Rating = 4.8f
        };

        var data = await _controller.UpdateMovie(movie);

        data.Result.Should().BeOfType<OkObjectResult>()
                   .Which.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task PutMovie_Return_BadRequest()
    {
        MovieDTO movie = null;

        var data = await _controller.UpdateMovie(movie);

        data.Result.Should().BeOfType<BadRequestObjectResult>()
                   .Which.StatusCode.Should().Be(400);
    }
}
