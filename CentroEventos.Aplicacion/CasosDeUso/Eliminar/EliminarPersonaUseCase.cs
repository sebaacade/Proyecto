using System;

namespace CentroEventos.Aplicacion.Eliminar;

public class EliminarPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar(int id){
        repo.EliminarPersona(id);
    }
}
