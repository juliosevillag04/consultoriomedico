# PROYECTO CONSULTORIO MÉDICO EN C#

Este proyecto consiste en desarrollar un sistema de consola para la administración básica de un consultorio médico.

El sistema está pensado para ser utilizado por una secretaria o personal administrativo y permitirá:

1. Ver doctores disponibles.
2. Agendar citas.
3. Ver citas registradas.
4. Gestionar citas.
5. Salir del sistema.

---

# OBJETIVO DE LA RAMA DEVELOP

La rama `develop` contiene la base común del proyecto.

Todos los integrantes deben partir desde esta rama para desarrollar sus módulos.

La finalidad es que todos puedan trabajar al mismo tiempo sin modificar las mismas partes del código.

---

# VARIABLES PRINCIPALES QUE NO SE DEBEN CAMBIAR

Estas variables serán utilizadas por todos los integrantes.

No cambiar nombres.

```csharp
doctores
horarios
horarios_ocupados
max_citas
citas
cantidad_citas
salir
```

---

# STRUCTS QUE NO SE DEBEN CAMBIAR

## struct Doctor

Campos:

```csharp
nombre
especialidad
perfil
```

## struct Cita

Campos:

```csharp
paciente
cedula
doctor
especialidad
horario
estado
doctor_index
horario_index
```

---

# FUNCIONES COMUNES QUE TODOS PUEDEN USAR

Estas funciones ya se encuentran en la base del proyecto.

```csharp
limpiar_pantalla()
mostrar_encabezado()
escribir_color()
pausar()
leer_entero()
leer_texto()
confirmar()
```

Ningún integrante debe cambiar estas funciones sin autorización del líder.

---

# DISTRIBUCIÓN DEL TRABAJO

---

# INTEGRANTE 1
## OPCIÓN 1 - VER DOCTORES DISPONIBLES

Responsable del módulo de doctores y horarios.

Debe trabajar en:

```csharp
ver_doctores()
mostrar_lista_doctores()
mostrar_horarios_doctor()
```

También es responsable de la información base:

```csharp
struct Doctor
doctores
horarios
horarios_ocupados
```

Debe encargarse de:

- Definir los doctores del sistema.
- Definir las especialidades.
- Definir los perfiles.
- Definir los horarios.
- Mostrar los doctores.
- Mostrar los horarios.
- Mostrar si un horario está disponible.
- Mostrar si un horario está ocupado.

Debe utilizar:

```csharp
doctores
horarios
horarios_ocupados
horarios.GetLength(1)
```

Ejemplo visual esperado:

```text
1. Dra. Valeria Rivas
   Especialidad: Medicina General
   Perfil: Atiende consultas generales.

   Horarios:
   1. 08:00 AM | Disponible
   2. 09:00 AM | Ocupado
   3. 10:00 AM | Disponible

2. Dr. Carlos Mendoza
   Especialidad: Pediatría
   Perfil: Especialista en atención médica para niños.

   Horarios:
   1. 08:30 AM | Disponible
   2. 09:30 AM | Disponible
   3. 10:30 AM | Ocupado
```

Importante:

Este módulo proporciona la información que utilizarán los demás módulos del sistema.

---

# INTEGRANTE 2
## OPCIÓN 2 - AGENDAR CITA

Debe trabajar en:

```csharp
agendar_cita()
doctor_tiene_horarios_disponibles()
seleccionar_horario_disponible()
```

Debe encargarse de:

- Solicitar nombre del paciente.
- Solicitar cédula o identificación.
- Mostrar los doctores.
- Permitir seleccionar un doctor.
- Mostrar el perfil del doctor seleccionado.
- Mostrar los horarios disponibles.
- Validar que el horario no esté ocupado.
- Confirmar la cita.
- Guardar la cita.
- Incrementar cantidad_citas.
- Marcar el horario como ocupado.

Debe utilizar:

```csharp
citas
cantidad_citas
doctores
horarios
horarios_ocupados
max_citas
```

Ejemplo visual esperado:

```text
Nombre del paciente: Juan Pérez

Cédula o identificación:
001-000000-0000X

Seleccione el doctor:

1. Dra. Valeria Rivas
2. Dr. Carlos Mendoza
3. Dra. Sofía Martínez

Seleccione el horario:

2

¿Desea confirmar la cita? (s/n): s

La cita fue agendada correctamente.
```

