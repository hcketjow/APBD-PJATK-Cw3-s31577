namespace TutorialCenter.DTOs;

public enum ReservationStatus {
    Planned,
    Confirmed,
    Cancelled
}

public class ReservationDto {
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string OrganizerName { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ReservationStatus ReservationStatus { get; set; } = ReservationStatus.Planned;
}
