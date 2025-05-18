using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Actualizar;

public class ActualizarPersonaUseCase(IRepositorioPersona repo,PersonaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int IdUsuario,Persona p){
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permisos.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(p.Id))
        {
            throw new EntidadNotFoundException("La persona que  se intenta actualizar no existe.");
        }
        repo.ActualizarPersona(p);
    }
}
