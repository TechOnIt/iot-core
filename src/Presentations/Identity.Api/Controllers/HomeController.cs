using iot.Application.Commands.LoginHistories;
using iot.Application.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iot.Identity.Api.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateCommand command)
    {
        var result = await _mediator.Send(new UserCreateCommand
        {
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            Password = command.Password,
            Name = command.Name,
            Surname = command.Surname
        });

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Test()
    {
        var createLoginHistoryResult = await _mediator.Send(new LoginHistoryCreateCommand
        {
            Ip = "192.168.1.100"
        });

        return Ok();
    }
}