using TutorialCenter.DTOs;
using TutorialCenter.Exceptions;
using TutorialCenter.Mappers;
using TutorialCenter.Repositories;

namespace TutorialCenter.Services;

public class RoomService(IRoomRepository roomRepository) : IRoomService {
    public IEnumerable<RoomDto> GetAll(string? rooms)
    {
        return (string.IsNullOrEmpty(rooms)
            ? roomRepository.GetRooms()
            : roomRepository.GetByName(rooms)).Select(room => room.ToDo());
    }

    public RoomDto GetById(int id)
    {
        var room = roomRepository.GetRoomById(id);
        return (room is null) ? throw new RoomNotFoundException(id) : room.ToDo();
    }

    public RoomDto Add(CreateRoomDto room)
    {
        var roomToAdd = room.ToDomain();
        roomRepository.AddRoom(roomToAdd);
        return roomToAdd.ToDo();
    }

    public RoomDto Update(int id, UpdateRoomDto room)
    {
        var roomToUpdate = room.ToDomain();
        roomToUpdate.Id = id;
        return !roomRepository.UpdateRoom(roomToUpdate) ? throw new RoomNotFoundException(id) : roomToUpdate.ToDo();
    }

    public void Remove(int id)
    {
        var roomToRemove = roomRepository.GetRoomById(id);
        if (roomToRemove is null)
            throw new RoomNotFoundException(id);
        roomRepository.RemoveRoom(roomToRemove);
    }
}
