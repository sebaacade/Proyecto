using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion;

public class EventoDeportivoValidador(IRepositorioEventoDeportivo repo,IRepositorioPersona r)
{
    public bool ValidarNombre(string nombre)
    {
        return !(string.IsNullOrWhiteSpace(nombre));
    }
    public bool ValidarDescripcion(string descripcion)
    {
        return !(string.IsNullOrWhiteSpace(descripcion));
    }
    public bool ValidarCupoMaximo(int n)
    {
        return (n > 0);
    }
    public bool ValidarFecha(DateTime fecha)
    {
        return !(fecha < DateTime.Now);
    }
    public bool ValidarDuracion(double duracion)
    {
        return !(duracion <= 0);
    }
    public bool ValidarResponsable(int id)
    {
        return r.ExisteId(id);
    }
    public bool ValidarExiste(int id)//unicamente para el modificar y eliminar
    {
        return repo.ExisteId(id);
    }
    public bool ValidarSiExpiro(int id)
    {
        return repo.Expiro(id);
    }
}

