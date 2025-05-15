using System;

namespace CentroEventos.Aplicacion.Actualizar;

public class ActualizarReservaUseCase(IRepositorioReserva repo)
{
    public void Ejecutar(Reserva r){
        repo.ActualizarReserva(r);
    }
}
