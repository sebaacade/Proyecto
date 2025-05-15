using System;

namespace CentroEventos.Aplicacion.Agregar;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo,EventoDeportivoValidador validador)
{
    public void Ejecutar(EventoDeportivo e){
        if(!validador.Validar(e,out string mensaje)){//validacion usada
            throw new ValidacionException(mensaje);//excepcion usada
        }
        repo.AgregarEventoDeportivo(e);
    }
}
