// See https://aka.ms/new-console-template for more information
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Agregar;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Eliminar;
using CentroEventos.Aplicacion.Actualizar;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Excepciones;

//agregar Persona
File.WriteAllText("personas.txt", string.Empty);
File.WriteAllText("eventos.txt", string.Empty);
File.WriteAllText("reservas.txt", string.Empty);
// (1) Inicializar repositorios y servicio de autorización
var repoPersona = new RepositorioPersonaTXT();
var repoEventoDeportivo = new RepositorioEventoDeportivoTXT();
var repoReserva = new RepositorioReservaTXT();
var servicioAutorizacion = new ServicioAutorizacionProvisorio();

// (2) Inicializar validadores
var validadorPersona = new PersonaValidador(repoPersona, repoReserva, repoEventoDeportivo);
var validadorEventoDeportivo = new EventoDeportivoValidador(repoEventoDeportivo, repoPersona, repoReserva);
var validadorReserva = new ReservaValidador(repoPersona, repoEventoDeportivo, repoReserva);

//(3) inicializar casos de uso

//create
var AgregarPersona = new AgregarPersonaUseCase(repoPersona, validadorPersona, servicioAutorizacion);
var AgregarReserva = new AgregarReservaUseCase(repoReserva, validadorReserva, servicioAutorizacion);
var AgregarEvento = new AgregarEventoDeportivoUseCase(repoEventoDeportivo,validadorEventoDeportivo,servicioAutorizacion);

//update
var ModificarPersona = new ActualizarPersonaUseCase(repoPersona, validadorPersona, servicioAutorizacion);
var ModificarReserva = new ActualizarReservaUseCase(repoReserva, validadorReserva, servicioAutorizacion);
var ModificarEvento = new ActualizarEventoDeportivoUseCase(repoEventoDeportivo, validadorEventoDeportivo, servicioAutorizacion);

//delete
var EliminarPersona = new EliminarPersonaUseCase(repoPersona,validadorPersona,servicioAutorizacion);
var EliminarReserva = new EliminarReservaUseCase(repoReserva,validadorReserva,servicioAutorizacion);
var EliminarEvento = new EliminarEventoDeportivoUseCase(repoEventoDeportivo, validadorEventoDeportivo, servicioAutorizacion);

