using System;
using CentroEventos.Aplicacion;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace CentroEventos.Repositorios;

public class RepositorioReservaTXT : IRepositorioReserva
{
    readonly string _nombreArch = "reservas.txt";
    readonly string _archivoIds = "IDsReservas.txt";
    private int _idUltimo;
    public RepositorioReservaTXT(){
        using var sr =new  StreamReader(_archivoIds);
        _idUltimo = int.Parse(sr.ReadToEnd());
    }
    public List<Reserva> ListarReserva(){
        var resultado=new List<Reserva>();
        using var sr=new StreamReader(_nombreArch);
        while(!sr.EndOfStream){
            var r=new Reserva();
            r.Id=int.Parse(sr.ReadLine()?? "");
            r.PersonaId=int.Parse(sr.ReadLine()??"");
            r.EventoDeportivoId=int.Parse(sr.ReadLine()??"");
            r.FechaAltaReserva=DateTime.Parse(sr.ReadLine()??"");
            r.EstadoAsistencia=(Reserva.Asistencia)Enum.Parse(typeof(Reserva.Asistencia),sr.ReadLine()??"");//
            resultado.Add(r);
        }
        return resultado;
    }
    public void AgregarReserva(Reserva r){
        _idUltimo++;
        r.Id = _idUltimo;//decirle a belen que cambie la linea de codigo
        using var sw2 = new StreamWriter(_archivoIds, false);
        using var sw = new StreamWriter(_nombreArch, true);

        // Crear una lista de los campos comunes
        var campos = new List<string>
        {
            "ID: "+r.Id.ToString(),
            "Persona ID: "+r.PersonaId.ToString(),
            "Actividad deportiva ID: "+r.EventoDeportivoId.ToString(),
            r.FechaAltaReserva.ToString(),
            r.EstadoAsistencia.ToString()
        };

        // Escribir la línea al archivo, separada por coma
        sw.WriteLine(string.Join(" - ", campos));
        sw2.WriteLine(_idUltimo);
    }
    public void ActualizarReserva(Reserva r){
        Boolean encontrado = false;
        using var sr = new StreamReader(_nombreArch);
        using var sw = new StreamWriter ("archivoTemporal.TXT");
        Reserva temp = new Reserva();
        while (!sr.EndOfStream){
            temp.Id = int.Parse(sr.ReadLine()??"");
            temp.PersonaId = int.Parse(sr.ReadLine()??"");
            temp.EventoDeportivoId =int.Parse(sr.ReadLine()??"");
            temp.FechaAltaReserva = DateTime.Parse(sr.ReadLine()??"");
            temp.EstadoAsistencia =(Reserva.Asistencia)Enum.Parse(typeof(Reserva.Asistencia),sr.ReadLine ()??"");

            if (temp.Id ==r.Id){
                sw.WriteLine (r.Id);
                sw.WriteLine(r.PersonaId);
                sw.WriteLine(r.EventoDeportivoId);
                sw.WriteLine(r.FechaAltaReserva);
                sw.WriteLine(r.EstadoAsistencia);
                encontrado = true;
            }
            else{
                sw.WriteLine (temp.Id);
                sw.WriteLine(temp.PersonaId);
                sw.WriteLine(temp.EventoDeportivoId);
                sw.WriteLine(temp.FechaAltaReserva);
                sw.WriteLine(temp.EstadoAsistencia);
            }
        }
        if (!encontrado ){
            File.Delete("archivoTemporal.TXT");
            Console.WriteLine("Evento no encontrado");
        }
        else{
            File.Delete (_nombreArch);
            File.Move("archivoTemporal.TXT", _nombreArch);
        }
     }
     public void EliminarReserva(int Id){
        bool encontre=false;
        using var sr=new StreamReader(_nombreArch);//lo voy a usar para ir leyendo todo mi archivo.
        using var sw=new StreamWriter("temporal.txt",false);// SIEMPRE EN FALSE YA QUE SI NO POR CADA LLAMADA SE SIGUE SOBREESCRIBIENDO 
        while(!sr.EndOfStream){                            
            List<string>l=new List<string>();// creo una lista para ir guardo los strign que leo y ver si encontre mi id accediendo a l[0].
            for(int i=0;i<7;i++){
                l.Add(sr.ReadLine()??"");//voy guardando las lineas que leo a la lista de strings.
            }
            if(!(int.Parse(l[0].ToString())== Id)){
                foreach(string e in l){
                    sw.WriteLine(e);//voy escribiendo en mi archivo temporal linea por linea.
                }
            }
            else{
                encontre=true;//innecesario unicamente para imprimir si se encontro o no. Podria unicamente siempre pasar el
            }                 //archivo temporal al verdadero archivo y listo, pero lo haria innecesariamente. 
        }
        if(encontre){
            Console.WriteLine("Se elimino con exito el evento");
            File.Delete(_nombreArch);//borro el archivo ya que no me sirve mas.
            File.Move("temporal.txt",_nombreArch);//hago el intercambio con el archivo temporal.
        }
        else{
            Console.WriteLine("No se encontro el evento a eliminar");
            File.Delete("temporal.txt");//borro el archivo temporal si no lo encontre.
        }
    }
    public bool Reservo(Reserva r){
        foreach(Reserva n in this.ListarReserva()){
            if(n.Id== r.Id){
                if(n.EventoDeportivoId== r.EventoDeportivoId){
                    return true;
                }
            }
        }
        return false;
    }
    public int CantidadDeReservas(int id){//devuelve la cantidad de personas que reservaron en un evento cuyo id se pasa por parametro
        int total=0;
        foreach(Reserva r in this.ListarReserva()){
            if(r.EventoDeportivoId==id){
                total++;
            }
        }
        return total;
    }
}
