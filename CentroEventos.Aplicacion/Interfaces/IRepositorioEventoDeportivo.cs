using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    public List<EventoDeportivo> ListarEventoDeportivo();
    public void AgregarEventoDeportivo(EventoDeportivo e);

    public void EliminarEventoDeportivo(int id);
    public void ActualizarEventoDeportivo(EventoDeportivo e);
    public bool ExisteId(int id);
    public int DevolverCupoMaximo(int id);
    public bool Expiro(int id);

}
