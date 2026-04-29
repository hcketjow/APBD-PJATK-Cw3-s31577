using Microsoft.AspNetCore.Mvc;
using TutorialCenter.DTOs;
using TutorialCenter.Exceptions;
using TutorialCenter.Services;

namespace TutorialCenter.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(IRoomService roomService) : ControllerBase
{
    // GET /api/rooms -> zwraca wszystkie sale
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? rooms)
    {
        return Ok(roomService.GetAll(rooms));
    }
    
    // GET /api/rooms/{id} -> Zwraca pojedynczą salę po identyfikatorze
    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            return Ok(roomService.GetById(id));
        }
        catch(RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    // GET /api/rooms/building/{buildingCode} -> Zwraca sale z wybranego budynku
    [HttpGet("buildings/{buildingCode}")]
    public IActionResult GetByBuildingCode([FromRoute] string buildingCode)
    {
        try
        {
            return Ok(roomService.GetByBuildingCode(buildingCode));
        }
        catch (RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    // GET /api/rooms?minCapacity=20&hasProjector=true&activeOnly=true -> Zwraca sale przefiltrowane po query stringu
    [HttpGet]
    public IActionResult GetAll([FromQuery] RoomQueryDto query)
    {
        return Ok(roomService.GetAll(query));
    }
    
    //POST /api/rooms -> Dodaje nową salę
    [HttpPost]
    public IActionResult Add([FromBody] CreateRoomDto room)
    {
        var createdRoom = roomService.Add(room);
        return CreatedAtAction(nameof(GetById), new { id = createdRoom.Id }, createdRoom);
    }
    
    //PUT /api/rooms/{id} -> Aktualizuje pełne dane sali
    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateRoomDto room)
    {
        try
        {
            return Ok(roomService.Update(id, room));
        }catch(RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    //DELETE /api/rooms/{id} Usuwa salę
    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            roomService.Remove(id);
            return NoContent();
        }
        catch (RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
