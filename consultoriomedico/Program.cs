using System;

// OPCIÓN 2: AGENDAR CITA

Doctor[] doctores =
{
    new Doctor
    {
        nombre = "Dra. Valeria Rivas",
        especialidad = "Medicina General",
        perfil = "Atiende consultas generales, chequeos médicos y seguimiento de pacientes."
    },
    new Doctor
    {
        nombre = "Dr. Carlos Mendoza",
        especialidad = "Pediatría",
        perfil = "Especialista en atención médica para niños y adolescentes."
    },
    new Doctor
    {
        nombre = "Dra. Sofía Martínez",
        especialidad = "Cardiología",
        perfil = "Especialista en control de presión, corazón y prevención cardiovascular."
    }
};

string[,] horarios =
{
    { "08:00 AM", "09:00 AM", "10:00 AM", "11:00 AM", "01:00 PM" },
    { "08:30 AM", "09:30 AM", "10:30 AM", "02:00 PM", "03:00 PM" },
    { "07:00 AM", "08:00 AM", "09:00 AM", "01:30 PM", "04:00 PM" }
};

bool[,] horarios_ocupados = new bool[doctores.Length, horarios.GetLength(1)];

const int max_citas = 100;
Cita[] citas = new Cita[max_citas];
int cantidad_citas = 0;

// MENÚ PRINCIPAL DE PRUEBA
// Solo funciona la opción 2: Agendar cita.

limpiar_pantalla();
mostrar_encabezado("SISTEMA DE CONSULTORIO MÉDICO");

Console.WriteLine("1. Ver doctores disponibles");
Console.WriteLine("2. Agendar cita");
Console.WriteLine("3. Ver mis citas");
Console.WriteLine("4. Gestión de citas");
Console.WriteLine("5. Salir");
Console.WriteLine();

int opcion = leer_entero("Seleccione una opción: ", 1, 5);

switch (opcion)
{
    case 2:
        agendar_cita();
        break;

    default:
        limpiar_pantalla();
        mostrar_encabezado("MÓDULO NO DISPONIBLE");
        escribir_color("Esta prueba individual solo contiene la opción 2: Agendar cita.", ConsoleColor.Yellow);
        pausar();
        break;
}

// FUNCIONES DE APOYO NECESARIAS PARA PROBAR

void limpiar_pantalla()
{
    Console.Clear();
}

void mostrar_encabezado(string titulo)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("==================================================");
    Console.WriteLine("        " + titulo);
    Console.WriteLine("==================================================");
    Console.ResetColor();
    Console.WriteLine();
}

void escribir_color(string mensaje, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(mensaje);
    Console.ResetColor();
}

void pausar()
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("Presione cualquier tecla para continuar...");
    Console.ResetColor();
    Console.ReadKey();
}

int leer_entero(string mensaje, int minimo, int maximo)
{
    int numero;
    string entrada;

    while (true)
    {
        Console.Write(mensaje);
        entrada = Console.ReadLine()!;

        if (entrada != null && int.TryParse(entrada, out numero))
        {
            if (numero >= minimo && numero <= maximo)
            {
                return numero;
            }
        }

        escribir_color("Error. Ingrese un número entre " + minimo + " y " + maximo + ".", ConsoleColor.Red);
    }
}

string leer_texto(string mensaje)
{
    string texto;

    while (true)
    {
        Console.Write(mensaje);
        texto = Console.ReadLine()!;

        if (texto != null && texto != "")
        {
            return texto;
        }

        escribir_color("Error. No puede dejar este dato vacío.", ConsoleColor.Red);
    }
}

bool confirmar(string mensaje)
{
    string respuesta;

    while (true)
    {
        Console.Write(mensaje + " (s/n): ");
        respuesta = Console.ReadLine()!;

        if (respuesta == "s" || respuesta == "S")
        {
            return true;
        }
        else if (respuesta == "n" || respuesta == "N")
        {
            return false;
        }

        escribir_color("Error. Debe responder con s o n.", ConsoleColor.Red);
    }
}

void mostrar_lista_doctores()
{
    for (int i = 0; i < doctores.Length; i++)
    {
        Console.WriteLine((i + 1) + ". " + doctores[i].nombre + " - " + doctores[i].especialidad);
    }

    Console.WriteLine();
}

void mostrar_horarios_doctor(int doctor_index)
{
    Console.WriteLine("Horarios del doctor:");

    for (int j = 0; j < horarios.GetLength(1); j++)
    {
        Console.Write((j + 1) + ". " + horarios[doctor_index, j] + " | ");

        if (horarios_ocupados[doctor_index, j])
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ocupado");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Disponible");
            Console.ResetColor();
        }
    }

    Console.WriteLine();
}

void guardar_datos()
{
    // En esta prueba individual no se guarda en archivo.
    // Solo representa que la cita quedó guardada temporalmente en el arreglo citas.
    escribir_color("Datos guardados temporalmente en el sistema.", ConsoleColor.Green);
}

