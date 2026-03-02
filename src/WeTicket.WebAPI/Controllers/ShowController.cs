using Microsoft.AspNetCore.Mvc;
using WeTicket.Application.Shared.Commands;
using WeTicket.Application.Shared.Dispatchers;
using WeTicket.Application.Shared.Queries;
using WeTicket.Application.Shows;
using WeTicket.Application.Shows.DTOs;

namespace WeTicket.WebAPI.Controllers;

[ApiController]
[Route("api/v1/shows")]
public class ShowController : ControllerBase
{
    private readonly ILogger<ShowController> _logger;
    private readonly IDispatcher _dispatcher;

    public ShowController(ILogger<ShowController> logger, IDispatcher dispatcher)
    {
        _logger = logger;
        _dispatcher = dispatcher;
    }

    [HttpGet]
    public async Task<ActionResult> GetListAsync()
    {
        ShowDto shows = await _dispatcher.DispatchAsync(new PagedQuery<ShowDto>
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

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await _dispatcher.DispatchAsync(new DeleteByIdCommand<Guid> { Id = id });
        return Ok();
    }
}