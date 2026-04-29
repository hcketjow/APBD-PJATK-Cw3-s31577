using TutorialCenter.DTOs;

namespace TutorialCenter.Services;

public interface IReservationService
{
    IEnumerable<ReservationDto> GetAll(string? topic);
    ReservationDto GetById(int id);
    ReservationDto Add(CreateReservationDto reservation);
    ReservationDto Update(int id, UpdateReservationDto reservation);
    void Remove(int id);
    IEnumerable<ReservationDto> GetAll(ReservationQueryDto query);
}
