using System.ComponentModel.DataAnnotations;

namespace TutorialCenter.DTOs;

public class CreateRoomDto {
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string BuildingCode { get; set; } = String.Empty;
    
    [Required]
    public int Floor { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
    public int Capacity { get; set; }

    [Required]
    public bool HasProjector { get; set; }

    [Required]
    public bool IsActive { get; set; }
}
