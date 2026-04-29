using Microsoft.AspNetCore.Mvc;
using TutorialCenter.DTOs;
using TutorialCenter.Exceptions;
using TutorialCenter.Services;

namespace TutorialCenter.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(IRoomService roomService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll([FromQuery] RoomQueryDto query)
    {
        return Ok(roomService.GetAll(query));
    }
    
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
    
    [HttpPost]
    public IActionResult Add([FromBody] CreateRoomDto room)
    {
        var createdRoom = roomService.Add(room);
        return CreatedAtAction(nameof(GetById), new { id = createdRoom.Id }, createdRoom);
    }
    
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