// Esta es la parte que se anexará en develop

void agendar_cita()
{
    if (cantidad_citas >= max_citas)
    {
        limpiar_pantalla();
        mostrar_encabezado("AGENDAR CITA");

        escribir_color("No se pueden registrar más citas. El sistema está lleno.", ConsoleColor.Red);

        pausar();
        return;
    }

    limpiar_pantalla();
    mostrar_encabezado("AGENDAR NUEVA CITA");

    string paciente = leer_texto("Nombre del paciente: ");
    string cedula = leer_texto("Cédula o identificación: ");

    limpiar_pantalla();
    mostrar_encabezado("SELECCIÓN DE DOCTOR");

    mostrar_lista_doctores();

    int doctor_index = leer_entero("Seleccione el doctor: ", 1, doctores.Length) - 1;

    limpiar_pantalla();
    mostrar_encabezado("PERFIL DEL DOCTOR");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(doctores[doctor_index].nombre);
    Console.ResetColor();

    Console.WriteLine("Especialidad: " + doctores[doctor_index].especialidad);
    Console.WriteLine("Perfil: " + doctores[doctor_index].perfil);
    Console.WriteLine();

    if (doctor_tiene_horarios_disponibles(doctor_index) == false)
    {
        escribir_color("Este doctor no tiene horarios disponibles.", ConsoleColor.Red);
        pausar();
        return;
    }

    mostrar_horarios_doctor(doctor_index);

    int horario_index = seleccionar_horario_disponible(doctor_index);

    limpiar_pantalla();
    mostrar_encabezado("CONFIRMAR CITA");

    Console.WriteLine("Paciente: " + paciente);
    Console.WriteLine("Cédula: " + cedula);
    Console.WriteLine("Doctor: " + doctores[doctor_index].nombre);
    Console.WriteLine("Especialidad: " + doctores[doctor_index].especialidad);
    Console.WriteLine("Horario: " + horarios[doctor_index, horario_index]);
    Console.WriteLine("Estado: Confirmada");
    Console.WriteLine();

    if (confirmar("¿Desea confirmar la cita?"))
    {
        citas[cantidad_citas].paciente = paciente;
        citas[cantidad_citas].cedula = cedula;
        citas[cantidad_citas].doctor = doctores[doctor_index].nombre;
        citas[cantidad_citas].especialidad = doctores[doctor_index].especialidad;
        citas[cantidad_citas].horario = horarios[doctor_index, horario_index];
        citas[cantidad_citas].estado = "Confirmada";
        citas[cantidad_citas].doctor_index = doctor_index;
        citas[cantidad_citas].horario_index = horario_index;

        horarios_ocupados[doctor_index, horario_index] = true;
        cantidad_citas++;

        guardar_datos();

        limpiar_pantalla();
        mostrar_encabezado("CITA CONFIRMADA");

        escribir_color("La cita fue agendada correctamente.", ConsoleColor.Green);
        Console.WriteLine();

        Console.WriteLine("Resumen final:");
        Console.WriteLine("Paciente: " + paciente);
        Console.WriteLine("Cédula: " + cedula);
        Console.WriteLine("Doctor: " + doctores[doctor_index].nombre);
        Console.WriteLine("Especialidad: " + doctores[doctor_index].especialidad);
        Console.WriteLine("Horario: " + horarios[doctor_index, horario_index]);
        Console.WriteLine("Estado: Confirmada");
    }
    else
    {
        limpiar_pantalla();
        mostrar_encabezado("CITA NO CONFIRMADA");

        escribir_color("La cita no fue registrada.", ConsoleColor.Yellow);
    }

    pausar();
}

bool doctor_tiene_horarios_disponibles(int doctor_index)
{
    for (int i = 0; i < horarios.GetLength(1); i++)
    {
        if (horarios_ocupados[doctor_index, i] == false)
        {
            return true;
        }
    }

    return false;
}

int seleccionar_horario_disponible(int doctor_index)
{
    int opcion;

    while (true)
    {
        opcion = leer_entero("Seleccione el número del horario: ", 1, horarios.GetLength(1)) - 1;

        if (horarios_ocupados[doctor_index, opcion] == false)
        {
            return opcion;
        }

        escribir_color("Ese horario ya está ocupado. Seleccione otro horario disponible.", ConsoleColor.Red);
    }
}

// ==================================================
// STRUCTS NECESARIOS PARA PROBAR
// En develop ya estarán definidos en la base común.
// ==================================================

struct Doctor
{
    public string nombre;
    public string especialidad;
    public string perfil;
}

struct Cita
{
    public string paciente;
    public string cedula;
    public string doctor;
    public string especialidad;
    public string horario;
    public string estado;
    public int doctor_index;
    public int horario_index;
}