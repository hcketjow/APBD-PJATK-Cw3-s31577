using TutorialCenter.Models;

namespace TutorialCenter.Repositories;

public interface IRoomRepository {
    IEnumerable<Room> GetRooms();
    IEnumerable<Room> GetByName(string name);
    Room? GetRoomById(int id);
    void AddRoom(Room room);
    bool UpdateRoom(Room room);
    void RemoveRoom(Room room);
    bool Exists(int id);
}
