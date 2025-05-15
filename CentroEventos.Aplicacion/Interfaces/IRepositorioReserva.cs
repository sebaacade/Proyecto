using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    public List<Reserva> ListarReserva();
    public void AgregarReserva(Reserva r);
    public void EliminarReserva(int id);
    public void ActualizarReserva(Reserva r);
    public bool Reservo(Reserva r);
    public int CantidadDeReservas(int id);//devuelve la cantidad de personas que reservaron en un evento cuyo id se pasa por parametro
}
