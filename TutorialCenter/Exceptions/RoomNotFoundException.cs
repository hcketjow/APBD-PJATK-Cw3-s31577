namespace TutorialCenter.Exceptions;

public class RoomNotFoundException : Exception
{
    public RoomNotFoundException(int id) : base($"Room with id: {id} not found") { }
    
    public RoomNotFoundException(string buildingCode) : base($"Room with building code: {buildingCode} not found") { }
}
