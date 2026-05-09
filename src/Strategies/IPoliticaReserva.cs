using System;

namespace Study_Classes_Booking_System.src.Strategies
{
    public interface IPoliticaReserva
    {
        bool Validar(Reserva nova, List<Reserva> existentes); // Forma de validar diferentes tipos de reserva
    }
}