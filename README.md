# Sistema de Gestión de Reservas - SunsetParadise

Este proyecto es un **sistema de gestión de reservas de hotel** desarrollado con **ASP.NET Core MVC**. Permite crear, visualizar y anular reservas, así como gestionar clientes y habitaciones.
- [Video demostrativo](https://drive.google.com/file/d/11EfyPDAK27UgysaUpAZWWjoZ8QJJ--Uu/view?usp=drivesdk)
- 
## Integrantes
- María José Rivera Flores - RF231136
---

## Características

- Crear, listar y cancelar reservas.
- Validaciones de fechas: no se permite ingresar fechas anteriores a la actual, ni que la fecha de salida sea menor que la de entrada.
- Gestión de clientes y habitaciones.
- Cálculo automático del total de la reserva según precio por noche y duración.
- Actualización automática del estado de las reservas: Activa, Finalizada o Anulada.

---

## Requisitos

- [.NET SDK 7.0 o superior](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (recomendado) o Visual Studio Code

---

## Instalación y ejecución

1. **Clonar el repositorio:**

```bash
git clone https://github.com/bannle/SunsetParadise.git
cd SunsetParadise
````

2. **Restaurar paquetes NuGet:**

```bash
dotnet restore
````
3. **Compilar el proyecto:**
```bash
dotnet build
````
4. **Ejecutar la aplicación:**
````bash
dotnet run
````
5. **Abrir en el navegador:**

- Acceder a la página principal en:
- [https://localhost:5001/](https://localhost:7257/)
