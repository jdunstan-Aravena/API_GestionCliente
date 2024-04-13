# API de Gestión de Clientes

Esta API proporciona endpoints para crear, actualizar y obtener clientes. Está construida con .NET Core y utiliza una base de 
datos SQLite para almacenar los datos de los clientes.

## Configuración del Proyecto

Antes de ejecutar la API, asegúrate de tener instalado lo siguiente:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQLite](https://www.sqlite.org/download.html) (opcional, si deseas trabajar con una base de datos SQLite)

## Configuración de la Base de Datos

Para configurar la base de datos SQLite, sigue estos pasos:

1. Abre una terminal o símbolo del sistema.
2. Navega hasta el directorio del proyecto.
3. Ejecuta el siguiente comando para aplicar las migraciones y crear la base de datos:
   ```bash
   dotnet ef database update


Ejecución del Proyecto
Para ejecutar la API, sigue estos pasos:

Abre una terminal o símbolo del sistema.
Navega hasta el directorio del proyecto.
Ejecuta el siguiente comando para compilar y ejecutar el proyecto: dotnet run

Endpoints
La API expone los siguientes endpoints:

POST /api/cliente: Crea un nuevo cliente.
PUT /api/cliente/{id}: Actualiza un cliente existente.
GET /api/cliente/{id}: Obtiene los detalles de un cliente específico.

Ejemplos de Uso

Crear Cliente:
POST /api/cliente
Content-Type: application/json
{
  "nombre": "Ejemplo",
  "apellido": "Cliente",
  "correoElectronico": "ejemplo@cliente.com"
}

Actualizar Cliente:
PUT /api/cliente/1
Content-Type: application/json
{
  "nombre": "Nuevo",
  "apellido": "Nombre",
  "correoElectronico": "nuevo@cliente.com"
}

Obtener Cliente:
GET /api/cliente/1


Nota del Creador:  Para este archivo y del release busqué ejemplos por internet pues no había tenido que crear nunca estos
                   archivos.
