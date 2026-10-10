# Nombre del proyecto ||| Conexión a GastosDB

## Pasos para ejecutar el Program.cs
- | Abrir Visual Studio Community 2026
- | Ejecutar el script crear_GastosDB.sql en una nueva consulta de (localdb)\MSSQLLocalDB
- | Abrir el proyecto y presionar "F5" o "Ctrl+F5" para ejecutarlo

# Capturas

## Escenario 1
![Captura 1](Capturas/cap1.png)

## Escenario 2
![Captura 2](Capturas/cap2.png)

## Escenario 3
![Captura 3](Capturas/cap3.png)

## Escenario 4: base de datos inexistente
Se cambió GastosDB por GastosDBh en la cadena de conexión.

![Captura 4](Capturas/cap4.png)

Se lanza una SqlException porque conexion.Open() Porque intenta abrir una base de datos que no existe.
