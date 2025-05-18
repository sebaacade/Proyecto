using System;
using System.ComponentModel.DataAnnotations;

namespace CentroEventos.Aplicacion.Agregar;

public class AgregarPersonaUseCase(IRepositorioPersona repo,PersonaValidador validador,IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int IdUsuario,Persona p){
        if (!autorizacion.PoseeElPermiso(IdUsuario, Permisos.UsarioAlta))
        {
            throw new FalloAutorizacionException("Usuario no tiene Autorizacion");
        }
        if (!validador.ValidarNombre(p.Nombre))
        {
            throw new ValidacionException("No se ingreso el nombre de la Persona");
        }
        if (!validador.ValidarApellido(p.Apellido))
        {
            throw new ValidacionException("No se ingreso el apellido de la Persona");
        }
        if (!validador.ValidarDNI(p.DNI))
        {
            throw new ValidacionException("No se ingreso el DNI de la Persona");
        }
        if (!validador.ValidarEmail(p.Email))
        {
            throw new ValidacionException("No se ingreso el Email de la Persona");
        }
        if (validador.ValidarExisteEmail(p.Email))
        {
            throw new DuplicadoException("Ya existe una persona registrada con el Email ingresado.");
        }
        if (validador.ValidarExisteDni(p.DNI))
        {
            throw new DuplicadoException("Ya existe una persona registrada con el DNI ingresado.");
        }
        repo.AgregarPersona(p);
    }
}
