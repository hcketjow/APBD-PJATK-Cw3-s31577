using TutorialCenter.DTOs;

namespace TutorialCenter.Services;

public interface IRoomService {
    IEnumerable<RoomDto> GetAll(string? rooms);
    RoomDto GetById(int id);
    IEnumerable<RoomDto> GetByBuildingCode(string? buildingCode);
    RoomDto Add(CreateRoomDto room);
    RoomDto Update(int id, UpdateRoomDto room);
    void Remove(int id);
    IEnumerable<RoomDto> GetAll(RoomQueryDto query);
}
