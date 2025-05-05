using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MonthlyRevenueController : ControllerBase
{
    private readonly IMediator _mediator;

    public MonthlyRevenueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetMonthlyRevenuesQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MonthlyRevenueDto dto)
    {
        await _mediator.Send(new CreateMonthlyRevenueCommand(dto));
        return Ok(new { message = "Inserted successfully" });
    }
}
    