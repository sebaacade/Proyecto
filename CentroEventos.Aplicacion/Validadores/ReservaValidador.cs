using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion;

public class ReservaValidador(IRepositorioPersona r1, IRepositorioEventoDeportivo r2, IRepositorioReserva r3)
{
    public bool ValidarPersonaQueRervo(int id)
    {
        return r1.ExisteId(id);
    }
    public bool ValidarEventoDeportivoReservado(int id)
    {
        return r2.ExisteId(id);
    }
    public bool ValidarSiYaReservo(int idP,int idE)// idP id de la persona que reservo, idE id del evento en el que se quiere reservar.
    {
        return r3.Reservo(idP,idE);
    }
    public bool ValidarSiHayCupo(int idEvento)
    {
        return !(r3.CantidadDeReservas(idEvento) == r2.DevolverCupoMaximo(idEvento));
    }
    public bool ValidarExiste(int id)//unicamente para el modifica y eliminar
    {
        return r3.ExisteId(id);
    }
}
