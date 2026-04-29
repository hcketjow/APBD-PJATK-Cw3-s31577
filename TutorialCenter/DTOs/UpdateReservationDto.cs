using System.ComponentModel.DataAnnotations;
using TutorialCenter.Models;

namespace TutorialCenter.DTOs;

public class UpdateReservationDto {
    public int Id { get; set; }

    [Required]
    public int RoomId { get; set; }

    [Required]
    [MaxLength(100)]
    public string OrganizerName { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Topic { get; set; } = string.Empty;

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public ReservationStatus ReservationStatus { get; set; } = ReservationStatus.Planned;
}
