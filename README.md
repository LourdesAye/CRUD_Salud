# Descripción general: Proyecto CLINICA - FRBA

Mediante este trabajo práctico se intentó simular la implementación de un nuevo sistema del ramo de la medicina, en donde se abordó la problemática de los afiliados y la implementación de un nuevo módulo que le permitía comprar bonos desde cualquier pc, como así también el pedido de turnos para los diferentes profesionales que conformaban el staff de la clínica. 
La implementación de dicho sistema requirió realizar la migración de los datos que se tenían hasta el momento en el sistema anterior.
Es para ello que se necesitó que se reformularan los procesos y el diseño de la base de datos para que cumpla con las nuevas restricciones.

# Componentes del TP

## Aplicación Desktop

La aplicación es del tipo Desktop desarrollada sobre C# con Visual Studio 2012 y Framework de .NET 4.5.
Esta aplicación tiene diversas pantallas, reportes y formularios que permiten interactuar, cargar y visualizar la información de la base de datos de SQL Server.
Las funcionalidades que se han desarrollado:
1. Abm de Rol .
2. Login y seguridad .
3. Registro de Usuario .
4. Abm Afiliado.
5. Abm Profesional.
6. Abm Especialidades Médicas .
7. Abm de Planes .
8. Registrar agenda del médico .
9. Compra de bonos.
10. Pedir turno.
11. Registro de llegada para atención médica .
12. Registrar resultado para atención médica.
13. Cancelar atención médica.
  * De parte del médico.
  * De parte del afiliado.

## Base de Datos

Se crea un modelo de datos que organice y normalice los datos de la única tabla existente. 
Este modelo de datos incluye:
* Creación de esquema correspondiente.
* Creación de nuevas tablas y vistas.
* Creación de claves primarias y foráneas para relacionar estas tablas.
* Creación de constraints y triggers sobre estas tablas cuando fuese necesario.
* Creación de los índices para acceder a los datos de estas tablas de manera eficiente.
* Migración de datos: Cargar todas las tablas creadas utilizando la totalidad de los datos entregados por la cátedra en la única tabla del modelo.
* Inserción de datos no incluidos en la tabla maestra que sean necesarios para el funcionamiento de la aplicación desktop, como por ejemplo, los roles.

#Sobre mi

En este trabajo práctico realizado para la materia Gestión de Datos en 2016, participé activamente en el desarrollo de la interfaz de usuario de la aplicación desktop, diseñando y programando la mayoría de las pantallas en C# con .NET. También implementé consultas SQL desde C# para recuperar y mostrar datos en la aplicación. A través de este proyecto, adquirí experiencia en el desarrollo de aplicaciones desktop, integración de C# con bases de datos SQL Server y la construcción de consultas básicas. Además, aprendí sobre el diseño y la gestión de bases de datos relacionales, comprendiendo conceptos como normalización, claves primarias y foráneas, y restricciones.
