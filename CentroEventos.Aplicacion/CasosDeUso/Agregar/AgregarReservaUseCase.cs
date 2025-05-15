using System;

namespace CentroEventos.Aplicacion.Agregar;

public class AgregarReservaUseCase(IRepositorioReserva repo,ReservaValidador validador)
{
    public void Ejecutar(Reserva r){
        if(!validador.Validar(r,out string mensaje)){//validacion usada
            throw new ValidacionException(mensaje);//excepcion usada
        }
        repo.AgregarReserva(r);
    }
}
