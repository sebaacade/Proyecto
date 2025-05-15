using System;

namespace CentroEventos.Aplicacion;

public class OperacionInvalidaException:Exception
{
    public OperacionInvalidaException(string mensaje):base(mensaje){ }
}