//read
var ListarPersona = new ListarPersonaUseCase(repoPersona);
var ListarReserva = new ListarReservaUseCase(repoReserva);
var ListarEvento = new ListarEventoDeportivoUseCase(repoEventoDeportivo);
var ListarEventoConCupoDisponible = new ListarEventoDeportivoConCupoDisponibleUseCase(repoEventoDeportivo,repoReserva);
var ListarAsistencia = new ListarAsistenciaAEventoUseCase(repoReserva, repoPersona, repoEventoDeportivo);
////PRUEBO EL AGREGAR PERSONA, FUNCIONA DE FORMA CORRECTA.(no validamos los telefonos, o los dni invalidos)
try
{
    AgregarPersona.Ejecutar(1, new Persona
    {
        DNI = "12345678",
        Nombre = "Juan",
        Apellido = "Pérez",
        Email = "juan@example.com",
        Telefono = "555-1234"
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (ValidacionException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex){Console.WriteLine(ex.Message);}
try
{
    AgregarPersona.Ejecutar(1, new Persona
    {
        DNI = "12345678",
        Nombre = "Valen",
        Apellido = "Fernandez",
        Email = "Valem@example.com",
        Telefono = "666-1234"
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (ValidacionException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex){Console.WriteLine(ex.Message);}
try
{
    AgregarPersona.Ejecutar(1, new Persona
    {
        DNI      = "48765432",
        Nombre   = "María",
        Apellido = "Gómez",
        Email    = "maria.gomez@example.com",
        Telefono = "555‑4321"
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException       ex) { Console.WriteLine(ex.Message); }
catch (DuplicadoException        ex) { Console.WriteLine(ex.Message); }

try
{
    AgregarPersona.Ejecutar(1, new Persona
    {
        DNI      = "24680135",
        Nombre   = "Carlos",
        Apellido = "López",
        Email    = "carlos.lopez@example.com",
        Telefono = "555‑2468"
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException       ex) { Console.WriteLine(ex.Message); }
catch (DuplicadoException        ex) { Console.WriteLine(ex.Message); }

//(email duplicado  para probar DuplicadoException)
try
{
    AgregarPersona.Ejecutar(1, new Persona
    {
        DNI      = "13579246",
        Nombre   = "Ana",
        Apellido = "Martínez",
        Email    = "maria.gomez@example.com",   // mismo email que María
        Telefono = "555‑1357"
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException       ex) { Console.WriteLine(ex.Message); }
catch (DuplicadoException        ex) { Console.WriteLine(ex.Message); }
try
{
    AgregarPersona.Ejecutar(1, new Persona
    {
        DNI = "12",        // DNI demasiado corto
        Nombre = "Diego",
        Apellido = "Sosa",
        Email = "diego.sosa@example.com",
        Telefono = "555‑9876"
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException       ex) { Console.WriteLine(ex.Message); }
catch (DuplicadoException        ex) { Console.WriteLine(ex.Message); }
try
{
    AgregarPersona.Ejecutar(1, new Persona
    {
        DNI      = "6745135",
        Nombre   = "Mayra",
        Apellido = "Mitma",
        Email    = "mitma.TeQuieroMejorAmiga@example.com",
        Telefono = "555‑2468"
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException       ex) { Console.WriteLine(ex.Message); }
catch (DuplicadoException        ex) { Console.WriteLine(ex.Message); }

try
{
    AgregarPersona.Ejecutar(1, new Persona
    {
        DNI      = "13579246",
        Nombre   = "Matias",
        Apellido = "Martínez",
        Email    = "mati.gomez@example.com",   
        Telefono = "555‑1357"
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException       ex) { Console.WriteLine(ex.Message); }
catch (DuplicadoException        ex) { Console.WriteLine(ex.Message); }

try
{
    AgregarPersona.Ejecutar(1, new Persona
    {
        DNI = "543543",
        Nombre = "German",
        Apellido = "Sosa",
        Email = "German.sosa@example.com",
        Telefono = "884‑9876"
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }
catch (DuplicadoException ex) { Console.WriteLine(ex.Message); }


//PRUEBO EL LISTAR DE PERSONA, FUNCIONA DE FORMA CORRECTA.
Console.WriteLine();Console.WriteLine();
Console.WriteLine("---------------LISTA DE LAS PERSONAS AGREGADAS--------------");
foreach (Persona p in ListarPersona.Ejecutar())
{
    Console.WriteLine(p.ToString());
}


//ELIMINAR PERSONA FUNCIONA DE FORMA CORRECTA.
//FALTA PROBAR QUE LA PERSONA A ELIMINAR NO TENGAS RESERVAS NI SEA RESPONSABLE DE UN EVENTO.
try
{
    EliminarPersona.Ejecutar(1, 1);
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
catch (OperacionInvalidaException ex) { Console.WriteLine(ex.Message); }


//PRUEBO EL LISTAR DE PERSONA, FUNCIONA DE FORMA CORRECTA.
Console.WriteLine();Console.WriteLine();
Console.WriteLine("---------------LISTA DE LAS PERSONAS DESPUES DE ELIMINAR--------------");
foreach (Persona p in ListarPersona.Ejecutar())
{
    Console.WriteLine(p.ToString());
}
// actualizar Persona

try
{
    ModificarPersona.Ejecutar(1, new Persona
    {
        Id=4,// a la hora de actualizar tengo que agregar si o si el id.
        DNI = "12344332",        
        Nombre = "Diego",
        Apellido = "Sosa",
        Email = "diego.sosa@example.com",
        Telefono = "666-432"
    });
}
catch (FalloAutorizacionException ex) {Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex) {Console.WriteLine(ex.Message);}
//PRUEBO EL LISTAR DE PERSONA, FUNCIONA DE FORMA CORRECTA.
Console.WriteLine();Console.WriteLine();
Console.WriteLine("---------------LISTA DE LAS PERSONAS DESPUES DE ACTUALIZAR--------------");
foreach (Persona p in ListarPersona.Ejecutar())
{
    Console.WriteLine(p.ToString());
}




//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



//agregar Evento

try
{
    AgregarEvento.Ejecutar(1, new EventoDeportivo
    {
        Nombre = "Evento de informartica",
        Descripcion = "Este evento es uno de los mejores 3 en el country",
        FechaHoraInicio = DateTime.Now,
        DuracionHoras = 2,
        CupoMaximo = 200,
        ResponsableId = 2
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
try
{
    AgregarEvento.Ejecutar(1, new EventoDeportivo
    {
        Nombre = "Evento de Medicina",
        Descripcion = "Este evento es el favorito de todos",
        FechaHoraInicio = DateTime.Now,
        DuracionHoras = 3,
        CupoMaximo = 150,
        ResponsableId = 6
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
try
{
    AgregarEvento.Ejecutar(1, new EventoDeportivo
    {
        Nombre = "Evento de Economia",
        Descripcion = "Este evento tiene mala reputacion",
        FechaHoraInicio = DateTime.Now,
        DuracionHoras = 4,
        CupoMaximo = 300,
        ResponsableId = 3
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
try
{
    AgregarEvento.Ejecutar(1, new EventoDeportivo
    {
        Nombre = "Evento de Artes",
        Descripcion = "Este evento esta lleno de vagos",
        FechaHoraInicio = DateTime.Now,//si  ponga una fecha superior me tira error
        DuracionHoras = 1,
        CupoMaximo = 20,
        ResponsableId = 4
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }

Console.WriteLine();Console.WriteLine();
Console.WriteLine("------------LISTA DE EVENTOS--------------");
foreach (EventoDeportivo e in ListarEvento.Ejecutar())
{
    Console.WriteLine(e.ToString());
}

// actulizar Evento

try
{
    ModificarEvento.Ejecutar(1, new EventoDeportivo
    {
        Id=3,
        Nombre = "Evento de Economia",
        Descripcion = "Este evento tiene mala reputacion",
        FechaHoraInicio = DateTime.Now.AddHours(3),// me dice que los eventos ya ocurrieon pero no me deja definirlas fechas que no sean .now
        DuracionHoras = 1,
        CupoMaximo = 500,
        ResponsableId = 4
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
catch (OperacionInvalidaException ex) { Console.WriteLine(ex.Message); }
Console.WriteLine();Console.WriteLine();
Console.WriteLine("------------LISTA DE EVENTOS DESPUES DE ACTUALIZAR--------------");
foreach (EventoDeportivo e in ListarEvento.Ejecutar())
{
    Console.WriteLine(e.ToString());
}
//Eliminar evento
try
{
    EliminarEvento.Ejecutar(1, 2);
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
catch (OperacionInvalidaException ex) { Console.WriteLine(ex.Message); }
Console.WriteLine();Console.WriteLine();
Console.WriteLine("------------LISTA DE EVENTOS DESPUES DE ELIMINAR--------------");
foreach (EventoDeportivo e in ListarEvento.Ejecutar())
{
    Console.WriteLine(e.ToString());
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




//agregar Reserva
try
{
    AgregarReserva.Ejecutar(1, new Reserva
    {
        PersonaId = 3,
        EventoDeportivoId = 2,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = Reserva.Asistencia.Pendiente
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
catch (DuplicadoException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }
try
{
    AgregarReserva.Ejecutar(1, new Reserva
    {
        PersonaId = 2,
        EventoDeportivoId = 1,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = Reserva.Asistencia.Presente
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
catch (DuplicadoException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }
try
{
    AgregarReserva.Ejecutar(1, new Reserva
    {
        PersonaId = 4,
        EventoDeportivoId = 4,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia = Reserva.Asistencia.Pendiente
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
catch (DuplicadoException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }
try
{
    AgregarReserva.Ejecutar(1, new Reserva
    {
        PersonaId = 2,
        EventoDeportivoId = 3,
        FechaAltaReserva = DateTime.Now,
        EstadoAsistencia= Reserva.Asistencia.Ausente
    });
}
catch (FalloAutorizacionException ex){Console.WriteLine(ex.Message);}
catch (EntidadNotFoundException ex){Console.WriteLine(ex.Message);}
catch (DuplicadoException ex) { Console.WriteLine(ex.Message); }
catch (ValidacionException ex) { Console.WriteLine(ex.Message); }
Console.WriteLine();Console.WriteLine();
Console.WriteLine("------------LISTA DE RESERVAS--------------");
foreach (Reserva r in ListarReserva.Ejecutar())
{
    Console.WriteLine(r.ToString());
}


// actulizar Reserva

try
{
    ModificarReserva.Ejecutar(1, new Reserva
    {
        Id = 3,
        PersonaId = 3,
        EventoDeportivoId = 1,
        FechaAltaReserva=DateTime.Now,//LA HORA SE MODIFICA? CONSULTAR
        EstadoAsistencia =Reserva.Asistencia.Presente
    });
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
Console.WriteLine();Console.WriteLine();
Console.WriteLine("------------LISTA DE RESERVAS DESPUES DE ACTUALIZAR--------------");
foreach (Reserva r in ListarReserva.Ejecutar())
{
    Console.WriteLine(r.ToString());
}
// eliminar Reserva

try
{
    EliminarReserva.Ejecutar(1,2);
}
catch (FalloAutorizacionException ex) { Console.WriteLine(ex.Message); }
catch (EntidadNotFoundException ex) { Console.WriteLine(ex.Message); }
Console.WriteLine();Console.WriteLine();
Console.WriteLine("------------LISTA DE RESERVAS DESPUES DE ELIMINAR--------------");
foreach (Reserva r in ListarReserva.Ejecutar())
{
    Console.WriteLine(r.ToString());
}
Console.WriteLine();Console.WriteLine();
Console.WriteLine("------------LISTA DE EVENTOS CON CUPOS DISPONIBLES--------------");
foreach (EventoDeportivo r in ListarEventoConCupoDisponible.Ejecutar())
{
    Console.WriteLine(r.ToString());
}
Console.WriteLine();Console.WriteLine();
Console.WriteLine("------------LISTA DE ASISTENCIAS--------------");
foreach (Persona r in ListarAsistencia.Ejecutar())
{
    Console.WriteLine(r.ToString());
}

/*


//listar no se si tiene try and catch

listarPersona.Ejecutar();
listarReserva.Ejecutar();
listarEvento.Ejecutar();
listarAsistencia.Ejecutar();
listarEventoConCupoDisponible.Ejecutar();

*/