using TutorialCenter.Models;

namespace TutorialCenter.Repositories;

public class RoomRepository : IRoomRepository{
    private static int _nextId = 1;
    private readonly List<Room> _room = [];
    
    public IEnumerable<Room> GetRooms() {
        return _room;
    }

    public IEnumerable<Room> GetByName(string name) {
        return  _room.Where(x => x.Name == name);
    }
    
    public IEnumerable<Room> GetByBuildingCode(string? buildingCode)
    {
        return _room.Where(x => x.BuildingCode == buildingCode);
    }

    public Room? GetRoomById(int id) {
        return _room.FirstOrDefault(x => x.Id == id);
    }

    public void AddRoom(Room room) {
        room.Id = _nextId++;
        _room.Add(room);
    }

    public bool UpdateRoom(Room room) {
        var existing = GetRoomById(room.Id);
        if (existing is null)
            return false;
        existing.Name = room.Name;
        existing.HasProjector = room.HasProjector;
        existing.BuildingCode = room.BuildingCode;
        existing.Capacity = room.Capacity;
        existing.IsActive = room.IsActive;
        existing.Floor = room.Floor;
        return true;
    }

    public void RemoveRoom(Room room) {
        _room.Remove(room);
    }

    public bool Exists(int id) {
        return _room.Any(x => x.Id == id);
    }
}
