using System;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarReservaUseCase(IRepositorioReserva repo)
{
    public void Ejecutar(int id){
        repo.EliminarReserva(id);
    }
}
