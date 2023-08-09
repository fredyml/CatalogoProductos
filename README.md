# Catálogo de Productos - API Restful

## Descripción

La aplicación es una API Restful que permite gestionar un catálogo de productos. Cada producto tiene las siguientes características:

- Nombre
- Descripción breve
- Categoría
- Imagen del producto (URL)

La API proporciona endpoints para:

1. Crear un nuevo producto
2. Modificar un producto existente
3. Borrar un producto existente
4. Listar los productos existentes con opciones de búsqueda y ordenación

## Endpoints

### Crear un nuevo producto (POST)

**Endpoint:** `/api/products`

**Request Body:**

```json
{
  "name": "nombre del producto",
  "description": "descripción breve del producto",
  "category": "categoría del producto",
  "productImageUrl": "url de la imagen del producto"
}
```

### Modificar un producto existente (PUT)

**Endpoint:** `/api/products`

**Request Body:**

```json
{
  "id": "ID del producto",
  "name": "nombre del producto",
  "description": "descripción breve del producto",
  "category": "categoría del producto",
  "productImageUrl": "url de la imagen del producto"
}
```

### Borrar un producto existente (DELETE)

**Endpoint:** `/api/products/{id}`

### Listar los productos existentes (GET)

**Endpoint:** `/api/products`

**Parámetros de consulta:**

- `name`: Filtrar por nombre
- `description`: Filtrar por descripción
- `category`: Filtrar por categoría
- `orderBy`: Ordenar por nombre o categoría
- `isAscending`: Orden ascendente o descendente

## Validaciones

- La URL de la imagen del producto debe tener una extensión de imagen válida (por ejemplo, `.jpg`, `.jpeg`, `.png`, `.gif`, `.bmp`).
- Todos los campos son obligatorios para la creación de un producto.

## Rendimiento

La aplicación está diseñada para manejar un catálogo de productos que puede crecer hasta más de 100 mil registros. Se han utilizado técnicas como paginación, filtrado y ordenación para garantizar el rendimiento óptimo de la aplicación.

## Tecnologías Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- AutoMapper
- NLog for Logging

## Cómo ejecutar la aplicación

1. Asegúrese de tener instalado .NET Core SDK y SQL Server.
2. Configure la cadena de conexión en el archivo `appsettings.json`.
3. Ejecute los siguientes comandos en la raíz del proyecto:

   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

4. La aplicación estará disponible en `https://localhost:5001`.

## Documentación API

La documentación de la API y la interfaz de usuario Swagger están disponibles en `https://localhost:5001/swagger`.

---

Desarrollado con ❤️ por Fredy Mendoza. Para cualquier pregunta o comentario, no dude en ponerse en contacto.
