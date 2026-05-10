using System;

namespace Study_Classes_Booking_System.src.Observers
{
    public interface IReservaObserver
    {
        void Update(string evento, Reserva reserva);//Interface do Observer
    }
}