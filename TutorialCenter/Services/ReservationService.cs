using TutorialCenter.DTOs;
using TutorialCenter.Exceptions;
using TutorialCenter.Mappers;
using TutorialCenter.Repositories;

namespace TutorialCenter.Services;

public class ReservationService(IReservationRepository reservationRepository, IRoomRepository roomRepository) : IReservationService {
    public IEnumerable<ReservationDto> GetAll(string? reservations)
    {
        return (string.IsNullOrEmpty(reservations)
            ? reservationRepository.GetReservations()
            : reservationRepository.GetReservationsByTopic(reservations)).Select(reservations => reservations.ToDto());
    }

    public ReservationDto GetById(int id)
    {
        var reservation = reservationRepository.GetReservationById(id);
        return (reservation is null) ? throw new ReservationNotFoundException(id) : reservation.ToDto();
    }

    public ReservationDto Add(CreateReservationDto reservation)
    {
        var room = roomRepository.GetRoomById(reservation.RoomId);
        if (room is null)
            throw new RoomNotFoundException(reservation.RoomId);
        if (!room.IsActive)
            throw new RoomNotActiveException(reservation.RoomId);
        var conflict = reservationRepository.GetReservations().Any(r => r.RoomId == reservation.RoomId
            && r.StartTime.Date == reservation.StartTime.Date
            && r.StartTime < reservation.EndTime
            && r.EndTime > reservation.StartTime);
        if (conflict)
            throw new ReservationConflictException();
        var reservationToAdd = reservation.ToDomain();
        reservationRepository.AddReservation(reservationToAdd);
        return reservationToAdd.ToDto();
    }

    public ReservationDto Update(int id, UpdateReservationDto reservation)
    {
        var reservationToUpdate = reservation.ToDomain();
        reservationToUpdate.Id = id;
        return !reservationRepository.UpdateReservation(reservationToUpdate)
            ? throw new ReservationNotFoundException(id)
            : reservationToUpdate.ToDto();
    }

    public void Remove(int id)
    {
        var reservationToRemove = reservationRepository.GetReservationById(id);
        if (reservationToRemove is null)
            throw new ReservationNotFoundException(id);
        reservationRepository.RemoveReservation(reservationToRemove);
    }
    
    public IEnumerable<ReservationDto> GetAll(ReservationQueryDto query)
    {
        var reservations = reservationRepository.GetReservations();
        if (query.Date.HasValue)
            reservations = reservations.Where(reservation => reservation.StartTime.Date == query.Date.Value.Date);
        if (query.Status.HasValue)
            reservations = reservations.Where(reservation => reservation.Status == query.Status.Value);
        if (query.RoomId.HasValue)
            reservations = reservations.Where(reservation => reservation.RoomId == query.RoomId.Value);
        return reservations.Select(reservation => reservation.ToDto());
    }
}
