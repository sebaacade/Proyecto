using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class EntidadNotFoundException:Exception
{
    public EntidadNotFoundException(string mensaje):base(mensaje){}//TIRAR THROW EN LASC ALSES DE ELAS EXCEPCIONES 
}
