select APELLIDOS_NOMBRE from P1_77492686M.dbo.PLANTILLA where APELLIDOS_NOMBRE like 'H%'

-----------------------------------------------------------------------------------------------------------------------------------------------------------

select APELLIDOS_NOMBRE from P1_77492686M.dbo.PLANTILLA where (TURNO = 'M' or TURNO = 'T') and (FUNCION = 'Enfermero' or FUNCION = 'Enfermera')

-----------------------------------------------------------------------------------------------------------------------------------------------------------

select APELLIDOS_NOMBRE,SALARIO from P1_77492686M.dbo.PLANTILLA where SALARIO >= 20000 and SALARIO <= 25000 and FUNCION = 'Enfermera'

-----------------------------------------------------------------------------------------------------------------------------------------------------------

select SUBSTRING(NOMBRE,1,3) as 'ABR',HOSPITAL_COD,NOMBRE from P1_77492686M.dbo.HOSPITAL order by ABR

-----------------------------------------------------------------------------------------------------------------------------------------------------------

select APELLIDOS_NOMBRE, round(SALARIO/12,0) AS 'SALARIO MENSUAL' from P1_77492686M.dbo.PLANTILLA where FUNCION = 'Enfermero' or FUNCION = 'Enfermera'

-----------------------------------------------------------------------------------------------------------------------------------------------------------

select AVG(SALARIO) as 'SALARIO MEDIO' from P1_77492686M.dbo.PLANTILLA where FUNCION = 'Enfermero'

-----------------------------------------------------------------------------------------------------------------------------------------------------------

select MAX(SALARIO) as 'SALARIO MAXIMO', MIN(SALARIO) as 'SALARIO MINIMO', MAX(SALARIO)-MIN(SALARIO) as 'DIFERENCIA' from P1_77492686M.dbo.PLANTILLA

-----------------------------------------------------------------------------------------------------------------------------------------------------------

select FUNCION as PUESTO, AVG(SALARIO) as 'SALARIO MEDIO' from P1_77492686M.dbo.PLANTILLA group by FUNCION

-----------------------------------------------------------------------------------------------------------------------------------------------------------

select FUNCION as PUESTO, COUNT(FUNCION) as NUMERO from P1_77492686M.dbo.PLANTILLA group by FUNCION

-----------------------------------------------------------------------------------------------------------------------------------------------------------

select 
	hospital.NOMBRE as 'HOSPITAL',  
	sala.NOMBRE as 'SALA',
	plantilla.FUNCION,
	plantilla.APELLIDOS_NOMBRE
from P1_77492686M.dbo.HOSPITAL hospital
inner join SALA sala on hospital.HOSPITAL_COD = sala.HOSPITAL_COD
inner join PLANTILLA plantilla on sala.HOSPITAL_COD = plantilla.HOSPITAL_COD and sala.SALA_COD = plantilla.SALA_COD
order by hospital.NOMBRE,sala.NOMBRE, plantilla.FUNCION, plantilla.APELLIDOS_NOMBRE

-----------------------------------------------------------------------------------------------------------------------------------------------------------

update P1_77492686M.dbo.PLANTILLA
set FUNCION = 'Enfermero'
where LOWER(FUNCION) = 'enfermo'

select HOSPITAL_COD, SALA_COD, EMPLEADO_NO, APELLIDOS_NOMBRE, FUNCION, TURNO, SALARIO from P1_77492686M.dbo.PLANTILLA

-----------------------------------------------------------------------------------------------------------------------------------------------------------

update P1_77492686M.dbo.HOSPITAL
set NUM_CAMA = NUM_CAMA + floor(NUM_CAMA*10/100)

select HOSPITAL_COD, NOMBRE, DIRECCION, TELEFONO, NUM_CAMA from P1_77492686M.dbo.HOSPITAL

-----------------------------------------------------------------------------------------------------------------------------------------------------------

