using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Actualizar;

public class ActualizarReservaUseCase(IRepositorioReserva repo,ReservaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int IdUsuario,Reserva r){
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permisos.ReservaModificaion))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(r.Id))
        {
            throw new EntidadNotFoundException("La reserva que se intenta actualizar no existe");
        }
        repo.ActualizarReserva(r);
    }
}
