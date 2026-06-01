using System;

// ==================================================
// PROYECTO CONSULTORIO MÉDICO
// BASE GENERAL PARA TRABAJAR EN EQUIPO
// ==================================================

// IMPORTANTE:
// No cambiar los nombres de estas variables.
// Todos los integrantes deben trabajar usando estos mismos nombres.

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

bool salir = false;

// ==================================================
// MENÚ PRINCIPAL
// ==================================================

while (!salir)
{
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
        case 1:
            ver_doctores();
            break;

        case 2:
            agendar_cita();
            break;

        case 3:
            ver_mis_citas();
            break;

        case 4:
            menu_gestion_citas();
            break;

        case 5:
            salir = true;
            despedida();
            break;
    }
}

// ==================================================
// FUNCIONES COMUNES
// TODOS PUEDEN USAR ESTAS FUNCIONES
// ==================================================

void limpiar_pantalla()
{
    Console.Clear();
}

void mostrar_encabezado(string titulo)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("==================================================");
    Console.WriteLine($"        {titulo}");
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

        if (int.TryParse(entrada, out numero))
        {
            if (numero >= minimo && numero <= maximo)
            {
                return numero;
            }
        }

        escribir_color($"Error. Ingrese un número entre {minimo} y {maximo}.", ConsoleColor.Red);
    }
}

