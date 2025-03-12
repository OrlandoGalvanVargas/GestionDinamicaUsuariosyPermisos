---

## **Documentación Técnica: Sistema de Gestión de Usuarios, Logins y Permisos**

### **1. Descripción General**

El sistema permite gestionar usuarios, logins, permisos y roles en una base de datos SQL Server. Está desarrollado en **ASP.NET Core** (Razor Pages) y utiliza un procedimiento almacenado (`sp_GestionUsuariosYPermisos`) para realizar las operaciones en la base de datos.

---

### **2. Requisitos**

- **ASP.NET Core**: La aplicación está desarrollada en ASP.NET Core (Razor Pages).
- **SQL Server**: Se requiere una instancia de SQL Server con acceso a la base de datos `DBAdmin`.
- **Procedimiento Almacenado**: El procedimiento almacenado `sp_GestionUsuariosYPermisos` debe estar creado en la base de datos `DBAdmin`.
- **Bootstrap**: Se utiliza para el diseño de las vistas.

---

### **3. Estructura del Proyecto**

El proyecto tiene la siguiente estructura de archivos:

```text
Pages/
├── GestionUsuarios/
│   ├── CrearLoginUsuario.cshtml          // Crear logins y usuarios
│   ├── AsignarPermisos.cshtml            // Asignar permisos a usuarios
│   ├── GestionRoles.cshtml               // Crear roles y asignar usuarios
│   ├── HistorialOperaciones.cshtml       // Historial de operaciones
Shared/
├── _Layout.cshtml                        // Layout común
appsettings.json                            // Configuración de la cadena de conexión
Program.cs                                // Configuración de la aplicación
```
---

### **4. Componentes del Sistema**

#### **4.1. Crear Login y Usuario (`CrearLoginUsuario.cshtml`)**
- **Descripción**: Permite crear un nuevo login y usuario en SQL Server.
- **Funcionalidades**:
    - Crear un login.
    - Crear un usuario asociado al login.
    - Asignar permisos a tablas y esquemas.
    - Mostrar una lista de logins y usuarios existentes.
- **Procedimiento Almacenado**: Acción 1 (`@Accion = 1`).

#### **4.2. Asignar Permisos (`AsignarPermisos.cshtml`)**
- **Descripción**: Permite asignar permisos específicos a usuarios en tablas y esquemas.
- **Funcionalidades**:
    - Asignar permisos a tablas y esquemas.
    - Revocar permisos.
    - Mostrar una lista de permisos asignados.
- **Procedimiento Almacenado**: Acción 2 (`@Accion = 2`) y Acción 8 (`@Accion = 8`).

#### **4.3. Gestión de Roles (`GestionRoles.cshtml`)**
- **Descripción**: Permite crear roles y asignar usuarios a roles.
- **Funcionalidades**:
    - Crear roles.
    - Asignar usuarios a roles.
    - Mostrar una lista de roles y usuarios asignados.
- **Procedimiento Almacenado**: Acción 3 (`@Accion = 3`) y Acción 4 (`@Accion = 4`).

#### **4.4. Historial de Operaciones (`HistorialOperaciones.cshtml`)**
- **Descripción**: Muestra un registro de las operaciones realizadas en el sistema.
- **Funcionalidades**:
    - Filtrar operaciones por tipo y fecha.
    - Mostrar una lista de operaciones con detalles.
- **Tabla de Base de Datos**: `HistorialOperaciones`.

---

### **5. Procedimiento Almacenado (`sp_GestionUsuariosYPermisos`)**

El procedimiento almacenado `sp_GestionUsuariosYPermisos` maneja todas las operaciones relacionadas con usuarios, logins, permisos y roles. Aquí está un resumen de las acciones:

