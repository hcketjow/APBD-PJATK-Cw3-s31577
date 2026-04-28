using TutorialCenter.Models;

namespace TutorialCenter.Repositories;

public class ReservationRepository : IReservationRepository {
    private static int _nextId = 1;
    private readonly List<Reservation> _reservations = [];

    public IEnumerable<Reservation> GetReservations(){
        return _reservations;
    }

    public IEnumerable<Reservation> GetReservationsByStartDate(DateTime date){
        return _reservations.Where(x => x.StartTime == date);
    }

    public Reservation? GetReservationById(int id) {
        return  _reservations.FirstOrDefault(x => x.Id == id);
    }

    public void AddReservation(Reservation reservation) {
        reservation.Id = _nextId++;
        _reservations.Add(reservation);
    }

    public bool UpdateReservation(Reservation reservation) {
        var existing = GetReservationById(reservation.Id);
        if (existing is null)
            return false;
        existing.StartTime = reservation.StartTime;
        existing.EndTime = reservation.EndTime;
        existing.RoomId = reservation.RoomId;
        existing.OrganizerName = reservation.OrganizerName;
        existing.Topic =  reservation.Topic;
        existing.ReservationStatus = reservation.ReservationStatus;
        return true;
    }

    public void RemoveReservation(Reservation reservation) {
        _reservations.Remove(reservation);
    }

    public bool Exists(int id) {
        return _reservations.Any(x => x.Id == id);
    }
}
