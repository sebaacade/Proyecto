using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarPersonaUseCase(IRepositorioPersona repo,PersonaValidador validador)
{
    public void Ejecutar(int id){
        if (!validador.ValidarExiste(id))
        {
            throw new EntidadNotFoundException("La persona que se intenta eliminar no esta registrada");
        }
        //la excepcion que falta es de regla de negocio
        //BELEN CREO QUE LO HIZO
        repo.EliminarPersona(id);
    }
}