string leer_texto(string mensaje)
{
    string texto;

    while (true)
    {
        Console.Write(mensaje);
        texto = Console.ReadLine()!;

        if (texto != "")
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
        Console.Write($"{mensaje} (s/n): ");
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

// ==================================================
// INTEGRANTE 1
// OPCIÓN 1: VER DOCTORES DISPONIBLES
// ==================================================

void ver_doctores()
{
    limpiar_pantalla();
    mostrar_encabezado("DOCTORES DISPONIBLES");

    /*
     INTEGRANTE 1:

     Esta parte debe mostrar la información de los doctores.

     Debe mostrar:
     - Número del doctor.
     - Nombre del doctor.
     - Especialidad.
     - Perfil breve.
     - Horarios numerados.
     - Si cada horario está disponible u ocupado.

     Debe usar:
     - doctores
     - horarios
     - horarios_ocupados
     - mostrar_horarios_doctor()
    */

    escribir_color("Módulo pendiente: Ver doctores disponibles.", ConsoleColor.Yellow);
    Console.WriteLine();

    Console.WriteLine("Ejemplo de cómo debería verse:");
    Console.WriteLine();

    Console.WriteLine("1. Dra. Valeria Rivas");
    Console.WriteLine("   Especialidad: Medicina General");
    Console.WriteLine("   Perfil: Atiende consultas generales, chequeos médicos y seguimiento de pacientes.");
    Console.WriteLine("   Horarios:");
    Console.WriteLine("   1. 08:00 AM | Disponible");
    Console.WriteLine("   2. 09:00 AM | Ocupado");
    Console.WriteLine("   3. 10:00 AM | Disponible");
    Console.WriteLine();

    pausar();
}

void mostrar_lista_doctores()
{
    /*
     INTEGRANTE 1:

     Esta función debe mostrar una lista corta de doctores.
     Se usará cuando la secretaria vaya a agendar una cita.

     Ejemplo:
     1. Dra. Valeria Rivas - Medicina General
     2. Dr. Carlos Mendoza - Pediatría
     3. Dra. Sofía Martínez - Cardiología
    */

    for (int i = 0; i < doctores.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {doctores[i].nombre} - {doctores[i].especialidad}");
    }

    Console.WriteLine();
}

void mostrar_horarios_doctor(int doctor_index)
{
    /*
     INTEGRANTE 1:

     Esta función debe mostrar los horarios del doctor seleccionado.
     Los horarios deben salir numerados.
     Debe mostrar si están disponibles u ocupados.

     Debe usar:
     - horarios
     - horarios_ocupados
     - horarios.GetLength(1)
    */

    Console.WriteLine("   Horarios:");

    for (int j = 0; j < horarios.GetLength(1); j++)
    {
        Console.Write($"   {j + 1}. {horarios[doctor_index, j]} | ");

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

// ==================================================
// INTEGRANTE 2
// OPCIÓN 2: AGENDAR CITA
// ==================================================

void agendar_cita()
{
    limpiar_pantalla();
    mostrar_encabezado("AGENDAR NUEVA CITA");

    /*
     INTEGRANTE 2:

     Esta parte debe permitir registrar una nueva cita.

     Flujo esperado:
     1. Pedir nombre del paciente.
     2. Pedir cédula o identificación.
     3. Mostrar lista de doctores.
     4. Permitir seleccionar un doctor.
     5. Mostrar perfil del doctor seleccionado.
     6. Mostrar horarios del doctor seleccionado.
     7. Seleccionar un horario disponible.
     8. Confirmar la cita.
     9. Guardar la cita en el arreglo citas.
     10. Aumentar cantidad_citas.
     11. Marcar el horario como ocupado.

     Debe usar:
     - citas
     - cantidad_citas
     - doctores
     - horarios
     - horarios_ocupados
     - max_citas
     - leer_texto()
     - leer_entero()
     - confirmar()
     - mostrar_lista_doctores()
     - mostrar_horarios_doctor()
     - seleccionar_horario_disponible()
     - doctor_tiene_horarios_disponibles()
    */

    escribir_color("Módulo pendiente: Agendar cita.", ConsoleColor.Yellow);
    Console.WriteLine();

    Console.WriteLine("Ejemplo de cómo debería verse:");
    Console.WriteLine();

    Console.WriteLine("Nombre del paciente: Juan Pérez");
    Console.WriteLine("Cédula o identificación: 001-000000-0000X");
    Console.WriteLine();
    Console.WriteLine("Seleccione el doctor:");
    Console.WriteLine("1. Dra. Valeria Rivas - Medicina General");
    Console.WriteLine("2. Dr. Carlos Mendoza - Pediatría");
    Console.WriteLine("3. Dra. Sofía Martínez - Cardiología");
    Console.WriteLine();
    Console.WriteLine("Seleccione el número del horario: 2");
    Console.WriteLine();
    Console.WriteLine("¿Desea confirmar la cita? (s/n): s");
    Console.WriteLine();
    Console.WriteLine("La cita fue agendada correctamente.");

    pausar();
}

bool doctor_tiene_horarios_disponibles(int doctor_index)
{
    /*
     INTEGRANTE 2:

     Esta función revisa si un doctor tiene al menos un horario disponible.

     Si encuentra un horario disponible, retorna true.
     Si todos están ocupados, retorna false.
    */

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
    /*
     INTEGRANTE 2:

     Esta función debe permitir seleccionar un horario.
     No debe aceptar horarios ocupados.
     Debe retornar la posición del horario seleccionado.
    */

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
// INTEGRANTE 3
// OPCIÓN 3: VER MIS CITAS
// ==================================================

void ver_mis_citas()
{
    limpiar_pantalla();
    mostrar_encabezado("VER MIS CITAS");

    /*
     INTEGRANTE 3:

     Esta parte debe permitir consultar las citas registradas.

     Debe permitir:
     1. Buscar cita por cédula.
     2. Mostrar todas las citas.
     3. Indicar si no hay citas registradas.
     4. Indicar si no se encontró una cita.
     5. Mostrar si la cita está Confirmada o Cancelada.

     Debe usar:
     - citas
     - cantidad_citas
     - leer_texto()
     - leer_entero()
     - mostrar_cita()
    */

    escribir_color("Módulo pendiente: Ver mis citas.", ConsoleColor.Yellow);
    Console.WriteLine();

    Console.WriteLine("Ejemplo de cómo debería verse:");
    Console.WriteLine();

    Console.WriteLine("1. Buscar por cédula");
    Console.WriteLine("2. Mostrar todas las citas");
    Console.WriteLine();
    Console.WriteLine("Paciente: Juan Pérez");
    Console.WriteLine("Cédula: 001-000000-0000X");
    Console.WriteLine("Doctor: Dra. Valeria Rivas");
    Console.WriteLine("Especialidad: Medicina General");
    Console.WriteLine("Horario: 09:00 AM");
    Console.WriteLine("Estado: Confirmada");

    pausar();
}

void mostrar_cita(int indice)
{
    /*
     INTEGRANTE 3:

     Esta función debe mostrar la información completa de una cita.

     Debe mostrar:
     - Número de cita.
     - Paciente.
     - Cédula.
     - Doctor.
     - Especialidad.
     - Horario.
     - Estado.
    */

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Cita #{indice + 1}");
    Console.ResetColor();

    Console.WriteLine($"Paciente: {citas[indice].paciente}");
    Console.WriteLine($"Cédula: {citas[indice].cedula}");
    Console.WriteLine($"Doctor: {citas[indice].doctor}");
    Console.WriteLine($"Especialidad: {citas[indice].especialidad}");
    Console.WriteLine($"Horario: {citas[indice].horario}");

    if (citas[indice].estado == "Confirmada")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Estado: {citas[indice].estado}");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Estado: {citas[indice].estado}");
        Console.ResetColor();
    }

    Console.WriteLine("--------------------------------------------------");
}

// ==================================================
// INTEGRANTE 4
// OPCIÓN 4: GESTIÓN DE CITAS Y SALIDA
// ==================================================

void menu_gestion_citas()
{
    limpiar_pantalla();
    mostrar_encabezado("GESTIÓN DE CITAS");

    /*
     INTEGRANTE 4:

     Esta parte debe crear un segundo menú.

     El menú debe tener:
     1. Cancelar cita.
     2. Agendar otra cita.
     3. Reporte de citas del día.
     4. Volver al menú principal.

     Debe usar:
     - cancelar_cita()
     - agendar_cita()
     - reporte_citas()
    */

    escribir_color("Módulo pendiente: Gestión de citas.", ConsoleColor.Yellow);
    Console.WriteLine();

    Console.WriteLine("Ejemplo de cómo debería verse:");
    Console.WriteLine();

    Console.WriteLine("1. Cancelar cita");
    Console.WriteLine("2. Agendar otra cita");
    Console.WriteLine("3. Reporte de citas del día");
    Console.WriteLine("4. Volver al menú principal");

    pausar();
}

void cancelar_cita()
{
    /*
     INTEGRANTE 4:

     Esta función debe cancelar una cita existente.

     Debe hacer:
     1. Mostrar solo las citas confirmadas.
     2. Permitir seleccionar cuál cita cancelar.
     3. Confirmar la cancelación.
     4. Cambiar el estado de la cita a Cancelada.
     5. Liberar el horario ocupado usando horarios_ocupados.
     6. Llamar a guardar_datos().

     Debe usar:
     - citas
     - cantidad_citas
     - horarios_ocupados
     - mostrar_cita()
     - confirmar()
     - guardar_datos()
    */

    limpiar_pantalla();
    mostrar_encabezado("CANCELAR CITA");

    escribir_color("Módulo pendiente: Cancelar cita.", ConsoleColor.Yellow);

    pausar();
}

void reporte_citas()
{
    /*
     INTEGRANTE 4:

     Esta función debe mostrar el reporte de citas del día.

     Debe mostrar:
     - Total de citas registradas.
     - Total de citas confirmadas.
     - Total de citas canceladas.
     - Citas confirmadas por doctor.
     - Detalle de citas.

     Debe usar:
     - citas
     - cantidad_citas
     - doctores
     - mostrar_cita()
     - guardar_datos()
    */

    limpiar_pantalla();
    mostrar_encabezado("REPORTE DE CITAS DEL DÍA");

    escribir_color("Módulo pendiente: Reporte de citas.", ConsoleColor.Yellow);
    Console.WriteLine();

    Console.WriteLine("Ejemplo de cómo debería verse:");
    Console.WriteLine();

    Console.WriteLine("Total de citas registradas: 5");
    Console.WriteLine("Citas confirmadas: 4");
    Console.WriteLine("Citas canceladas: 1");
    Console.WriteLine();
    Console.WriteLine("Citas confirmadas por doctor:");
    Console.WriteLine("Dra. Valeria Rivas: 2 cita(s)");
    Console.WriteLine("Dr. Carlos Mendoza: 1 cita(s)");
    Console.WriteLine("Dra. Sofía Martínez: 1 cita(s)");

    pausar();
}

void guardar_datos()
{
    /*
     INTEGRANTE 4:

     Esta función representa el guardado de datos.

     En esta versión base NO se guarda en archivo,
     porque no se está usando System.IO.

     Los datos quedan guardados temporalmente en:
     - arreglo citas
     - matriz horarios_ocupados

     Mientras el programa esté abierto, los datos se mantienen.
     Si se cierra el programa, se reinician.
    */

    escribir_color("Datos guardados temporalmente en el sistema.", ConsoleColor.Green);
}

void despedida()
{
    /*
     INTEGRANTE 4:

     Esta función muestra el mensaje final cuando el usuario decide salir.
    */

    limpiar_pantalla();
    mostrar_encabezado("GRACIAS POR USAR EL SISTEMA");

    escribir_color("Sistema finalizado correctamente.", ConsoleColor.Green);
    Console.WriteLine();
    Console.WriteLine("Consultorio Médico - Proyecto en C#");
    Console.WriteLine();

    pausar();
}

// ==================================================
// STRUCTS DEL PROYECTO
// NO CAMBIAR LOS NOMBRES DE LOS CAMPOS
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