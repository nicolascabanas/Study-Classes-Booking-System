using System;
using System.Collections.Generic;
using System.Linq;
using Study_Classes_Booking_System.src.Models;
using Study_Classes_Booking_System.src.Factories;

namespace Study_Classes_Booking_System.src.Repositories
{
	public class ReservaRepositorySingleton
	{
		private static ReservaRepositorySingleton _instance;
		private static readonly object _lock = new object();
		private readonly List<Reserva> _reservas;
		private readonly List<Sala> _salasSistema;

		private ReservaRepositorySingleton()
		{
			_reservas = new List<Reserva>();

			// RF-01: Cadastro inicial de salas para consulta
			_salasSistema = new List<Sala>
			{
				new SalaEstudoIndividual { Id = 1, Nome = "Sala Individual A1", PrecoBase = 20.0 },
				new SalaTrabalhoGrupo { Id = 2, Nome = "Sala de Grupo B1", PrecoBase = 50.0 },
				new LaboratorioInformatica { Id = 3, Nome = "Laboratório Lab 01", PrecoBase = 100.0 }
			};
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

		// RF-01: Retorna salas que não possuem reserva no intervalo de tempo
		public List<Sala> BuscarSalasDisponiveis(DateTime inicio, DateTime fim)
		{
			var salasOcupadasIds = _reservas
				.Where(r => r.Status != StatusReserva.Cancelada &&
						   ((inicio >= r.DataReserva && inicio < r.DataReserva.AddHours(2)) ||
							(fim > r.DataReserva && fim <= r.DataReserva.AddHours(2))))
				.Select(r => r.Sala.Id)
				.Distinct()
				.ToList();

			return _salasSistema.Where(s => !salasOcupadasIds.Contains(s.Id)).ToList();
		}

		public List<Sala> ListarTodasAsSalas()
		{
			return _salasSistema;
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
					Console.WriteLine($"- Sala: {r.Sala.Nome.PadRight(20)} | Usuário: {r.Usuario.Nome}");
				}
			}
			Console.WriteLine("==============================================\n");
		}
	}
}