using System.Collections.Generic;
using Study_Classes_Booking_System.src.Models;

namespace Study_Classes_Booking_System.src.Repositories
{
	public class ReservaRepositorySingleton
	{
		private static ReservaRepositorySingleton _instance;
		private readonly List<Reserva> _reservas;

		private ReservaRepositorySingleton()
		{
			_reservas = new List<Reserva>();
		}

		public static ReservaRepositorySingleton GetInstance()
		{
			if (_instance == null)
			{
				_instance = new ReservaRepositorySingleton();
			}
			return _instance;
		}

		public void Adicionar(Reserva reserva)
		{
			_reservas.Add(reserva);
		}

		public List<Reserva> ListarTodas()
		{
			return _reservas;
		}
	}
}