using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarReservaUseCase(IRepositorioReserva repo,ReservaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int IdUsuario,int id){
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permisos.ReservaBaja))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        //UNICAMENTE VERIFICO QUE LA RESERVA EXISTA
        if (!validador.ValidarExiste(id))
        {
            throw new EntidadNotFoundException("La reserva que se intenta eliminar no existe");
        }
        repo.EliminarReserva(id);
    }
}
