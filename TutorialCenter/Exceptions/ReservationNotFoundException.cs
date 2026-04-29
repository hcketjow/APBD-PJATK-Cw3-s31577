namespace TutorialCenter.Exceptions;

public class ReservationNotFoundException : Exception
{
    public ReservationNotFoundException(int id) : base($"Reservation with id: {id} not found") { }
    
    public ReservationNotFoundException(DateTime dateTime) : base($"Reservation with startDate: {dateTime} not found") { }
}
