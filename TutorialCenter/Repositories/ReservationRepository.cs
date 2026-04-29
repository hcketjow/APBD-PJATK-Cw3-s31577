using TutorialCenter.Models;

namespace TutorialCenter.Repositories;

public class ReservationRepository : IReservationRepository {
    private static int _nextId = 1;
    private readonly List<Reservation> _reservations = [
        new Reservation { Id = 1, RoomId = 1, OrganizerName = "Anna Kowalska", Topic = "Warsztaty HTTP", StartTime = new DateTime(2026, 5, 10, 10, 0, 0), EndTime = new DateTime(2026, 5, 10, 12, 0, 0), Status = ReservationStatus.Confirmed },
        new Reservation { Id = 2, RoomId = 1, OrganizerName = "Jan Nowak", Topic = "Wprowadzenie do REST", StartTime = new DateTime(2026, 5, 11, 9, 0, 0), EndTime = new DateTime(2026, 5, 11, 11, 0, 0), Status = ReservationStatus.Planned },
        new Reservation { Id = 3, RoomId = 2, OrganizerName = "Maria Wiśniewska", Topic = "ASP.NET Core", StartTime = new DateTime(2026, 5, 12, 13, 0, 0), EndTime = new DateTime(2026, 5, 12, 15, 0, 0), Status = ReservationStatus.Planned },
        new Reservation { Id = 4, RoomId = 2, OrganizerName = "Piotr Zając", Topic = "Entity Framework", StartTime = new DateTime(2026, 5, 13, 10, 0, 0), EndTime = new DateTime(2026, 5, 13, 12, 0, 0), Status = ReservationStatus.Cancelled },
        new Reservation { Id = 5, RoomId = 3, OrganizerName = "Karolina Maj", Topic = "Docker i kontenery", StartTime = new DateTime(2026, 5, 14, 14, 0, 0), EndTime = new DateTime(2026, 5, 14, 16, 0, 0), Status = ReservationStatus.Confirmed },
        new Reservation { Id = 6, RoomId = 4, OrganizerName = "Tomasz Lewandowski", Topic = "CI/CD Pipeline", StartTime = new DateTime(2026, 5, 15, 9, 0, 0), EndTime = new DateTime(2026, 5, 15, 11, 0, 0), Status = ReservationStatus.Planned },
    ];

    public IEnumerable<Reservation> GetReservations(){
        return _reservations;
    }

    public IEnumerable<Reservation> GetReservationsByTopic(string? topic){
        return _reservations.Where(x => x.Topic == topic);
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
        existing.Status = reservation.Status;
        return true;
    }

    public void RemoveReservation(Reservation reservation) {
        _reservations.Remove(reservation);
    }

    public bool Exists(int id) {
        return _reservations.Any(x => x.Id == id);
    }
}
