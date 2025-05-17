using System;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo,EventoDeportivoValidador validador)
{
    public void Ejecutar(int id){ 
        if(!validador.ValidarExiste(id)){
            throw new EntidadNotFoundException("El evento que se intenta elimnar no esta registrado.");
        }
        //la excepcion que falta es de regla de negocio
        //BELEN CREO QUE LO HIZO
        repo.EliminarEventoDeportivo(id);
    }
}
