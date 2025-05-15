using System;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoValidador(IRepositorioPersona repo)
{
    public bool Validar(EventoDeportivo evento,out String mensaje){
        mensaje="";
        if(string.IsNullOrWhiteSpace(evento.Nombre)){
            mensaje+="ERROR. No se puede ingresar un nombre vacio.\n";
        }
        if(string.IsNullOrWhiteSpace(evento.Descripcion)){
            mensaje+="ERROR. No se puede ingresar una descripcion vacia.\n";
        }
        if(evento.FechaHoraInicio<DateTime.Now){
            mensaje+="ERROR. La fecha tiene que ser actual o posterior.\n";
        }
        if(evento.DuracionHoras<=0){
            mensaje+="ERROR. La duracion debe ser mayor a cero.\n";
        }
        if(!repo.ExisteId(evento.ResponsableId)){
            mensaje+="ERROR. El responsable no corresponde a una persona existenete.\n";
        }
        return (mensaje=="");
    }
}
