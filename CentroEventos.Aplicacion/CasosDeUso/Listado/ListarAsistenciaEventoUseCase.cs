using System;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarAsistenciaAEventoUseCase(IRepositorioReserva res, IRepositorioPersona per, IRepositorioEventoDeportivo eve)
{
    public List<Persona> Ejecutar() {

        var resultado = new List<Persona>();
        foreach (Reserva reserva in res.ListarReserva())
        {
            if (reserva.EstadoAsistencia == Reserva.Asistencia.Presente)// no se si esta bien
            {
                var evento = eve.BuscarEvento(reserva.EventoDeportivoId);
                if (evento.FechaHoraInicio < DateTime.Now)// no se si tengo q sumarle las horas de duracion y ersta bien escho
                {
                    var persona = per.BuscarPersona(reserva.PersonaId);
                    resultado.Add(persona);    
                }
            } 

        }      
        return resultado;
    }

}
