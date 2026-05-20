using Microsoft.AspNetCore.Mvc;
using MiniStore.Application.Shared.Commands;
using MiniStore.Application.Shared.Dispatchers;
using MiniStore.Application.Shared.Queries;
using MiniStore.Application.Shows.Commands.CreateShowCommands;
using MiniStore.Application.Shows.Commands.UpdateShowCommands;
using MiniStore.Application.Shows.DTOs;

namespace MiniStore.WebAPI.Controllers;

[ApiController]
[Route("api/v1/shows")]
public class ShowController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public ShowController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpGet]
    public async Task<ActionResult> GetListAsync()
    {
        IEnumerable<ShowDto> shows = await _dispatcher.DispatchAsync(new PagedQuery<ShowDto>
        {
            PageSize = 10,
            PageNumber = 1
        });
        return Ok(shows);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetByIdAsync(Guid id)
    {
        ShowDto shows = await _dispatcher.DispatchAsync(new GetByIdQuery<ShowDto>
        {
            Id = Guid.Empty
        });
        return Ok(shows);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(CreateShowCommand createShowCommand)
    {
        Guid id = await _dispatcher.DispatchAsync(createShowCommand);
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateAsync(Guid id, UpdateShowCommand updateShowCommand)
    {
        await _dispatcher.DispatchAsync(updateShowCommand);
        return Ok(id);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await _dispatcher.DispatchAsync(new DeleteByIdCommand<Guid> { Id = id });
        return Ok();
    }
}