---

# INTEGRANTE 3
## OPCIÓN 3 - VER MIS CITAS

Debe trabajar en:

```csharp
ver_mis_citas()
mostrar_cita()
```

Debe encargarse de:

- Validar si existen citas.
- Buscar citas por cédula.
- Mostrar todas las citas.
- Mostrar la información completa de una cita.
- Mostrar si una cita está confirmada o cancelada.

Debe utilizar:

```csharp
citas
cantidad_citas
```

Ejemplo visual esperado:

```text
1. Buscar por cédula
2. Mostrar todas las citas

Paciente: Juan Pérez
Cédula: 001-000000-0000X

Doctor: Dra. Valeria Rivas
Especialidad: Medicina General

Horario: 09:00 AM

Estado: Confirmada
```

---

# INTEGRANTE 4
## OPCIÓN 4 - GESTIÓN DE CITAS Y SALIDA

Debe trabajar en:

```csharp
menu_gestion_citas()
cancelar_cita()
reporte_citas()
guardar_datos()
despedida()
```

Debe encargarse de:

- Crear el segundo menú.
- Cancelar citas.
- Liberar horarios ocupados.
- Generar reporte de citas.
- Mostrar citas confirmadas.
- Mostrar citas canceladas.
- Mostrar estadísticas por doctor.
- Mostrar el mensaje final de salida.

Debe utilizar:

```csharp
citas
cantidad_citas
horarios_ocupados
doctores
```

Ejemplo visual esperado:

```text
GESTIÓN DE CITAS

1. Cancelar cita
2. Agendar otra cita
3. Reporte de citas del día
4. Volver al menú principal
```

Ejemplo de reporte:

```text
REPORTE DE CITAS DEL DÍA

Total de citas registradas: 5

Citas confirmadas: 4
Citas canceladas: 1

Citas confirmadas por doctor:

Dra. Valeria Rivas: 2
Dr. Carlos Mendoza: 1
Dra. Sofía Martínez: 1
```

---

# SOBRE GUARDAR DATOS

En esta versión base del proyecto NO se utilizará:

```csharp
using System.IO
```

Por lo tanto:

- Los datos se almacenarán temporalmente.
- Las citas se guardarán dentro del arreglo `citas`.
- Los horarios ocupados se guardarán dentro de `horarios_ocupados`.
- Al cerrar el programa toda la información se reiniciará.

La función:

```csharp
guardar_datos()
```

representa únicamente el guardado temporal de la información.

---

# RAMAS RECOMENDADAS

Cada integrante debe crear su propia rama basada en `develop`.

```text
feature/ver-doctores
feature/agendar-cita
feature/ver-citas
feature/gestion-citas
```

---

# FORMA DE TRABAJAR EN GITHUB

Actualizar develop:

```bash
git checkout develop
git pull origin develop
```

Crear rama:

```bash
git checkout -b feature/nombre-de-la-rama
```

Subir cambios:

```bash
git add .
git commit -m "descripcion del cambio"
git push -u origin feature/nombre-de-la-rama
```

---

# REGLAS IMPORTANTES

1. No trabajar directamente en main.
2. No trabajar directamente en develop después de creada la base.
3. Cada integrante trabaja únicamente en su rama.
4. No cambiar nombres de variables globales.
5. No cambiar nombres de structs.
6. No cambiar nombres de funciones comunes.
7. Utilizar snake_case en nuevas funciones.
8. Validar todas las entradas del usuario.
9. Probar el código antes de subir cambios.
10. Consultar al líder antes de modificar código ajeno.

---

# ORDEN RECOMENDADO PARA INTEGRAR

1. feature/ver-doctores
2. feature/agendar-cita
3. feature/ver-citas
4. feature/gestion-citas

Razón:

- Agendar cita depende de doctores y horarios.
- Ver citas depende de que existan citas.
- Gestión de citas depende de las citas registradas.

---

# LÍDER DEL PROYECTO

Responsabilidades del líder:

- Mantener la rama develop.
- Resolver conflictos de merge.
- Revisar los cambios de cada integrante.
- Integrar las ramas al proyecto principal.
- Verificar que todo compile correctamente.
- Mantener actualizado este README.