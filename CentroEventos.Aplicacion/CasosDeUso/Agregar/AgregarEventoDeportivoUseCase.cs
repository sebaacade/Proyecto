using System;
using System.ComponentModel.DataAnnotations;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Agregar;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repo,EventoDeportivoValidador validador)
{
    public void Ejecutar(EventoDeportivo e){
        //tira una exepcion que se propaga al main donde se lo llama y se lo atrapa con dicho catch.?
        if (!validador.ValidarNombre(e.Nombre)) {
            throw new ValidacionException("No se ingreso el nombre del evento.");
        }
        if (!validador.ValidarDescripcion(e.Descripcion))
        {
            throw new ValidacionException("No se ingreso la Descripcion del evento.");
        }
        if (validador.ValidarCupoMaximo(e.CupoMaximo))
        {
            throw new ValidacionException("Cupo Maximo invalido, debe ser mayor a 0.");
        }
        if (!validador.ValidarDuracion(e.DuracionHoras))
        {
            throw new ValidacionException("La duracion debe ser mayor a 0");
        }
        if (!validador.ValidarFecha(e.FechaHoraInicio))
        {
            throw new ValidacionException("La fecha tiene que ser actual o posterior.");
        }
        if (!validador.ValidarResponsable(e.ResponsableId))
        {
            throw new EntidadNotFoundException("El responsable no corresponde a una persona existente.");
        }
        repo.AgregarEventoDeportivo(e);
    }
}
