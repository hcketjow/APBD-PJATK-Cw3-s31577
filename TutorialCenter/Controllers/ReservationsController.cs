using Microsoft.AspNetCore.Mvc;
using TutorialCenter.DTOs;
using TutorialCenter.Exceptions;
using TutorialCenter.Repositories;
using TutorialCenter.Services;

namespace TutorialCenter.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController(IReservationService reservationService) : ControllerBase {
    [HttpGet]
    public IActionResult GetAll([FromQuery] ReservationQueryDto query)
    {
        return Ok(reservationService.GetAll(query));
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            return Ok(reservationService.GetById(id));
        }
        catch (ReservationNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] CreateReservationDto reservation)
    {
        var createdReservation = reservationService.Add(reservation);
        return CreatedAtAction(nameof(GetById), new { id = createdReservation.Id }, createdReservation);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateReservationDto reservation)
    {
        try
        {
            return Ok(reservationService.Update(id, reservation));
        }
        catch (ReservationNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            reservationService.Remove(id);
            return NoContent();
        }
        catch (ReservationNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
