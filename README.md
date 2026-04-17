# API WEB - Sistema de Gestión de Clientes - Asesor

Este es un sistema de gestión de clientes construido con .NET 8 y arquitectura limpia (Clean Architecture).

## 📋 Descripción General

Es una aplicación ASP.NET Core diseñada para gestionar información de clientes en el contexto del sector de seguros. Implementa patrones de diseño modernos como CQRS (Command Query Responsibility Segregation) y una arquitectura de capas desacopladas que facilita el mantenimiento, testing y escalabilidad.

## 🏗️ Arquitectura

El proyecto sigue una arquitectura limpia con **5 capas principales**:

```
┌────────────────────────────────────┐
│   Asesor.API (Presentación)        │ ← Controladores, DTOs, Middlewares
├────────────────────────────────────┤
│  Asesor.Aplicacion (Aplicación)    │ ← Casos de uso, Comandos, Consultas
├────────────────────────────────────┤
│  Asesor.Dominio (Dominio)          │ ← Entidades, Objetos de Valor
├────────────────────────────────────┤
│  Asesor.Persistencia (Infraestructura) │ ← DbContext, Repositorios
└────────────────────────────────────┘
```

### 📦 Proyectos

#### 1. **Asesor.API** (Capa de Presentación)
- **Responsabilidad**: Expone los endpoints REST y maneja las solicitudes HTTP
- **Contenido**:
  - `Controllers/`: Controladores REST
    - `ClienteController.cs`: Gestiona operaciones de clientes (GET, POST, PUT, DELETE)
  - `DTOs/`: Data Transfer Objects para transferencia de datos
    - `ClientesDTO.cs`: DTO para crear clientes
    - `ActualizaClienteDTO.cs`: DTO para actualizar clientes
  - `Midlewares/`: Middlewares HTTP
    - `ManejadorExcepcionesMiddleware.cs`: Centraliza el manejo de excepciones
- **Framework**: ASP.NET Core 8.0 (Sdk.Web)
- **Características**:
  - Validación de entrada en DTOs
  - Manejo centralizado de excepciones
  - Redirección HTTPS automática

#### 2. **Asesor.Aplicacion** (Capa de Aplicación)
- **Responsabilidad**: Implementa la lógica de casos de uso siguiendo CQRS
- **Contenido**:
  - `CasosUso/GestionCliente/`:
    - **Comandos** (Escritura):
      - `CrearCliente/`: Crear nuevo cliente
      - `ActualizarCliente/`: Actualizar datos del cliente
      - `BorrarCliente/`: Eliminar cliente
    - **Consultas** (Lectura):
      - `ListarClientes/`: Obtener listado de todos los clientes
      - `ObtenerCliente/`: Obtener detalles de un cliente específico
      - `ObtenerDetalleCliente/`: Obtener información detallada
  - `Contratos/`: Interfaces y contratos
  - `Excepciones/`: Excepciones personalizadas de la aplicación
  - `Utilidades/`:
    - `Mediador/`: Implementación del patrón Mediator para enrutar comandos/consultas
  - `RegistraServiciosDeAplicacion.cs`: Inyección de dependencias
- **Patrones**:
  - **CQRS**: Separación de comandos (escritura) y consultas (lectura)
  - **Mediator**: Desacoplamiento entre controladores y casos de uso
  - **Validación**: Usando FluentValidation

#### 3. **Asesor.Dominio** (Capa de Dominio)
- **Responsabilidad**: Define las entidades y lógica de negocio principal
- **Contenido**:
  - `Entidades/`:
    - `Cliente.cs`: Entidad principal que representa un cliente
      - Propiedades: Id, Nombre, Identificación, Correo, Teléfono, Dirección
      - Métodos: Constructor privado, Actualizar, validaciones
  - `ObjetosValor/`: Tipos de valor que encapsulan lógica
    - `Identificacion.cs`: Objeto de valor para validar identificaciones
    - `CorreoElectronico.cs`: Objeto de valor para validar correos electrónicos
  - `Enumerados/`: Enumeraciones del dominio
  - `Excepciones/`:
    - `ExcepcionReglaNegocio.cs`: Excepción para violaciones de reglas de negocio
- **Características**:
  - Encapsulación de lógica de negocio en entidades
  - Validaciones en constructores
  - Objetos de valor para garantizar integridad de datos

#### 4. **Asesor.Persistencia** (Capa de Infraestructura)
- **Responsabilidad**: Maneja la persistencia de datos en SQL Server
- **Contenido**:
  - `AsesorDBContext.cs`: DbContext de Entity Framework Core
  - `Configuracion/`: Configuraciones de entidades para EF Core
  - `Migrations/`: Migraciones de base de datos
  - `Repositorio/`: Patrones de acceso a datos
  - `UnidadTrabajo/`: Patrón Unit of Work para transacciones
  - `RegistroServiciosDePersistencia.cs`: Inyección de dependencias
- **Tecnologías**:
  - Entity Framework Core 8.0.11
  - SQL Server
- **Características**:
  - DbSet para Clientes
  - Migraciones automáticas
  - Configuración centralizada de entidades

#### 5. **Asesor.pruebas** (Capa de Testing)
- **Responsabilidad**: Pruebas automatizadas del sistema
- **Contenido**: Casos de prueba para validar la funcionalidad

## 🔄 Flujo de Solicitud

