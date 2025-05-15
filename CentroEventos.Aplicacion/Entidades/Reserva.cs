using System;
using System.Runtime;

namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int Id{get;set;}
    public int PersonaId{get;set;}//id de la persona que hace la reserva
    public int EventoDeportivoId{get;set;}//id del evento deportivo reservado
    public DateTime FechaAltaReserva{get;set;}//fecha y hora en que se realizo la inscripcion 
    public enum Asistencia{
        Pendiente,
        Presente,
        Ausente
    }
    public Asistencia EstadoAsistencia{get;set;}

    public override string ToString(){
        return $"ID:{Id}, PersonaId(id de la persona que concreto la reserva): {PersonaId}, EventoDeportivo(id del evento que se reservo):{EventoDeportivoId}, Fecha y Hora:{FechaAltaReserva}, Asistencia:{EstadoAsistencia}";
    }
}
