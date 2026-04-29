using TutorialCenter.Models;

namespace TutorialCenter.Repositories;

public class RoomRepository : IRoomRepository{
    private static int _nextId = 1;
    private readonly List<Room> _room = [
        new Room { Id = 1, Name = "Lab 101", BuildingCode = "A", Floor = 1, Capacity = 20, HasProjector = true, IsActive = true },
        new Room { Id = 2, Name = "Lab 202", BuildingCode = "A", Floor = 2, Capacity = 30, HasProjector = false, IsActive = true },
        new Room { Id = 3, Name = "Sala B1", BuildingCode = "B", Floor = 0, Capacity = 15, HasProjector = true, IsActive = false },
    ];

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