```
1. Cliente HTTP realiza solicitud a /api/cliente
   ↓
2. ClienteController recibe y mapea DTOs
   ↓
3. Controller envía Comando/Consulta via Mediator
   ↓
4. Mediator enruta a CasoUso correspondiente
   ↓
5. CasoUso ejecuta lógica y accede a persistencia
   ↓
6. AsesorDBContext interactúa con SQL Server
   ↓
7. Respuesta regresa hacia cliente
   ↓
8. ManejadorExcepcionesMiddleware captura errores si ocurren
```

## 📊 Modelo de Datos

### Entidad: Cliente

```
┌─────────────────────────────┐
│         Cliente             │
├─────────────────────────────┤
│ Id (Guid)                   │
│ Nombre (string)             │
│ Identificacion (ValObj)     │
│ Correo (ValObj)             │
│ Teléfono (string)           │
│ Dirección (string)          │
└─────────────────────────────┘
```

## 🚀 Endpoints de API

### Clientes

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/cliente` | Listar todos los clientes |
| `GET` | `/api/cliente/{id}` | Obtener cliente por ID |
| `POST` | `/api/cliente` | Crear nuevo cliente |
| `PUT` | `/api/cliente/{id}` | Actualizar cliente |
| `DELETE` | `/api/cliente/{id}` | Eliminar cliente |

### Ejemplos

**Crear Cliente:**
```http
POST /api/cliente
Content-Type: application/json

{
  "nombre": "Juan Pérez",
  "identificacion": "12345678",
  "correo": "juan@example.com",
  "telefono": "555-1234",
  "direccion": "Calle Principal 123"
}
```

**Actualizar Cliente:**
```http
PUT /api/cliente/{id}
Content-Type: application/json

{
  "nombre": "Juan Pedro Pérez",
  "identificacion": "12345678",
  "correo": "juan.p@example.com",
  "telefono": "555-5678",
  "direccion": "Calle Principal 456"
}
```

## 🛠️ Tecnologías Utilizadas

- **.NET 8.0**: Framework principal
- **ASP.NET Core**: Servidor web
- **Entity Framework Core 8.0.11**: ORM para SQL Server
- **FluentValidation**: Validación fluida
- **SQL Server**: Base de datos
- **CQRS**: Patrón de separación de responsabilidades
- **Mediator**: Patrón para desacoplamiento

## ⚙️ Configuración

### Archivos de Configuración

- `appsettings.json`: Configuración general
- `appsettings.Development.json`: Configuración para desarrollo

### Variables de Entorno Requeridas

- **ConnectionString**: Cadena de conexión a SQL Server

## 🔐 Manejo de Errores

El sistema implementa un middleware centralizado de excepciones (`ManejadorExcepcionesMiddleware`) que:

- Captura todas las excepciones no controladas
- Devuelve respuestas de error estructuradas con códigos HTTP apropiados
- Registra errores para auditoría
- Diferencia entre errores de negocio y errores técnicos

### Excepciones Personalizadas

- `ExcepcionReglaNegocio`: Violaciones de reglas de negocio

## 📖 Patrones de Diseño

### 1. Clean Architecture
- Separación en capas independientes
- Dependencias apuntan hacia adentro (hacia el dominio)
- Fácil testabilidad

### 2. CQRS (Command Query Responsibility Segregation)
- **Comandos**: Operaciones que modifican estado (Create, Update, Delete)
- **Consultas**: Operaciones de solo lectura (Get, List)

### 3. Mediator
- Desacopla controladores de casos de uso
- Centraliza el enrutamiento de comandos y consultas

### 4. Repository Pattern
- Abstracción del acceso a datos
- Facilita testing con mocks

### 5. Unit of Work
- Manejo de transacciones
- Coherencia en operaciones múltiples

### 6. Value Objects
- `Identificacion`: Valida formato de identificación
- `CorreoElectronico`: Valida formato de email

### 7. Dependency Injection
- Inyección automática en `Program.cs`
- Extensiones para registro de servicios

## 🧪 Testing

La solución incluye el proyecto `Asesor.pruebas` para:
- Pruebas unitarias de entidades y casos de uso
- Pruebas de integración con base de datos
- Validación de reglas de negocio

## 📝 Validaciones

### Nivel DTOs (API)
- Atributos `[Required]` en propiedades
- Validación automática en endpoint

### Nivel Aplicación
- FluentValidation para reglas complejas
- Validadores específicos por caso de uso

### Nivel Dominio
- Validaciones en constructores
- Objetos de valor encapsulan validaciones
- Excepciones de regla de negocio

## 🔗 Flujo de Dependencias

```
Asesor.API
  └─> Asesor.Aplicacion
        └─> Asesor.Dominio
        └─> Asesor.Persistencia
              └─> Asesor.Aplicacion
              └─> Asesor.Dominio
```

**Regla**: Las capas internas nunca dependen de las externas. Las dependencias siempre apuntan hacia el dominio.

## 🚦 Estado del Proyecto

- ✅ Arquitectura limpia implementada
- ✅ CQRS completamente funcional
- ✅ Gestión de clientes (CRUD)
- ✅ Manejo centralizado de excepciones
- ✅ Validación en múltiples capas
- ✅ Migraciones de base de datos

## 📚 Recursos Adicionales

- [Clean Architecture - Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [CQRS Pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [FluentValidation](https://fluentvalidation.net/)

---

**Última actualización**: Abril 2026
**Versión**: 1.0.0
**Autor**: Equipo de Desarrollo
