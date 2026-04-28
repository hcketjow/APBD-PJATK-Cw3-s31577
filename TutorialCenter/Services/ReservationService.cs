using TutorialCenter.DTOs;
using TutorialCenter.Repositories;

namespace TutorialCenter.Services;

public class ReservationService(IReservationRepository reservationRepository) : IReservationService {
    public IEnumerable<ReservationDto> GetAll(string? reservations)
    {
        return null;
    }

    public ReservationDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public ReservationDto Add(CreateReservationDto reservation)
    {
        throw new NotImplementedException();
    }

    public ReservationDto Update(int id, UpdateReservationDto reservation)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }
}
