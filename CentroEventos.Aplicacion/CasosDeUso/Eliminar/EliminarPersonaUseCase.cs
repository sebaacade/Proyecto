using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarPersonaUseCase(IRepositorioPersona repo,PersonaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int IdUsuario,int id){
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permisos.UsuarioBaja))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarExiste(id))
        {
            throw new EntidadNotFoundException("La persona que se intenta eliminar no esta registrada");
        }
         if(!validador.ValidarNoTieneReservaAsociada(id)){
            throw new OperacionInvalidaException("La persona que se intenta eliminar cuenta con al menos una reserva asociada.");
        }
        if(!validador.ValidarNoEsResponsableDeEventoDeportivo(id)){
            throw new OperacionInvalidaException("La persona que se intenta eliminar es responsable de al menos un evento deportivo.");
        }
        //la excepcion que falta es de regla de negocio
        //BELEN CREO QUE LO HIZO
        repo.EliminarPersona(id);
    }
}
