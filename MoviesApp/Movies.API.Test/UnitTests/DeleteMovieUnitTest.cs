using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using movies_api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.API.Test.UnitTests;

public class DeleteMovieUnitTest : IClassFixture<MoviesUnitTestController>
{
    private readonly MovieController _controller;

    public DeleteMovieUnitTest(MoviesUnitTestController controller)
    {
        _controller = new MovieController(controller.repository, controller.mapper);
    }

    [Fact]
    public async Task DeleteMovie_OkResult()
    {
        var data = await _controller.DeleteMovie(1);

        data.Result.Should().BeOfType<OkObjectResult>()
                   .Which.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task DeleteMovie_Return_NotFound()
    {
        var data = await _controller.DeleteMovie(99999);

        data.Result.Should().BeOfType<NotFoundObjectResult>()
                   .Which.StatusCode.Should().Be(404);
    }
}
