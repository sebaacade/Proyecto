using System;
using System.Collections.Generic;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    public List<Persona> ListarPersona();
    public bool Existe(int id);
}
