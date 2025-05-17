using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarReservaUseCase(IRepositorioReserva repo,ReservaValidador validador)
{
    public void Ejecutar(int id){
        //UNICAMENTE VERIFICO QUE LA RESERVA EXISTA
        if (!validador.ValidarExiste(id))
        {
            throw new EntidadNotFoundException("La reserva que se intenta eliminar no existe");
        }
        repo.EliminarReserva(id);
    }
}
