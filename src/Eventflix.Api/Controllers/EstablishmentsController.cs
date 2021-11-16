using Eventflix.Domain.Establishments;
using Eventflix.Domain.Establishments.Commands;
using Eventflix.Domain.Establishments.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eventflix.Api.Controllers;

[ApiController]
[Route("establishments")]
public class EstablishmentsController : ControllerBase
{
    private static readonly List<Establishment> _establishments = new ();

    [HttpGet]
    public IActionResult Get()
    {
        var items = _establishments.Select(e=>new EstablishmentItem
        {
            Id = e.Id,
            Name = e.Name,
            Status = e.Status.ToString()
        });

        return Ok(items);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateEstablishment request)
    {
        var establishment = new Establishment(
            name: request.Name
        );

        _establishments.Add(establishment);

        var details = new EstablishmentDetails
        {
            Id = establishment.Id,
            Name = establishment.Name,
            Status = establishment.Status.ToString()
        };

        return Created($"establishments/{details.Id}", details);
    }
}
