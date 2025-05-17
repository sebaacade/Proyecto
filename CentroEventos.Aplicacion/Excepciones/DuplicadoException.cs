using System;

namespace CentroEventos.Aplicacion;

public class DuplicadoException : Exception
{
    public DuplicadoException(string mensaje) : base(mensaje){}
    
}
