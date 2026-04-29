namespace TutorialCenter.Exceptions;

public class ReservationNotFoundException : Exception
{
    public ReservationNotFoundException(int id) : base($"Reservation with id: {id} not found") { }
    
    public ReservationNotFoundException(string? topic) : base($"Reservation with topic: {topic} not found") { }
}
