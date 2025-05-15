using System;

namespace CentroEventos.Aplicacion;

public interface IServicioAutorizacion
{
   public bool PoseeElPermiso(int IdUsuario,Permisos permiso);
}
