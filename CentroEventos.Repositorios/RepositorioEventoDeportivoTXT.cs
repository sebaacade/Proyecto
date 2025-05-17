using System;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{
    readonly string _nombreArchivo = "personas.txt";
    readonly string _archivoIds = "IDs.txt";
    private int _idUltimo;

    public RepositorioEventoDeportivoTXT()
    {
        using var sr = new StreamReader(_archivoIds);
        _idUltimo = int.Parse(sr.ReadToEnd());///ESTA BIEN? NO HAY QUE USAR UN STATIC?constructor
    }
    public List<EventoDeportivo> ListarEventoDeportivo()
    {//MODIFICADO POR LA BAJA LOGICA
        var resultado = new List<EventoDeportivo>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {// mientras no termine el archivo.
            var e = new EventoDeportivo();//creo un eventoDeportivo para ir agregando sus campos.
            string IdLinea = sr.ReadLine() ?? "";// leo una linea en una variable string.
            if (IdLinea.StartsWith("*"))
            {//aca verifico que no empiece por "*", osea que no tenga borrado logico.
                for (int i = 0; i < 6; i++)
                {
                    sr.ReadLine();//si tiene borrado logico, lo salto leyendo las demas lineas.
                }
            }
            else
            {// si no leo las linea y las agrego a la lista.
                e.Id = int.Parse(IdLinea);
                e.Nombre = sr.ReadLine() ?? "";
                e.Descripcion = sr.ReadLine() ?? "";
                e.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
                e.DuracionHoras = double.Parse(sr.ReadLine() ?? "");
                e.CupoMaximo = int.Parse(sr.ReadLine() ?? "");
                e.ResponsableId = int.Parse(sr.ReadLine() ?? "");
                resultado.Add(e);
            }
        }
        return resultado;
    }
    public void AgregarEventoDeportivo(EventoDeportivo p)
    {
        _idUltimo++;
        p.Id = _idUltimo;//decirle a belen que cambie la linea de codigo
        using var sw2 = new StreamWriter(_archivoIds, false);
        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(p.Id);
        sw.WriteLine(p.Nombre);
        sw.WriteLine(p.Descripcion);
        sw.WriteLine(p.FechaHoraInicio);
        sw.WriteLine(p.DuracionHoras);
        sw.WriteLine(p.CupoMaximo);
        sw.WriteLine(p.ResponsableId);
    }
    public void EliminarEventoDeportivo(int Id)
    {//CONSIDERAR QUE SI HAGO UN BORRADO LOGICO TENGO QUE CAMBIAR EL LISTAR.
        bool encontre = false;// va verificar si se elimino o no.
        using var sr = new StreamReader(_nombreArchivo);//lo voy a usar para ir leyendo todo mi archivo.
        using var sw = new StreamWriter("temporal.txt", false);// aca voy a ir escribiendo todo el archivo, con la unica diferencia que concateno 
        while (!sr.EndOfStream)
        {                            // un "*" al evento a borrar(borrado logico).
            List<string> l = new List<string>();// creo una lista para ir guardo los strign que leo y ver si encontre mi id accediendo a l[0].
            for (int i = 0; i < 7; i++)
            {
                l.Add(sr.ReadLine() ?? "");//voy guardando las lineas que leo a la lista de strings.
            }
            if (!l[0].StartsWith("*") && int.Parse(l[0].ToString()) == Id)
            {// verifico si es el id que busco, pero antes verifico que ya no este borrado.
                l[0] = "*" + l[0];// si la condicion es true, hago el borrado logico.
                encontre = true;
            }
            foreach (string e in l)
            {
                sw.WriteLine(e);//voy escribiendo en mi archivo temporal linea por linea.
            }

        }
        if (encontre)
        {
            Console.WriteLine("Se elimino con exito el evento");
            File.Delete(_nombreArchivo);//borro el archivo ya que no me sirve mas.
            File.Move("temporal.txt", _nombreArchivo);//hago el intercambio con el archivo temporal.
        }
        else
        {
            Console.WriteLine("No se encontro el evento a eliminar");
            File.Delete("temporal.txt");//borro el archivo temporal si no lo encontre.
        }
    }
    public void ActualizarEventoDeportivo(EventoDeportivo ed)
    {
        Boolean encontrado = false;
        using var sr = new StreamReader(_nombreArchivo);
        using var sw = new StreamWriter("archivoTemporal.TXT");
        EventoDeportivo temp = new EventoDeportivo();
        while (!sr.EndOfStream)
        {
            temp.Id = int.Parse(sr.ReadLine() ?? "");
            temp.Nombre = sr.ReadLine() ?? "";
            temp.Descripcion = sr.ReadLine() ?? "";
            temp.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? "");
            temp.DuracionHoras = int.Parse(sr.ReadLine() ?? "");
            temp.CupoMaximo = int.Parse(sr.ReadLine() ?? "");
            temp.ResponsableId = int.Parse(sr.ReadLine() ?? "");
            if (temp.Id == ed.Id)
            {
                sw.WriteLine(ed.Id);
                sw.WriteLine(ed.Nombre);
                sw.WriteLine(ed.Descripcion);
                sw.WriteLine(ed.FechaHoraInicio);
                sw.WriteLine(ed.DuracionHoras);
                sw.WriteLine(ed.CupoMaximo);
                sw.WriteLine(temp.ResponsableId);
                encontrado = true;
            }
            else
            {
                sw.WriteLine(temp.Id);
                sw.WriteLine(temp.Nombre);
                sw.WriteLine(temp.Descripcion);
                sw.WriteLine(temp.FechaHoraInicio);
                sw.WriteLine(temp.DuracionHoras);
                sw.WriteLine(temp.CupoMaximo);
                sw.WriteLine(temp.ResponsableId);
            }
        }
        if (!encontrado)
        {
            File.Delete("archivoTemporal.TXT");
            Console.WriteLine("Evento no encontrado");
        }
        else
        {
            File.Delete(_nombreArchivo);
            File.Move("archivoTemporal.TXT", _nombreArchivo);
        }
    }

    public bool ExisteId(int id)
    {
        foreach (EventoDeportivo e in this.ListarEventoDeportivo())
        {
            if (e.Id == id)
            {
                return true;
            }
        }
        return false;
    }
    public int DevolverCupoMaximo(int id)
    {
        foreach (EventoDeportivo e in this.ListarEventoDeportivo())
        {
            if (e.Id == id)
            {
                return e.CupoMaximo;
            }
        }
        return 0;
    }
    public bool Expiro(int id)
    {
        foreach (EventoDeportivo e in this.ListarEventoDeportivo())
        {
            if (e.Id == id)
            {
                return e.FechaHoraInicio < DateTime.Now;
            }
        }
        return false;
    }
}
