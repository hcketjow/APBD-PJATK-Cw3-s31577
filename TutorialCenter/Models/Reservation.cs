namespace TutorialCenter.Models;

public enum ReservationStatus
{
    Planned,
    Confirmed,
    Cancelled
}

public class Reservation {
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string OrganizerName { get; set; }
    public string Topic { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Planned;
}
