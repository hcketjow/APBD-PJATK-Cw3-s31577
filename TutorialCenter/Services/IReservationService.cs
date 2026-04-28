using TutorialCenter.DTOs;

namespace TutorialCenter.Services;

public interface IReservationService {
    IEnumerable<ReservationDto> GetAll(string? reservations);
    ReservationDto GetById(int id);
    ReservationDto Add(CreateReservationDto reservation);
    ReservationDto Update(int id, UpdateReservationDto reservation);
    void Remove(int id);
}
