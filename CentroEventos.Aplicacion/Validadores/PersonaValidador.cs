using System;

namespace CentroEventos.Aplicacion;

public class PersonaValidador(IRepositorioPersona repositorio)
{
public bool Validar(Persona persona, out string mensajeError){//Decirle a belen que lo cambie que la interfaz no va en el parametro del metodo
        mensajeError = "";                                    // si no va en el constructor primario.
        if(string.IsNullOrWhiteSpace(persona.Nombre)){

            mensajeError += "Nombre del persona inválido.\n";
        }

        if(string.IsNullOrWhiteSpace(persona.Apellido)){

            mensajeError += "Apellido del persona inválido.\n";
        }

        if(string.IsNullOrWhiteSpace(persona.DNI)){

            mensajeError += "DNI del persona inválido.\n";
        }
        else if (repositorio.ExisteDNI(persona.DNI)){
            mensajeError += "El DNI ya está registrado en otra persona.\n";
        }

        if(string.IsNullOrWhiteSpace(persona.Email)){

            mensajeError += "Email del persona inválido.\n";
        }
        else if (repositorio.ExisteEmail(persona.Email)){
            
            mensajeError += "El email ya está registrado en otra persona.\n";
        }

        return (mensajeError == "");
    }
}
