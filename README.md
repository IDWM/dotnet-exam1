# IDWM 2024-2: Cátedra 1

Este proyecto corresponde a la Cátedra 1 para la asignatura Introducción al Desarrollo Web Móvil.

## Requerimientos

- **[ASP.NET Core 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)** 
- **[Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)** 
- **[Postman](https://www.postman.com/downloads/)** para probar la API

## Clonar el Repositorio

Clona el repositorio con el siguiente comando:

```bash
git clone https://github.com/IDWM/dotnet-exam1.git
```

## Restaurar el Proyecto

Después de clonar el repositorio, navega a la carpeta del proyecto y restaura los paquetes de NuGet:

```bash
cd dotnet-exam1
dotnet restore
```

## Configurar la Base de Datos

Crea el archivo `appsettings.json` para configurar la conexión a la base de datos. Añade la siguiente cadena de conexión para usar una base de datos SQLite:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  }
}
```

Este ajuste se encargará de crear una base de datos local `app.db`.

## Ejecutar la Aplicación

Para ejecutar la aplicación, utiliza el siguiente comando:

```bash
dotnet run
```

Esto iniciará el servidor en `http://localhost:5000`.

## Probar la API con Postman

Utiliza Postman para probar los endpoints de la API. Importa la colección llamada **"IDWM - Cátedra 1.postman_collection.json"**, que está incluida en el proyecto, y ejecuta las solicitudes predefinidas.