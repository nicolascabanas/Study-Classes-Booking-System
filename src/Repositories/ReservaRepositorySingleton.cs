using System;
using System.Collections.Generic;
using System.Linq;
using Study_Classes_Booking_System.src.Models;

namespace Study_Classes_Booking_System.src.Repositories
{
	public class ReservaRepositorySingleton
	{
		private static ReservaRepositorySingleton _instance;
		private static readonly object _lock = new object();
		private readonly List<Reserva> _reservas;

		private ReservaRepositorySingleton()
		{
			_reservas = new List<Reserva>();
		}

		public static ReservaRepositorySingleton GetInstance()
		{
			lock (_lock)
			{
				if (_instance == null)
				{
					_instance = new ReservaRepositorySingleton();
				}
				return _instance;
			}
		}

		public void Adicionar(Reserva reserva)
		{
			lock (_lock)
			{
				_reservas.Add(reserva);
			}
		}

		public List<Reserva> ListarTodas()
		{
			return _reservas;
		}

		public void GerarRelatorioDiario()
		{
			var hoje = DateTime.Now.Date;
			var reservasHoje = _reservas.Where(r => r.DataReserva.Date == hoje).ToList();

			Console.WriteLine("\n==============================================");
			Console.WriteLine($"   RELATÓRIO DE OCUPAÇÃO - {hoje:dd/MM/yyyy}");
			Console.WriteLine("==============================================");

			if (reservasHoje.Count == 0)
			{
				Console.WriteLine("Nenhuma ocupação registrada para hoje.");
			}
			else
			{
				foreach (var r in reservasHoje)
				{
					Console.WriteLine($"- Sala: {r.Sala.Nome.PadRight(15)} | Usuário: {r.Usuario.Nome}");
				}
			}
			Console.WriteLine("==============================================\n");
		}
	}
}