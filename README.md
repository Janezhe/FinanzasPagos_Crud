# FinanzasPagos_Crud

FinanzasPagos_Crud es una aplicación web desarrollada con C# y .NET que permite gestionar gastos y pagos personales de forma sencilla e intuitiva, con una interfaz estilo bancario y persistencia de datos en MySQL.

## 1. Clonar repositorio

```bash
https://github.com/Janezhe/FinanzasPagos_Crud.git
```

## 2. Configuración de la base de datos

```yaml
ConnectionStrings:
  DefaultConnection: "server=localhost;database=crudpagosdb;user=root;password=TU_PASSWORD;"

Logging:
  LogLevel:
    Default: Information
    Microsoft.AspNetCore: Warning
    Microsoft.EntityFrameworkCore.Database.Command: Information

AllowedHosts: "*"

App:
  Nombre: "FinanzasPagos"
  Version: "1.0.0"
```

## 3. Características principales

- **Gestión de Pagos**: listado, creación, visualización de detalles, edición y eliminación con control de estado (Pendiente / Aprobado).
- **Gestión de Gastos**: listado, creación, visualización de detalles, edición y eliminación con campo de descripción.
- **Gestión de Categorías**: navegación por categorías (Pagos / Gastos) desde una sola vista para una mejor organización.
- **Interfaz Premium**: diseño estilo bancario con paleta azul navy, gradientes y componentes modales dinámicos mediante CSS personalizado.
- **Validación de Datos**: implementación de validaciones en servidor y cliente para garantizar la integridad de la información.
- **Persistencia de Datos**: almacenamiento en MySQL con Entity Framework Core y Pomelo, configuración mediante archivo YAML (`appsettings.yml`).

## 4. Tecnologías utilizadas

- ASP.NET Core 8 MVC
- Entity Framework Core 8
- Pomelo.EntityFrameworkCore.MySql
- MySQL 8
- HTML / CSS / JavaScript (vanilla)
- YAML para configuración (NetEscapades.Configuration.Yaml)

## 5. Estructura del proyecto

```
FinanzasPagos_Crud/
├── Controllers/
│   ├── PagosController.cs          # CRUD de pagos + carga del ViewModel
│   └── GastosController.cs         # CRUD de gastos
├── Data/
│   └── FinanzasDb.cs               # DbContext con DbSet(Pago) y DbSet(Gasto)
├── Migrations/                     # Migraciones generadas por EF Core
├── Models/
│   ├── Pago.cs                     # Modelo: Id, Monto, Estado, Categoria, CreadoEn
│   ├── Gasto.cs                    # Modelo: Id, Monto, Descripcion, CreadoEn
│   └── PagoGastoViewModel.cs       # ViewModel combinado para Index
├── Views/
│   └── Pagos/
│       ├── Index.cshtml            # Vista principal (menú Pagos / Gastos)
│       ├── Crear.cshtml
│       ├── Detalle.cshtml
│       └── Eliminar.cshtml
│   └── Shared/
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot/                        # Archivos estáticos (CSS, JS)
├── Properties/
│   └── launchSettings.json
├── appsettings.json
├── appsettings.Development.json
├── appsettings.yml                 # Configuración principal (cadena de conexión)
└── Program.cs
```

## 6. Migración de base de datos

Abrir la **Consola del Administrador de paquetes**:
Herramientas → Administrador de paquetes NuGet → Consola del Administrador de paquetes

```powershell
Add-Migration Inicial
Update-Database
```

> Usa siempre la Consola del Administrador de paquetes (NuGet), no el Developer PowerShell ni CMD.

## 7. Capturas de pantalla

## Pagos

### Listado de Pagos
<img src="imagenes/listado_pago.png" width="700" alt="Listado de Pagos"/>

### Detalle de Pagos
<img src="imagenes/detalle_pago.png" width="700" alt="Detalle de Pagos"/>

### Buscador por Estado
<img src="imagenes/buscar_estado.png" width="700" alt="Buscador por Estado"/>

### Eliminar Pago
<img src="imagenes/eliminar_pago.png" width="700" alt="Eliminar Pago"/>

## Gastos

### Listado de Gastos
<img src="imagenes/listado_gastos.png" width="700" alt="Listado de Gastos"/>

### Editar Gasto
<img src="imagenes/editar_gasto.png" width="700" alt="Editar Gasto"/>
