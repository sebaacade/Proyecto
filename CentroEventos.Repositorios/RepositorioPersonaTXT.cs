using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioPersonaTXT : IRepositorioPersona
{
    readonly string _nombreArchivo="XXX";
    public List<Persona> ListarPersona(){
        var resultado=new List<Persona>();
        using var sr=new StreamReader(_nombreArchivo);
        while(!sr.EndOfStream){
            var p=new Persona();
            p.id=int.Parse(sr.ReadLine()??"");
            p.DNI=sr.ReadLine()??"";
            p.Nombre=sr.ReadLine()??"";
            p.Apellido=sr.ReadLine()??"";
            p.Email=sr.ReadLine()??"";
            p.Telefono=sr.ReadLine()??"";
            resultado.Add(p);
        }
        return resultado;
    }
    public bool Existe(int id){
        foreach(Persona p in this.ListarPersona()){
            if(p.id == id){
                return true;
            }
        }
        return false;
    }
}
