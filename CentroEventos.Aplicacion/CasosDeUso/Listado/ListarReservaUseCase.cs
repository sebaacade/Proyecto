using System;

namespace CentroEventos.Aplicacion;

public class ListarReservaUseCase(IRepositorioReserva repo)
{
    public List<Reserva> Ejecutar(){
        return repo.ListarReserva();
    }
}
