using System;
using System.Collections.Generic;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    public List<Persona> ListarPersona();
    public void AgregarPersona(Persona p);
    public void EliminarPersona(int id);
    public void ActualizarPersona(Persona p);
    public bool ExisteId(int id);
    bool ExisteDNI(string dni);
    bool ExisteEmail(string email);
}
