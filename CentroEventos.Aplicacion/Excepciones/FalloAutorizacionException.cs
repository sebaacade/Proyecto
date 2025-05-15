using System;

namespace CentroEventos.Aplicacion;

public class FalloAutorizacionException:Exception
{
    public FalloAutorizacionException(string mensaje):base(mensaje){}
}
