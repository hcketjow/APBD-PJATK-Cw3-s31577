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
            : roomRepository.GetByName(rooms)).Select(room => room.ToDto());
    }

    public RoomDto GetById(int id)
    {
        var room = roomRepository.GetRoomById(id);
        return (room is null) ? throw new RoomNotFoundException(id) : room.ToDto();
    }

    public IEnumerable<RoomDto> GetByBuildingCode(string? buildingCode)
    {
        var rooms = roomRepository.GetByBuildingCode(buildingCode);
        return !rooms.Any() ? throw new RoomNotFoundException(buildingCode!) : rooms.Select(room => room.ToDto());
    }

    public RoomDto Add(CreateRoomDto room)
    {
        var roomToAdd = room.ToDomain();
        roomRepository.AddRoom(roomToAdd);
        return roomToAdd.ToDto();
    }

    public RoomDto Update(int id, UpdateRoomDto room)
    {
        var roomToUpdate = room.ToDomain();
        roomToUpdate.Id = id;
        return !roomRepository.UpdateRoom(roomToUpdate) ? throw new RoomNotFoundException(id) : roomToUpdate.ToDto();
    }

    public void Remove(int id)
    {
        var roomToRemove = roomRepository.GetRoomById(id);
        if (roomToRemove is null)
            throw new RoomNotFoundException(id);
        roomRepository.RemoveRoom(roomToRemove);
    }

    public IEnumerable<RoomDto> GetAll(RoomQueryDto query)
    {
        var rooms = roomRepository.GetRooms();
        if (query.Capacity.HasValue)
            rooms = rooms.Where(room => room.Capacity >= query.Capacity.Value);
        if (query.HasProjector.HasValue)
            rooms = rooms.Where(room => room.HasProjector == query.HasProjector.Value);
        if (query.IsActive.HasValue)
            rooms = rooms.Where(room => room.IsActive == query.IsActive.Value);
        return rooms.Select(room => room.ToDto());
    }
}
