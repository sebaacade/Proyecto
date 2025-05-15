using System;

namespace CentroEventos.Aplicacion.Actualizar;

public class ActualizarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo)
{
    public void Ejecutar(EventoDeportivo e){
        repo.ActualizarEventoDeportivo(e);
    }
}
