using TutorialCenter.Models;

namespace TutorialCenter.DTOs;

public class ReservationQueryDto
{
    public DateTime? Date { get; set; }
    public ReservationStatus? Status { get; set; }
    public int? RoomId { get; set; }
}