| Acción | Descripción                                  | Parámetros Requeridos                                         |
|--------|----------------------------------------------|-----------------------------------------------------------|
| 1      | Crear login y usuario                        | `@NombreLogin`, `@Contrasena`, `@NombreUsuario`, `@NombreBaseDatos` |
| 2      | Asignar permisos a tablas y esquemas         | `@NombreUsuario`, `@NombreBaseDatos`, `@PermisosTablas`, `@PermisosEsquemas` |
| 3      | Crear rol                                    | `@NombreRol`, `@NombreBaseDatos`                                 |
| 4      | Asignar usuario a rol                        | `@NombreUsuario`, `@NombreRol`, `@NombreBaseDatos`                 |
| 5      | Obtener logins y usuarios                    | Ninguno                                                     |
| 6      | Obtener permisos de usuario                  | `@NombreUsuario`                                           |
| 7      | Obtener roles y usuarios asignados           | Ninguno                                                     |
| 8      | Revocar permisos                             | `@NombreUsuario`, `@NombreBaseDatos`, `@PermisosTablas`, `@PermisosEsquemas` |

---

### **6. Flujo de Trabajo**

1. **Crear Login y Usuario**:
    - El usuario ingresa el nombre del login, la contraseña, el nombre del usuario y la base de datos.
    - El sistema valida que el login y el usuario no existan.
    - Si la validación es exitosa, se crea el login y el usuario.

2. **Asignar Permisos**:
    - El usuario selecciona un usuario, una base de datos y los permisos a asignar.
    - El sistema asigna los permisos a las tablas y esquemas especificados.

3. **Gestión de Roles**:
    - El usuario crea un rol y asigna usuarios a ese rol.
    - El sistema muestra una lista de roles y usuarios asignados.

4. **Historial de Operaciones**:
    - El sistema registra cada operación en la tabla `HistorialOperaciones`.
    - El usuario puede filtrar y ver el historial de operaciones.

---

### **7. Validaciones**

- **Duplicidad de Logins y Usuarios**: El sistema valida que no se creen logins o usuarios duplicados.
- **Existencia de Usuarios y Roles**: Antes de asignar permisos o roles, el sistema valida que el usuario y el rol existan.
- **Formato de Permisos**: Los permisos deben estar en formato SQL válido (por ejemplo, `SELECT, INSERT ON dbo.Tabla1`).

---

### **8. Mensajes de Error y Éxito**

- **Mensajes de Éxito**: Se muestran en verde cuando una operación se realiza correctamente.
- **Mensajes de Error**: Se muestran en rojo cuando ocurre un error (por ejemplo, duplicidad de logins o usuarios).

---

### **9. Pruebas**

1. **Crear Login y Usuario**:
    - Verifica que no se puedan crear logins o usuarios duplicados.
    - Verifica que los permisos se asignen correctamente.

2. **Asignar Permisos**:
    - Verifica que los permisos se asignen y revoquen correctamente.
    - Verifica que los permisos se muestren en la tabla de permisos asignados.

3. **Gestión de Roles**:
    - Verifica que se puedan crear roles y asignar usuarios.
    - Verifica que los roles y usuarios se muestren correctamente en la tabla.

4. **Historial de Operaciones**:
    - Verifica que cada operación se registre en el historial.
    - Verifica que los filtros funcionen correctamente.

---

### **10. Instrucciones de Uso**

1. **Crear Login y Usuario**:
    - Navega a la página `CrearLoginUsuario`.
    - Ingresa los datos del login, usuario y base de datos.
    - Haz clic en "Crear Login y Usuario".

2. **Asignar Permisos**:
    - Navega a la página `AsignarPermisos`.
    - Selecciona un usuario, una base de datos y los permisos a asignar.
    - Haz clic en "Asignar Permisos" o "Revocar Permisos".

3. **Gestión de Roles**:
    - Navega a la página `GestionRoles`.
    - Crea un rol o asigna usuarios a roles existentes.
    - Haz clic en "Crear Rol" o "Asignar Usuario a Rol".

4. **Historial de Operaciones**:
    - Navega a la página `HistorialOperaciones`.
    - Filtra las operaciones por tipo y fecha.
    - Revisa el historial de operaciones.

---

### **11. Conclusión**

El sistema de gestión de usuarios, logins y permisos es una herramienta robusta y fácil de usar que permite administrar eficientemente los accesos y permisos en una base de datos SQL Server. Con esta documentación, los desarrolladores y administradores pueden entender y utilizar el sistema de manera efectiva.

---

