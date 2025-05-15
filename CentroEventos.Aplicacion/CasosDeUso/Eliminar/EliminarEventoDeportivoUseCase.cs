using System;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo)
{
    public void Ejecutar(int id){
        repo.EliminarEventoDeportivo(id);
    }
}
