using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using movies_api.Controllers;
using movies_api.DTOs;
using movies_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.API.Test.UnitTests;

public class GetMoviesUnitTest : IClassFixture<MoviesUnitTestController>
{
    private readonly MovieController _controller;

    public GetMoviesUnitTest(MoviesUnitTestController controller)
    {
        _controller = new MovieController(controller.repository, controller.mapper);
    }

    [Fact]
    public async Task GetMovieById_OkResult()
    {
        // arrange
        var prodId = 2;

        // act
        var data = await _controller.GetMovieById(prodId);

        // assert (fluent assertions)
        data.Result.Should().BeOfType<OkObjectResult>()
                   .Which.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetMovieById_Return_NotFound()
    {
        var prodId = 99999;

        var data = await _controller.GetMovieById(prodId);

        data.Result.Should().BeOfType<NotFoundObjectResult>()
                   .Which.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task GetMovieById_Return_BadRequest()
    {
        var prodId = -1;

        var data = await _controller.GetMovieById(prodId);

        data.Result.Should().BeOfType<BadRequestObjectResult>()
                   .Which.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task GetAllMovies_OkResult()
    {
        var data = await _controller.GetAllMovies();

        data.Result.Should().BeOfType<OkObjectResult>()
                   .Which.Value.Should().BeAssignableTo<IEnumerable<Movie>>()
                   .And.NotBeNull();
    }
}
