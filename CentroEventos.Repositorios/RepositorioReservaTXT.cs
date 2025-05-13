using System;
using CentroEventos.Aplicacion;
using System.Collections.Generic;
using System.IO;

namespace CentroEventos.Repositorios;

public class RepositorioReservaTXT : IRepositorioReserva
{
    readonly string _nombreArchivo="XXX";

    public List<Reserva> ListarReserva(){
        var resultado=new List<Reserva>();
        using var sr=new StreamReader(_nombreArchivo);
        while(!sr.EndOfStream){
            var r=new Reserva();
            r.id=int.Parse(sr.ReadLine()?? "");
            r.PersonaId=int.Parse(sr.ReadLine()??"");
            r.EventoDeportivoId=int.Parse(sr.ReadLine()??"");
            r.FechaAltaReserva=DateTime.Parse(sr.ReadLine()??"");
            r.EstadoAsistencia=(Reserva.Asistencia)Enum.Parse(typeof(Reserva.Asistencia),sr.ReadLine()??"");//
            resultado.Add(r);
        }
        return resultado;
    }
}
