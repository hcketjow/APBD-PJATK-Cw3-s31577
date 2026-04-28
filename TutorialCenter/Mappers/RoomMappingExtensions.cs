using TutorialCenter.DTOs;
using TutorialCenter.Models;

namespace TutorialCenter.Mappers;

public static class RoomMappingExtensions {
    public static Room ToDomain(this RoomDto roomDto)
    {
        return new Room
        {
            Id = roomDto.Id,
            Name = roomDto.Name,
            BuildingCode =  roomDto.BuildingCode,
            Floor =  roomDto.Floor,
            Capacity = roomDto.Capacity,
            HasProjector = roomDto.HasProjector,
            IsActive =  roomDto.IsActive
        };
    }
    
    public static Room ToDomain(this CreateRoomDto createRoomDto)
    {
        return new Room
        {
            Name = createRoomDto.Name,
            BuildingCode =  createRoomDto.BuildingCode,
            Floor =  createRoomDto.Floor,
            Capacity = createRoomDto.Capacity,
            HasProjector = createRoomDto.HasProjector,
            IsActive =  createRoomDto.IsActive
        };
    }
    
    public static Room ToDomain(this UpdateRoomDto updateRoomDto)
    {
        return new Room
        {
            Name = updateRoomDto.Name,
            BuildingCode =  updateRoomDto.BuildingCode,
            Floor =  updateRoomDto.Floor,
            Capacity = updateRoomDto.Capacity,
            HasProjector = updateRoomDto.HasProjector,
            IsActive =  updateRoomDto.IsActive
        };
    }
    
    public static RoomDto ToDo(this Room room)
    {
        return new RoomDto {
            Id = room.Id,
            Name = room.Name,
            BuildingCode =  room.BuildingCode,
            Floor =  room.Floor,
            Capacity = room.Capacity,
            HasProjector = room.HasProjector,
            IsActive =  room.IsActive
        };
    }
}
