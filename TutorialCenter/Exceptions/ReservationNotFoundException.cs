namespace TutorialCenter.Exceptions;

public class ReservationNotFoundException(int id) : Exception($"Reservation with id: {id} not found");
