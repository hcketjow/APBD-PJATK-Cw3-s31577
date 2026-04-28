using Microsoft.AspNetCore.Mvc;
using TutorialCenter.Repositories;

namespace TutorialCenter.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController(IReservationRepository reservationService) : ControllerBase {
    //GET /api/reservations -> Zwraca wszystkie rezerwacje
    
    //GET /api/reservations/{id} -> Zwraca jedną rezerwację
    
    //GET /api/reservations?date=2026-05-10&status=confirmed&roomId=2 -> Zwraca rezerwacje przefiltrowane po query stringu
    
    //POST /api/reservations -> Tworzy nową rezerwację
    
    //PUT /api/reservations/{id} -> Aktualizuje istniejącą rezerwację
    
    //DELETE /api/reservations/{id} -> Usuwa rezerwację.
}
