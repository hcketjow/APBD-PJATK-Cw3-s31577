using TutorialCenter.DTOs;

namespace TutorialCenter.Services;

public interface IRoomService {
    IEnumerable<RoomDto> GetAll(string? rooms);
    RoomDto GetById(int id);
    RoomDto Add(CreateRoomDto room);
    RoomDto Update(int id, UpdateRoomDto room);
    void Remove(int id);
}
