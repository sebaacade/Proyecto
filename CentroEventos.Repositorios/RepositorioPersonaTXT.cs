using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioPersonaTXT : IRepositorioPersona
{
     readonly string _nombreArch = "personas.txt";
    readonly string _archivoIds = "IDs.txt";
    private int _idUltimo;
    public RepositorioPersonaTXT(){
        using var sr =new  StreamReader(_archivoIds);
        _idUltimo = int.Parse(sr.ReadToEnd());
    }
    public List<Persona> ListarPersona(){
        var resultado=new List<Persona>();
        using var sr=new StreamReader(_nombreArch);
        while(!sr.EndOfStream){
            var p=new Persona();
            p.Id=int.Parse(sr.ReadLine()??"");
            p.DNI=sr.ReadLine()??"";
            p.Nombre=sr.ReadLine()??"";
            p.Apellido=sr.ReadLine()??"";
            p.Email=sr.ReadLine()??"";
            p.Telefono=sr.ReadLine()??"";
            resultado.Add(p);
        }
        return resultado;
    }
    public void AgregarPersona(Persona persona)
    {   
        using var sw2 = new StreamWriter(_archivoIds, false);
        _idUltimo++;
        persona.Id = _idUltimo;

        using var sw = new StreamWriter(_nombreArch, true);

        // Crear una lista de los campos comunes
        List<string?> campos = new List<string?>
        {
            persona.Id.ToString(),
            persona.DNI,
            persona.Nombre + ' ' + persona.Apellido,
            persona.Telefono,
            persona.Email
        };
         // Escribir la línea al archivo, separada por palito
        sw.WriteLine(string.Join('|', campos));
        sw2.WriteLine(_idUltimo);
    }
    public void EliminarPersona(int id){
         // Leer todas las líneas
        List<string> lineas = File.ReadAllLines(_nombreArch).ToList();

        // Buscar y eliminar la línea cuyo ID coincida
        var nuevasLineas = lineas
            .Where(linea => !linea.StartsWith(id.ToString() + '|'))
            .ToList();

        // Sobrescribir el archivo con las nuevas líneas
        File.WriteAllLines(_nombreArch, nuevasLineas);
    }
    /*public void ActualizarPersona(Persona persona){
        List<Persona> lista = new List<Persona>();
        lista = ListarPersona();
        int i = 0;

        while(i < lista.Count && persona.Id != lista[i].Id){// solo < restricto ya que si no accede a una posicion invalida.
            i++;
        }

        if (persona.Id == lista[i].Id){
            lista[i] = persona;
        }

        // Sobrescribir el archivo con las nuevas líneas
        File.WriteAllLines(_nombreArch, lista);// cambia un text con una lista(?
    }*/
    public void ActualizarPersona(Persona ed){
        Boolean encontrado = false;
        using var sr =  new StreamReader(_nombreArch);
        using var sw = new StreamWriter ("archivoTemporal.TXT");
        var temp = new Persona();
        while (!sr.EndOfStream){
            temp.Id = int.Parse(sr.ReadLine()??"");
            temp.Nombre = sr.ReadLine()??"";
            temp.Apellido = sr.ReadLine()??"";
            temp.Email = sr.ReadLine()??"";
            temp.Telefono= sr.ReadLine()??"";
            if (temp.Id ==ed.Id){
                sw.WriteLine(ed.Id);
                sw.WriteLine(ed.Nombre);
                sw.WriteLine(ed.Apellido);
                sw.WriteLine(ed.Email);
                sw.WriteLine(ed.Telefono);
                encontrado = true;
            }
            else{
                sw.WriteLine(temp.Id);
                sw.WriteLine(temp.Nombre);
                sw.WriteLine(temp.Apellido);
                sw.WriteLine(temp.Email);
                sw.WriteLine(temp.Telefono);
            }
        }
        if (!encontrado ){
            File.Delete("archivoTemporal.TXT");
            Console.WriteLine("Evento no encontrado");
        }
        else{
            File.Delete (_nombreArch);
            File.Move("archivoTemporal.TXT", _nombreArch);// es valido el modificar?
        }
     }

    public bool ExisteId(int id){
        foreach(Persona p in this.ListarPersona()){
            if(p.Id == id){
                return true;
            }
        }
        return false;
    }
    public bool ExisteDNI(string dni){
        foreach(Persona p in this.ListarPersona()){
            if(p.DNI == dni){
                return true;
            }
        }
        return false;
    }
    public bool ExisteEmail(string email){
        foreach(Persona p in this.ListarPersona()){
            if(p.Email == email){
                return true;
            }
        }
        return false;
    }
}
