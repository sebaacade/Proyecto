using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Actualizar;

public class ActualizarReservaUseCase(IRepositorioReserva repo,ReservaValidador validador)
{
    public void Ejecutar(Reserva r){
        if (!validador.ValidarExiste(r.Id))
        {
            throw new EntidadNotFoundException("La reserva que se intenta actualizar no existe");
        }
        repo.ActualizarReserva(r);
    }
}
