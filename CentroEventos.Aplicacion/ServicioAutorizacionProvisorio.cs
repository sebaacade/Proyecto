using System;

namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvisorio:IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario,Permisos p){
        if(IdUsuario == 1){
            return true;
        }
        return false;
    }
}
