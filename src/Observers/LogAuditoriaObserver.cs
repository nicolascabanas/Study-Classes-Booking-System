using System;

namespace Study_Classes_Booking_System.src.Observers
{
    public class LogAuditoriaObserver : IReservaObserver
    {
        public void Update(string evento, Reserva reserva) =>
            Console.WriteLine($"[LOG] {DateTime.Now} | {evento} | Reserva {reserva.Id}");
    }
}