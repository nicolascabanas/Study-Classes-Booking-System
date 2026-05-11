using System;

namespace Study_Classes_Booking_System.src.Observers
{
    public class NotificacaoEmailObserver : IReservaObserver
    {
        public void Update(string evento, Reserva reserva) =>
            Console.WriteLine($"[EMAIL] {evento}: {reserva.Usuario.Email} — Sala {reserva.Sala.Nome}");
    }

}