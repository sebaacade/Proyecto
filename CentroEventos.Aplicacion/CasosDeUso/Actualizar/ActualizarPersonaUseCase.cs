using System;

namespace CentroEventos.Aplicacion.Actualizar;

public class ActualizarPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar(Persona p){
        repo.ActualizarPersona(p);
    }
}
