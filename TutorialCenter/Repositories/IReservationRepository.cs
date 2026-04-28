using TutorialCenter.Models;

namespace TutorialCenter.Repositories;

public interface IReservationRepository {
    IEnumerable<Reservation> GetReservations();
    IEnumerable<Reservation> GetReservationsByStartDate(DateTime date);
    Reservation? GetReservationById(int id);
    void AddReservation(Reservation reservation);
    bool UpdateReservation(Reservation reservation);
    void RemoveReservation(Reservation reservation);
    bool Exists(int id);
}
