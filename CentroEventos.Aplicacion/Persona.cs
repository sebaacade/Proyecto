using System;
using System.Dynamic;
using System.Runtime.InteropServices;

namespace CentroEventos.Aplicacion;

public class Persona
{
    public int id{get;set;}
    public string DNI{get;set;}="";
    public string Nombre{get;set;}="";
    public string Apellido{get;set;}="";
    public string Email{get;set;}="";
    public string Telefono{get;set;}="";

    public override string ToString()
    {
        return $"ID:{id}, DNI:{DNI}, Nombre:{Nombre}, Apellido:{Apellido}, Email:{Email}, Telefono:{Telefono}";
    }
}
