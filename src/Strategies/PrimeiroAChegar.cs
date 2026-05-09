using System;

namespace Study_Classes_Booking_System.src.Strategies
{
    public class PrimeiroAChegar : IPoliticaReserva
    {
        public bool Validar(Reserva nova, List<Reserva> existentes) =>
            !existentes.Any(e =>
                e.Sala.Id == nova.Sala.Id &&
                e.Horario == nova.Horario &&
                e.Status != StatusReserva.CANCELADA); //Estratégia para validar quem chega primeiro
    }    
}
