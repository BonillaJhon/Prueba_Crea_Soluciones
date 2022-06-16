--reporte 1

CREATE DATABASE PRUEBASQL
use PRUEBASQL
CREATE TABLE CIUDAD
(
Id int not null ,
Nombre varchar (50) 
constraint PK_ID_CIUDAD  Primary key (Id)
)

use PRUEBASQL
CREATE TABLE CLIENTE

(
Id int not null ,
primer_nombre varchar (50),
primer_apellido varchar (50),
dias_mora int ,
id_ciudad int
constraint PK_ID_CLIENTE  Primary key (Id)
foreign key (ID_CIUDAD) references CIUDAD (Id)
)


///////////////////////////////////


select CLIENTE.Id as cedula, CLIENTE.primer_nombre + CLIENTE.primer_apellido  as nombre, CLIENTE.dias_mora as diasEnMora ,
case 
when dias_mora between 1 and 20 then 'Riesgo Bajo'
when dias_mora between 21 and 35 then 'Riesgo Medio'
when dias_mora > 35  then 'Riesgo Alto'
end as riesgo, CIUDAD.Nombre AS CIUDAD  from CLIENTE
inner join CIUDAD
on CLIENTE.id_ciudad = CIUDAD.Id
ORDER BY dias_mora ASC


////////////////////////////////


--reporte 2 

CREATE DATABASE Reporte_dos



CREATE TABLE SUCURSAL
(
ID INT not null ,
NOMBRE VARCHAR (50) 
constraint PK_ID_SUCURSAL  Primary key (Id)
)
GO
CREATE TABLE COTIZACION
(
ID INT not null ,
VALOR_POLIZA_IVA_INCL DECIMAl(10,2),
VALOR_POLIZA INT,
VALOR_POLIZA_CUOTA INT,
ID_SUCURSAL INT
constraint PK_ID_COTIZACION  Primary key (Id)
foreign key (ID_SUCURSAL) references SUCURSAL (Id)
)
GO
/*     ************************                  */
 
 SELECT SUCURSAL.
 NOMBRE AS SUCURSAL ,
 CONVERT (decimal(10,0), COTIZACION.VALOR_POLIZA_IVA_INCL ) AS VALORTOTALPAGADO 
 FROM COTIZACION 
 inner join SUCURSAL ON COTIZACION.ID_SUCURSAL = SUCURSAL.ID 
 ORDER BY VALOR_POLIZA_IVA_INCL DESC 
 

 

 /*     ************************                  */

 --Reporte 3 

 CREATE DATABASE reporte_tres
use reporte_tres
CREATE TABLE PERSONA
(
CC int not null ,
Nombre varchar (50),
APELLIDO varchar (50) 
constraint PK_ID_PERSONA  Primary key (CC)
)

use reporte_tres
CREATE TABLE ESTUDIOS

(
Id int not null ,
INSTITUCION varchar (50),
FECHA DATETIME ,
FKPERSONA int 
constraint PK_ID_ESTUDIOS  Primary key (Id)
foreign key (FKPERSONA) references PERSONA (CC)
)
/*     ************************                  */


Select * from PERSONA
Select max(ESTUDIOS.FECHA)as FECHA ,FKPERSONA from ESTUDIOS group by FKPERSONA

SELECT 
PERSONA.CC AS CC , 
PERSONA.Nombre + PERSONA.APELLIDO AS NOMBRE , 
ESTUDIOS.INSTITUCION AS INSTITUCION, 
ESTUDIOS.FECHA AS FECHA
FROM PERSONA
inner join ESTUDIOS on ESTUDIOS.FKPERSONA=PERSONA.CC
inner join (Select max(ESTUDIOS.FECHA)as FECHA ,FKPERSONA from ESTUDIOS group by FKPERSONA) p on p.FKPERSONA=ESTUDIOS.FKPERSONA and p.FECHA=ESTUDIOS.FECHA
ORDER BY FECHA DESC 



/*     ************************                  */

 --Reporte 4 
 CREATE DATABASE REPORTE_CUATRO
 USE REPORTE_CUATRO
 CREATE TABLE EMPLEADO
 (
 CC INT NOT NULL PRIMARY KEY,
 NOMBRE VARCHAR (50),
 CARGO VARCHAR (50),
 AREA VARCHAR (50),
 ID_JEFE INT,
 CONSTRAINT JEFE_FK FOREIGN KEY (ID_JEFE) REFERENCES EMPLEADO(CC)
 );

 /*     ************************                  */

 SELECT T1.CC AS CC, T1.NOMBRE AS NOMBRE ,T1.CARGO AS CARGO , T2.NOMBRE AS NOMBREJEFE
 FROM EMPLEADO T1
 INNER JOIN EMPLEADO T2
 ON T2.CC = T1.ID_JEFE
 
 


