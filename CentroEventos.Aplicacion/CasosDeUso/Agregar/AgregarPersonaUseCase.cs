using System;

namespace CentroEventos.Aplicacion.Agregar;

public class AgregarPersonaUseCase(IRepositorioPersona repo,PersonaValidador validador)
{
    public void Ejecutar(Persona p){
        if(!validador.Validar(p,out string mensaje)){//validacion usada
            throw new ValidacionException(mensaje);//excepcion usada
        }
        repo.AgregarPersona(p);
    }
}
