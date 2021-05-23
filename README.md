# Nokiu

## Pasos para deploy del proyecto y conectarse al Repositorio 

1-Clonar el proyecto con Visual Studio 2019

2-Abrir la solución y desde VS => Extensiones, instalar Github. Seguir los pasos, reiniciar si es necesario.
  video de Referencia https://youtu.be/560GOf3f6xk

3- Para conectar con la DB desde VS con EntityFramework:

​		-Click derecho en el proyecto y luego click en unload o (descargar ESP). En todos excepto en 			Nokiu.Entities

​			https://drive.google.com/file/d/1neItjGza7G_snqEA0PJDhXMd54tOk398/view?usp=sharing

-Luego abrir la consola de Administracion de paquetes Nuget

      https://drive.google.com/file/d/1NQibvZsItLIV1afUgi9wViv67ms9AAQW/view?usp=sharing

Si tienen autorización con Windows en su SQL Server tienen que introducir la sentencia :

Scaffold-DBContext "Server=Tu_Server;Database=Nokiu;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

## ATENCIÓN: PUEDE SER QUE AL MAPPEAR CON LA DB ALGUNAS CLASES EN LA CARPETA MODELS SE REPITAN. DEJAR LAS ACTUALES Y NO BORRAR LA CLASE ERRORVIEWMODEL.CS



    https://drive.google.com/file/d/11Q4NTYM9xb5wE_AmHn3YegkllBvxRo4e/view?usp=sharing



Le dan Enter y seguramente les pida instalar los siguientes Packetes Nuget si no los tienen instalados. Usen las versiones que aparecen a continuación:

  https://drive.google.com/file/d/1LwdrHRI8dRdfZ8rxBUPBTUMHCGdtL6F3/view?usp=sharing

Listo.

4-Volver a cargar todos los otros proyectos con click derecho Load project o Cargar proyecto
