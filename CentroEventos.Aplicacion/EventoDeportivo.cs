using System;

namespace CentroEventos.Aplicacion;

public class EventoDeportivo
{
    public int id{get;set;}
    public string Nombre{get;set;}="";
    public string Descripcion{get;set;}="";
    public DateTime FechaHoraInicio{get;set;}
    public double DuracionHoras{get;set;}//duracion del evento en horas, ej 1.5 para una hora y media
    public int CupoMaximo{get;set;}
    public int Responsableld{get;set;}//id de la persona a cargo del evento

    public override string ToString(){
        return $"id:{id}, Nombre:{Nombre}, Descripcion:{Descripcion}, FechaHoraInicio:{FechaHoraInicio}, DuracionHoras{DuracionHoras},";
    }
}
