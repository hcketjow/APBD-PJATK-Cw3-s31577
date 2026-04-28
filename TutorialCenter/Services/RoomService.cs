using TutorialCenter.DTOs;
using TutorialCenter.Repositories;

namespace TutorialCenter.Services;

public class RoomService(IRoomRepository roomRepository) : IRoomService {
    public IEnumerable<RoomDto> GetAll(string? rooms)
    {
        throw new NotImplementedException();
    }

    public RoomDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public RoomDto Add(CreateRoomDto room)
    {
        throw new NotImplementedException();
    }

    public RoomDto Update(int id, UpdateRoomDto room)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }
}
