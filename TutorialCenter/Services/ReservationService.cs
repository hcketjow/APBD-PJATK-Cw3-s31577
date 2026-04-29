using TutorialCenter.DTOs;
using TutorialCenter.Exceptions;
using TutorialCenter.Mappers;
using TutorialCenter.Repositories;

namespace TutorialCenter.Services;

public class ReservationService(IReservationRepository reservationRepository) : IReservationService {
    public IEnumerable<ReservationDto> GetAll(DateTime? date)
    {
        return (date.HasValue ? reservationRepository.GetReservationsByStartDate(date.Value)
                : reservationRepository.GetReservations())
            .Select(reservation => reservation.ToDto());
    }

    public ReservationDto GetById(int id)
    {
        var reservation = reservationRepository.GetReservationById(id);
        return (reservation is null) ? throw new ReservationNotFoundException(id) : reservation.ToDto();
    }

    public ReservationDto Add(CreateReservationDto reservation)
    {
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
}
