using System;

namespace CentroEventos.Aplicacion;

public class ReservaValidador(IRepositorioPersona r1,IRepositorioEventoDeportivo r2,IRepositorioReserva r3)
{
    public bool Validar(Reserva r, out String mensaje){
        mensaje="";
        //Existe id de r1 pregunta si existe la persona.
        //Existe id de r2 pregunta si existe el EventoDeportivo.
        if(!r1.ExisteId(r.PersonaId) && !r2.ExisteId(r.EventoDeportivoId)){
            mensaje+="Error.Entidad inexistente.\n";
        }
        //Reservo es un metodo de r3 que verifica si dicha persona ya hizo una reserva anteriormente.
        if(r3.Reservo(r)){
            mensaje+="Error.Esta persona ya reservo este Evento.\n";
        }
        //CantidadDeReservas me devuelve la cantidad de reservas del evento pasado por parametro.
        //DevolverCupoMaximo me retorna el cupoMaximo del evento pasado por parametro.
        //CONSULTA: esta bien hacer un metodo para devolver el cupo maximo de un evento?
        if(r3.CantidadDeReservas(r.EventoDeportivoId)==r2.DevolverCupoMaximo(r.EventoDeportivoId)){// unicamente pregunto por igual para tirar error,preguntar si es necesario preguntar tambien por mayor.
            mensaje+="Error.Llegaste al cupo maximo del Evento.\n";
        }
        return (mensaje =="");
    }
}
