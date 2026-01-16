using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoDoacaoDeSangue.API.Controllers;
using ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.CreateDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.DeleteDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.UpdateDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions;
using ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetAllDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetByIdDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetDonationHistoryAsync;
using ProjetoDoacaoDeSangue.Application.ViewModels.DoadorViewModels;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Core.Models;

namespace ProjetoDoacaoDeSangue.Test.Controllers;

public class DoadorControllerTests
{

    private readonly Mock<IMediator> _mediatorMock;
    private readonly DoadorController _controller;

    public DoadorControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new DoadorController(_mediatorMock.Object);
    }

    [Fact]
    public async Task CreateDoadorAsync_ShouldReturnOk_WithId()
    {
        var command = new CreateDoadorAsyncCommand
        {
            NomeCompleto = "Doador Teste",
            Email = "doadotteste@gmail.com"
        };

        _mediatorMock
            .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var result = await _controller.CreateDoadorAsync(command);

        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();

        var response = okResult!.Value as ApiResponse<int>;
        response.Should().NotBeNull();
        response!.Status.Should().BeTrue();
        response.Value.Should().Be(1);

        _mediatorMock.Verify(
            m => m.Send(command, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task CreateDoadorAsync_ShouldThrowException_WhenMediatorThrows()
    {
        var command = new CreateDoadorAsyncCommand
        {
            NomeCompleto = "Doador",
            Email = "duplicado@gmail.com"
        };

        _mediatorMock
            .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new EmailAlreadyExistsException(command.Email));

        Func<Task> act = async () => await _controller.CreateDoadorAsync(command);

        await act.Should().ThrowAsync<EmailAlreadyExistsException>();
    }

    [Fact]
    public async Task DeleteDoadorAsync_ShouldReturnOk()
    {
        var id = 1;

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<DeleteDoadorAsyncCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Unit.Value);

        var result = await _controller.DeleteDoadorAsync(id);

        var ok = result as OkObjectResult;
        ok.Should().NotBeNull();

        var response = ok!.Value as ApiResponse<object>;
        response!.Status.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteDoadorAsync_ShouldThrowException_WhenNotFound()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<DeleteDoadorAsyncCommand>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new DonorNotFoundException(999));

        Func<Task> act = async () => await _controller.DeleteDoadorAsync(999);

        await act.Should().ThrowAsync<DonorNotFoundException>();
    }

    [Fact]
    public async Task UpdateDoadorAsync_ShouldReturnOk()
    {
        var command = new UpdateDoadorAsyncCommand
        {
            Id = 1,
            NomeCompleto = "Updated name"
        };

        _mediatorMock
            .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Unit.Value);

        var result = await _controller.UpdateDoadorAsync(command);

        var ok = result as OkObjectResult;
        ok.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateDoadorAsync_ShouldThrowException_WhenInvalidId()
    {
        var command = new UpdateDoadorAsyncCommand { Id = 999 };

        _mediatorMock
            .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new DonorNotFoundException(command.Id));

        Func<Task> act = async () => await _controller.UpdateDoadorAsync(command);

        await act.Should().ThrowAsync<DonorNotFoundException>();
    }

    [Fact]
    public async Task GetAllDoadorAsync_ShouldReturnOk()
    {
        var doadores = new List<Doador>
    {
        new() { Id = 1, NomeCompleto = "Doador" }
    };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllDoadorAsyncQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(doadores);

        var result = await _controller.GetAllDoadorAsync();

        var ok = result as OkObjectResult;
        ok.Should().NotBeNull();
    }

    [Fact]
    public async Task GetByIdDoadorAsync_ShouldReturnOk()
    {
        var dto = new GetDataDoadorViewDto { NomeCompleto = "Doador" };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetByIdDoadorAsyncQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(dto);

        var result = await _controller.GetByIdDoadorAsync(1);

        var ok = result as OkObjectResult;
        ok.Should().NotBeNull();
    }

    [Fact]
    public async Task GetByIdDoadorAsync_ShouldThrowException_WhenNotFound()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetByIdDoadorAsyncQuery>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new DonorNotFoundException(999));

        Func<Task> act = async () => await _controller.GetByIdDoadorAsync(999);

        await act.Should().ThrowAsync<DonorNotFoundException>();
    }

    [Fact]
    public async Task GetDonationHistoryAsync_ShouldReturnOk()
    {
        var history = new List<Doacao>();

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetDonationHistoryAsyncQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(history);

        var result = await _controller.GetDonationHistoryAsync(1);

        var ok = result as OkObjectResult;
        ok.Should().NotBeNull();
    }

    [Fact]
    public async Task GetDonationHistoryAsync_ShouldThrowException_WhenDoadorNotFound()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetDonationHistoryAsyncQuery>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new DonorNotFoundException(999));

        Func<Task> act = async () => await _controller.GetDonationHistoryAsync(999);

        await act.Should().ThrowAsync<DonorNotFoundException>();
    }
}
