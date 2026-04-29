using Microsoft.AspNetCore.Mvc;
using TutorialCenter.DTOs;
using TutorialCenter.Exceptions;
using TutorialCenter.Repositories;
using TutorialCenter.Services;

namespace TutorialCenter.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController(IReservationService reservationService) : ControllerBase {
    //GET /api/reservations -> Zwraca wszystkie rezerwacje
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? reservations)
    {
        return Ok(reservationService.GetAll(reservations));
    }
    
    //GET /api/reservations/{id} -> Zwraca jedną rezerwację
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
    
    //GET /api/reservations?date=2026-05-10&status=confirmed&roomId=2 -> Zwraca rezerwacje przefiltrowane po query stringu
    [HttpGet]
    public IActionResult GetAll([FromQuery] ReservationQueryDto query)
    {
        return Ok(reservationService.GetAll(query));
    }
    
    //POST /api/reservations -> Tworzy nową rezerwację
    [HttpPost]
    public IActionResult Create([FromBody] CreateReservationDto reservation)
    {
        var createdReservation = reservationService.Add(reservation);
        return CreatedAtAction(nameof(GetById), new { id = createdReservation.Id }, createdReservation);
    }
    
    //PUT /api/reservations/{id} -> Aktualizuje istniejącą rezerwację
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
    
    //DELETE /api/reservations/{id} -> Usuwa rezerwację.
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
