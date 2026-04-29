using TutorialCenter.DTOs;
using TutorialCenter.Models;

namespace TutorialCenter.Mappers;

public static class ReservationMappingExtensions {
    public static Reservation ToDomain(this ReservationDto reservationDto)
    {
        return new Reservation
        {
            Id = reservationDto.Id,
            RoomId = reservationDto.RoomId,
            OrganizerName = reservationDto.OrganizerName,
            Topic =  reservationDto.Topic,
            StartTime = reservationDto.StartTime,
            EndTime = reservationDto.EndTime,
            Status = reservationDto.Status
        };
    }

    public static Reservation ToDomain(this CreateReservationDto createReservation)
    {
        return new Reservation
        {
            RoomId = createReservation.RoomId,
            OrganizerName = createReservation.OrganizerName,
            Topic =  createReservation.Topic,
            StartTime = createReservation.StartTime,
            EndTime = createReservation.EndTime,
            Status = createReservation.ReservationStatus
        };
    }

    public static Reservation ToDomain(this UpdateReservationDto updateReservationDto)
    {
        return new Reservation
        {
            RoomId = updateReservationDto.RoomId,
            OrganizerName = updateReservationDto.OrganizerName,
            Topic =  updateReservationDto.Topic,
            StartTime = updateReservationDto.StartTime,
            EndTime = updateReservationDto.EndTime,
            Status = updateReservationDto.ReservationStatus
        };
    }

    public static ReservationDto ToDto(this Reservation reservation)
    {
        return new ReservationDto
        {
            Id = reservation.Id,
            RoomId = reservation.RoomId,
            OrganizerName = reservation.OrganizerName,
            Topic =  reservation.Topic,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime,
            Status = reservation.Status
        };
    }
}
