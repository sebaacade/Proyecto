using System;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoValidador(IRepositorioPersona repo)
{
    public bool Validar(EventoDeportivo evento,String mensaje){
        mensaje=" ";
        if(string.IsNullOrWhiteSpace(evento.Nombre)){
            mensaje="ERROR. No se puede ingresar un nombre vacio";
        }
        if(string.IsNullOrWhiteSpace(evento.Descripcion)){
            mensaje="ERROR. No se puede ingresar una descripcion vacia";
        }
        if(evento.FechaHoraInicio<DateTime.Now){
            mensaje="ERROR. La fecha tiene que ser actual o posterior";
        }
        if(evento.DuracionHoras<=0){
            mensaje="ERROR. La duracion debe ser mayor a cero";
        }
        if(!repo.Existe(evento.Responsableld)){
            mensaje="ERROR. El responsable no corresponde a una persona existenete";
        }
        return (mensaje==" ");
    }
}
