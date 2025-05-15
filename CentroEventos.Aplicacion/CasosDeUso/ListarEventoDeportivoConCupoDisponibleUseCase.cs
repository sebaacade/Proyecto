namespace CentroEventos.Aplicacion;

public class ListarEventoDeportivoConCupoDisponibleUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioReserva repositorioReserva)
{

    public List<EventoDeportivo> Ejecutar()
    {
        List<EventoDeportivo> listado = new List<EventoDeportivo>();
        List<EventoDeportivo> temp = repositorioEventoDeportivo.ListarEventoDeportivo();
        foreach (EventoDeportivo e in temp){
            if (repositorioReserva.CantidadDeReservas(e.Id) < e.CupoMaximo && e.FechaHoraInicio > DateTime.Now)
            {
                listado.Add(e);
            }
        }    
            return listado;
    }
}