using System;

public class PrioridadeDocente : IPoliticaReserva
{
    public bool Validar(Reserva nova, List<Reserva> existentes)
    {
        var conflito = existentes.FirstOrDefault(e =>
            e.Sala.Id == nova.Sala.Id && e.Horario == nova.Horario);

        if (conflito == null) return true;
        // Professor pode sobrescrever reserva de aluno
        return nova.Usuario.Tipo == TipoUsuario.PROFESSOR
            && conflito.Usuario.Tipo == TipoUsuario.ALUNO;
    }
}
