namespace TutorialCenter.Models;

public class Reservation {
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string OrganizerName { get; set; }
    public string Topic { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public Status ReservationStatus { get; set; } = Status.planned;
    
    public enum Status
    {
        planned,
        confirmed,
        cancelled
    }
}
