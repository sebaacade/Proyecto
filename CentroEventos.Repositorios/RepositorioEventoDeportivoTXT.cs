using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivoTXT: IRepositorioEventoDeportivo
{
    readonly string _nombreArchivo="xxx";
    public List<EventoDeportivo> ListarEventoDeportivo(){
        var resultado=new List<EventoDeportivo>();
        using var sr=new StreamReader(_nombreArchivo);
        while(!sr.EndOfStream){
            var e=new EventoDeportivo();
            e.id=int.Parse(sr.ReadLine()?? "");
            e.Nombre=sr.ReadLine()?? "";
            e.Descripcion=sr.ReadLine()?? "";
            e.FechaHoraInicio=DateTime.Parse(sr.ReadLine()??"");
            e.DuracionHoras=double.Parse(sr.ReadLine()?? "");
            e.CupoMaximo=int.Parse(sr.ReadLine()?? "");
            e.Responsableld=int.Parse(sr.ReadLine()??"");
            resultado.Add(e);
        }
        return resultado;
    }
}
