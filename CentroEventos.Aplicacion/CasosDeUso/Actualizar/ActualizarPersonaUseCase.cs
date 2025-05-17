using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Actualizar;

public class ActualizarPersonaUseCase(IRepositorioPersona repo,PersonaValidador validador)
{
    public void Ejecutar(Persona p){
        if (!validador.ValidarExiste(p.Id))
        {
            throw new EntidadNotFoundException("La persona que  se intenta actualizar no existe.");
        }
        repo.ActualizarPersona(p);
    }
}
