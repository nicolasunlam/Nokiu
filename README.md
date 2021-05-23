# Nokiu

## Pasos para deploy del proyecto y conectarse al Repositorio 

1-Clonar el proyecto con Visual Studio 2019

2-Abrir la solución y desde VS => Extensiones, instalar Github. Seguir los pasos, reiniciar si es necesario.
  video de Referencia https://youtu.be/560GOf3f6xk

3- Para conectar con la DB desde VS con EntityFramework:

​		-Click derecho en el proyecto y luego click en unload o (descargar ESP). En todos excepto en 			Nokiu.Entities

​			![image-20210523123417032](C:\Users\Usuario\AppData\Roaming\Typora\typora-user-images\image-20210523123417032.png)

-Luego abrir la consola de Administracion de paquetes Nuget

![image-20210523123720750](C:\Users\Usuario\AppData\Roaming\Typora\typora-user-images\image-20210523123720750.png)

Si tienen autorización con Windows en su SQL Server tienen que introducir la sentencia :

Scaffold-DBContext "Server=Tu_Server;Database=Nokiu;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

## ATENCIÓN: PUEDE SER QUE AL MAPPEAR CON LA DB ALGUNAS CLASES EN LA CARPETA MODELS SE REPITAN. DEJAR LAS ACTUALES Y NO BORRAR LA CLASE ERRORVIEWMODEL.CS



![image-20210523124230968](C:\Users\Usuario\AppData\Roaming\Typora\typora-user-images\image-20210523124230968.png)



Le dan Enter y seguramente les pida instalar los siguientes Packetes Nuget si no los tienen instalados. Usen las versiones que aparecen a continuación:

![image-20210523124406095](C:\Users\Usuario\AppData\Roaming\Typora\typora-user-images\image-20210523124406095.png)

Listo.

4-Volver a cargar todos los otros proyectos con click derecho Load project o Cargar proyecto