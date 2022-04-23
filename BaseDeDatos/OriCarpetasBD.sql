
use Master;
GO
IF EXISTS (SELECT * FROM SysDataBases WHERE NAME='ESTUDIOSORI')
BEGIN
	DROP DATABASE ESTUDIOSORI
END

GO
CREATE DATABASE ESTUDIOSORI
ON
(
	NAME=ESTUDIOSORI,
	FILENAME='C:\Ori2\ESTUDIOSORI.mdf'
) 
GO

Use ESTUDIOSORI
GO

CREATE TABLE Paciente                   
( 
Id int not null PRIMARY KEY Identity,
Nombre varchar(20) not null,
Apellido varchar(20) not null,
Telefono varchar(20) not null,
Celular int not null,
FechaDeNac Date not null,
Activo bit not null,
)
go

CREATE TABLE Odontologo                  
( 
Id int not null primary key Identity,
Nombre varchar(20),
Apellido varchar(20),
Telefono varchar(20) ,
Celular int ,
Ciudad varchar(20) ,
Email varchar(20) ,
horario varchar(20) ,
Activo bit not null
)
go

select * from 
create TABLE DireccionesOdontologo
(
Id int not null primary key identity,
IdOdontologo int not null,
Direccion varchar(40)
Foreign Key(IdOdontologo) references Odontologo(Id),
)
go

CREATE TABLE Empleado                  
( 
Id int not null primary key Identity,
Nombre varchar(20) not null,
Apellido varchar(20) not null,
Telefono varchar(20) not null,
Celular int not null,
usename varchar(20) not null,
pass varchar(20) not null,
tipo varchar(5),
activo bit
)
go



CREATE TABLE Carpeta                
(
Factura	varchar(20) not null primary key, 
Tipo varchar(20),
FechaPrometida Date,
FechaRealizada Date,
Clinica varchar(20),
Cerrada bit,
CerradaPor varchar(20),
EntregadoA varchar(20),
Observaciones varchar(20),
IdPaciente int not null,
IdOdontologo int not null,
DireccionDeEnvio varchar(40),

Enviada bit,
Retirada bit,
DireccionOPersona varchar(40),

Foreign Key(IdPaciente) references Paciente(Id),
Foreign Key(IdOdontologo) references Odontologo(Id),

Activo bit not null
)
go

CREATE TABLE Tomografia             
(
Id int not null primary key identity,
Factura varchar(20) not null,
Orden varchar(40) not null,
Impresiones int not null,
Informe bit not null,
SinInforme bit,
Cds int ,
Patologia varchar(40),
TomadaPor int,
InformadaPor int,
ChequeadaPor int,
FechaRealizado date not null,
FechaPrometida date not null,
Cerrada bit,
CerradaPor int,
Cs3dImagingSoft bit,
ImplantViewer bit,
InVivoSoft bit,
OtroSoftware  varchar(20),	
Foreign Key(Factura) references Carpeta(Factura),
Foreign Key(TomadaPor) references Empleado(Id),
Foreign Key(CerradaPor) references Empleado(Id),
Foreign Key(InformadaPor) references Empleado(Id),
Activo bit not null
)
go  

CREATE TABLE Span          
(
Id int primary key identity,
Factura varchar(20) not null,
FechaRealizado date not null,
FechaPrometido date not null,		
SinOpt bit not null,		
Rb bit not null,	      
Mc bit not null,			   
Oli bit not null,				
Bj bit not null,			
Pow bit not null,		
Quir bit not null,		
Trevisi bit not null,			
Hold bit not null,		
Harv bit not null,		
Sch bit not null,		
Rick bit not null,				
FotoDig	bit not null,	
TipoFotoDig varchar(20),
IdentikitComentarios varchar(20),	
Cd bit not null,
Cerrado bit not null,
CerradaPor int,
Foreign Key(Factura) references Carpeta(Factura),
Foreign Key(CerradaPor) references Empleado(Id),
Activo bit not null
)
go


CREATE TABLE NemoDocViewer          
(
Id int primary key identity,
Factura varchar(10) not null,
FechaRealizado date not null,
FechaPrometido date not null,			
Nemo bit not null,
DocViewer bit not null,		
Roth bit not null,	      
Ayala bit not null,
PconTrat bit not null,
PsinTrat bit not null,
VisEst bit not null,
Rb bit not null,
Mc bit not null,		   
Oli bit not null,				
Bj bit not null,			
Pow bit not null,		
Quir bit not null,		
Trevisi bit not null,
Hold bit not null,
Harv bit not null,
Sch bit not null,
Rick bit not null,				
FotoDigital	bit not null,	
TipoDeFotoDig varchar(20),
IdentikitComentarios varchar(20),
CD bit not null,
RickFront bit not null,
Modelo bit not null,
SinOpt bit not null,
Software varchar(20),
Observaciones varchar(100),
Cerrado bit not null,
cerradoPor int not null,
Activo bit not null

)
go

CREATE TABLE Oxi
(
Id int primary key Identity,
Factura varchar(20) not null,
FechaRealizado date not null,
FechaPrometido date not null,
Cd bit not null,
Opt123 bit not null,
Informe bit not null,
Impresion bit not null,
Cerrada bit not null,
CerradaPor int,
Activo bit not null,
Foreign Key(Factura) references Carpeta(Factura),
Foreign Key(CerradaPor) references Empleado(Id)
)
go

CREATE TABLE Modelo
(
Id int not null primary key identity,
Factura varchar(20) not null,
Clinica varchar(10) not null,
FechaRealizado date not null,
FechaPrometido date not null,	
ModeloYMedio bit not null,
EstudioDeModelo bit not null,
PlacaBase bit not null,
ParaArticulador bit not null,
Laboratorio varchar(20),
Observaciones varchar(40),
TieneFotos bit,
Cerrada bit,
CerradaPor int,
Activo bit not null,
Foreign Key(Factura) references Carpeta(Factura),
Foreign Key(CerradaPor) references Empleado(Id)
)
go

CREATE TABLE FotografiaEstudio
(
Id int primary key identity,
Factura varchar(20) not null,
FechaRealizado date not null,
FechaPrometido date not null,
FrentePerfilSonrisa bit not null,
Intrabucal bit not null,
OerJetYOverBite bit not null,
Submenton bit not null,
LimpioPor int not null,
EmplantilladoPor int not null,
ImpresoPor int not null,
Cerrado bit,
CerradoPor int not null,
Activo bit not null,
Foreign Key(Factura) references Carpeta(Factura),
Foreign Key(CerradoPor) references Empleado(Id),
Foreign Key(LimpioPor) references Empleado(Id),
Foreign Key(EmplantilladoPor) references Empleado(Id),
Foreign Key(ImpresoPor) references Empleado(Id)
)
go

--CREATE TABLE Fotos
--(
--Id int primary key identity,
--Ruta varchar(40) not null,
--FotoChica image not null,
--FotoGrande image not null
--)
go

CREATE TABLE Fotos
(
Id int primary key identity,
FotoGrande image not null,
FotoChica image not null
)
go

CREATE TABLE FotosDeModelos
(
Id int primary key identity,
FotoChica image not null,
FotoGrande image not null,
)
go

CREATE TABLE FotosFotografiaEsts
(
Id int primary key identity,
IdFoto int not null,
IdFotografiaEst int not null,
Foreign Key(IdFoto) references Fotos(Id),
Foreign Key(IdFotografiaEst) references FotografiaEstudio(Id),
Activo bit not null
)
go

CREATE TABLE FotosModelos
(
Id int primary key identity,
IdFoto int not null,
IdModelo int not null,
Foreign Key(IdFoto) references FotosDeModelos(Id),
Foreign Key(IdModelo) references Modelo(Id),
Activo bit not null
)
go

CREATE TABLE Rutas
(
id int primary key identity,
ruta varchar(200),
tipo int, --1 acces cordon, 2 acces pocitos
)
go

--CARPETA


create proc BuscarCarpeta 
@factura varchar(10)
as
Begin
	Select * from Carpeta 
	where factura=@factura and Activo=1
End
go


-- PROCEDIMIENTOS



create proc AgregarCarpeta			--AGREGAR CARPETA
@fac varchar(20),
@tipo varchar(20),
@fecProm date,
@fecReal date,
@cli varchar(20),
@cerr bit,
@cerrpor varchar(20),
@entreg varchar(20),
@obs varchar(20),
@pac int,
@odo int,
@dir varchar(40)
as
Begin
if(not exists(select * from Carpeta where Factura=@fac))
					insert into Carpeta values(@fac,@tipo,@fecProm,@fecReal,@cli,@cerr,@cerrpor,@entreg,@obs,@pac,@odo,@dir,0,0,'',1)
				 
End
go

create proc AgregarCarpeta2			--AGREGAR CARPETA
@fac varchar(20),
@tipo varchar(20),
@fecProm date,
@fecReal date,
@cli varchar(20),
@cerr bit,
@cerrpor varchar(20),
@entreg varchar(20),
@obs varchar(20),
@pacnom varchar(20),
@pacape varchar(20),
@odoape varchar(20),
@odonom varchar(20),
@odociu varchar(20),
@ododir varchar(20),
@odomail varchar(20),
@odotel varchar(20)
as
Begin
begin transaction

		if not exists(select * from Odontologo where Nombre=@odonom and Apellido=@odoape)
		insert into Odontologo values(@odonom,@odoape,@odotel,0,@odociu,@odomail,'sin horario',1)
	
	if @@ERROR<>0
	rollback transaction
	
	
		declare @idodo int
		select @idodo=Odontologo.Id from Odontologo where Odontologo.Nombre=@odonom and Odontologo.Apellido=@odoape

	if @@ERROR<>0
	rollback transaction
	
		if not exists(select * from Paciente where Nombre=@pacnom and Apellido=@pacape)
		insert into Paciente values(@pacnom,@pacape,0,0,'1/1/1900',1)

	if @@ERROR<>0
	rollback transaction

		declare @idpac int
		select @idpac=Paciente.Id from Paciente where Nombre=@pacnom and Apellido=@pacape
		
	if @@ERROR<>0
	rollback transaction

		if not exists (select * from Carpeta where Factura=@fac)
		insert into Carpeta values (@fac,@tipo,@fecProm,@fecReal,@cli,@cerr,@cerrpor,@entreg,@obs,@idpac,@idodo,'',0,0,'',1)
		
commit transaction			 
End
go

Create proc ModificarCarpeta
@fac varchar(20),
@tipo varchar(20),
@fecProm date,
@fecReal date,
@cli varchar(20),
@cerr bit,
@cerrpor varchar(20),
@entreg varchar(20),
@obs varchar(20),
@pac int,
@odo int,
@dir varchar(40)
as
Begin
if(exists(select * from Carpeta where Factura=@fac))
 update Carpeta set Tipo=@tipo,FechaPrometida=@fecProm,FechaRealizada=@fecReal,Clinica=@cli,Cerrada=@cerr,CerradaPor=@cerrpor,EntregadoA=@entreg,Observaciones=@obs,IdPaciente=@pac,IdOdontologo=@odo,DireccionDeEnvio=@dir
				 
End
go

create proc EliminarCarpeta
@fac varchar(20)
as
begin
if(exists(select * from Carpeta where Factura=@fac))
	begin
		if(not exists(select * from Tomografia where Factura=@fac))
		begin
			if(not exists(select * from Span where Factura=@fac))
			begin
				if(not exists(select * from NemoDocViewer where Factura=@fac))
				begin
					if(not exists(select * from oxi where Factura=@fac))
						begin
							if(not exists(select * from Modelo where Factura=@fac))
							begin
								delete from Carpeta where Factura=@fac
							end
							else return 1
						end
					else return 1
				end
				else return 1
			end
			else return 1
		end
		else return 1
	end	
else return 2
end
go


--estadisticas
create proc ContarCarpetasXAnioMes

	@anio int,
	@mes int
	
as
begin

		select COUNT(Carpeta.Factura) as 'cuenta' from Carpeta where (YEAR(FechaRealizada))=@anio and (MONTH(FechaRealizada))=@mes
end
go


create proc ListarEnviosPendientes
@Tipo varchar(20),
@Entregado varchar(20)
as
begin
select * from Carpeta where Cerrada=1 and Enviada=0 and Retirada=0 and Tipo=@Tipo and EntregadoA=@Entregado and FechaPrometida<=SYSDATETIME()
end
go



create proc ListarRetirosPendientes
AS
begin
select * from Carpeta where Cerrada=1 and Retirada=0 and Tipo='Retira Cordon' or Tipo='Retira Pocitos'
end
go

create proc ModificarEnviasRetiras
@fac varchar(20),
@paciente varchar(20),
@env bit,
@ret bit,
@diropers varchar(40)
as
begin
declare @idpac int
begin transaction
select @idpac=Paciente.Id from Paciente inner join Carpeta 
on Carpeta.IdPaciente=Paciente.Id
where Carpeta.Enviada=0 and Carpeta.Retirada=0 and Factura=@fac
				if @@ERROR<>0
				begin
				
						rollback transaction
						return -1
				end
update Carpeta set Enviada=@env,Retirada=@ret,DireccionOPersona=@diropers 
where Carpeta.IdPaciente=@idpac and Carpeta.Factura=@fac
				if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
commit transaction
return 1
end				
go


--EMPLEADO


create proc BuscarEmpleado   --BUSCAR EMPLEADO POR USUARIO Y CONTRASEÑA
@user varchar(20),
@pass varchar(20)
as
Begin
	Select * from Empleado 
	where usename=@user and pass=@pass
End
go


create proc BuscarEmpleadoPorId   --BUSCAR EMPLEADO POR ID
@id int
as
Begin
	Select * from Empleado 
	where Id=@id
End
go

create proc BuscarEmpleados
@tipo varchar(20)
as
begin
 select * from Empleado where tipo=@tipo
end
go


create proc BuscarEmpleadosPorNombre
@nombre varchar(20)
as
begin
 select * from Empleado where Nombre like @nombre+'%'
end
go

create proc BuscarEmpleadosPorApellido
@apellido varchar(20)
as
begin
 select * from Empleado where Apellido like @apellido+'%'
end
go

create proc AgregarEmpleado   --AGREGAR EMPLEADO
@nom varchar(20),
@ape varchar(20),
@tel int,
@cel int,
@user varchar(30),
@pass varchar(20),
@tipo varchar(1)
as
Begin
if(exists(select * from Paciente where Nombre=@nom and Apellido=@ape))
	return 1 --ya existe un empleado con ese nombre y/o apellido
else if(exists(select * from Empleado where Empleado.usename=@user and Empleado.pass=@pass))
	return 2 --ya existe un empleado con ese nombre de usuario y/o contraseña
else
	insert into Empleado values(@nom,@ape,@tel,@cel,@user,@pass,@tipo,1)

End
go

create proc EliminarEmpleado   --ELIMINAR EMPLEADO
@id int
as
Begin
	if(not exists(select * from Empleado inner join Carpeta
	on Carpeta.CerradaPor=Empleado.Id 
	where Id=@id))
		delete Empleado where Id=@id
	else 
		return 2
End
go

create proc ModificarEmpleado   --AGREGAR EMPLEADO
@id int,
@user varchar(30),
@pass varchar(20),
@nom varchar(20),
@ape varchar(20),
@tel varchar(20),
@cel int,
@tipo varchar(20)
as
Begin
if(exists(select * from Empleado where Id=@id))
	update Empleado set Nombre=@nom,Apellido=@ape,Telefono=@tel,Celular=@cel,usename=@user,pass=@pass,tipo=@tipo
	where Id=@id
else
	return 1 --no existe el empleado
End
go


--ODONTOLOGO


create proc BuscarOdontologos 
as
Begin
	Select * from Odontologo 
	
End
go

create proc BuscarOdontologo 
@apellido varchar(20),
@nombre varchar(20)
as
Begin
	Select * from Odontologo 
	where apellido=@apellido and nombre=@nombre
End
go

create proc BuscarOdontologoPorId
@Id int
as
Begin
	select * from Odontologo where Id=@Id
End
go

create proc BuscarOdontologosPorNombre
@nombre varchar(20)
as
Begin
select * from Odontologo where Nombre like @nombre+'%'
End
go



create proc BuscarOdontologosPorApellido
@apellido varchar(20)
as
Begin
select * from Odontologo where Apellido like @apellido+'%'
End
go

create proc BuscarOdontologosPorTelefono
@tel varchar(20)
as
Begin
select * from Odontologo where Telefono like @tel+'%'
End
go

create proc BuscarOdontologosPorCelular
@cel int
as
Begin
select * from Odontologo where Celular like @cel+'%'
End
go

create proc AgregarOdontologo   --AGREGAR ODONTOLOGO
@nom varchar(20),
@ape varchar(20),
@tel varchar(20),
@cel int,
@hor varchar(20),
@email varchar(20),
@ciudad varchar(20)
as
Begin 			
	insert into Odontologo values(@nom,@ape,@tel,@cel,@ciudad,@email,@hor,1)
End
go

create proc AgregarDireccion  --AGREGAR DIRECCION DE ODONTOLOGO
@nom varchar(20),
@ape varchar(20),
@ciu varchar(20),
@dir varchar(40)
as
Begin
declare @id int
if(not exists(select * from DireccionesOdontologo inner join Odontologo 
on DireccionesOdontologo.IdOdontologo=Odontologo.Id
where Odontologo.Nombre=@nom and Odontologo.Apellido=@ape and Odontologo.Ciudad=@ciu
and DireccionesOdontologo.Direccion=@dir))
	begin
		select @id=Odontologo.Id from Odontologo where Odontologo.Nombre=@nom and Odontologo.Apellido=@ape and Odontologo.Ciudad=@ciu
		insert into DireccionesOdontologo values(@id,@dir)
	end
End

go

create proc AgregarDireccionAccess
@nom varchar(20),
@ape varchar(20),
@ciu varchar(20),
@dir varchar(20)
as
begin
declare @id int
select * from DireccionesOdontologo	
		select @id=Odontologo.Id from Odontologo where Odontologo.Nombre=@nom and Odontologo.Apellido=@ape and Odontologo.Ciudad=@ciu
		insert into DireccionesOdontologo values(@id,@dir)	
end
go

create proc BuscarDirecciones
@id int
as
Begin
select * from DireccionesOdontologo where IdOdontologo=@id
end
go

create proc modificarOdontologo   --MODIFICAR ODONTOLOGO
@id int,
@nom varchar(20),
@ape varchar(20),
@tel varchar(20),
@cel int,
@hor varchar(20),
@email varchar(20),
@ciudad varchar(20)
as
Begin
if(exists(select * from Odontologo where Id=@Id))
	Update Odontologo set Nombre=@nom, Apellido=@ape, Telefono=@tel, Celular=@cel, horario=@hor, Ciudad=@ciudad, Email=@email
	where Id=@id
else
	return 1 --no existe el odontologo
End
go

create proc eliminarOdontologo   --ELIMINAR ODONTOLOGO
@id int
as
Begin
if(not exists(select * from Odontologo where Id=@id))
	return 3
else
	begin
		if(not exists(select * from Odontologo inner join Carpeta on Carpeta.IdOdontologo=Odontologo.Id where Id=@id))
		begin
			begin transaction
				delete from DireccionesOdontologo where IdOdontologo=@id
				if @@ERROR<>0
				begin
																
						rollback transaction
						return -1
				end
				delete from Odontologo where Id=@id
				if @@ERROR<>0
				begin
				
						rollback transaction
						return -1
				end
				commit transaction
		end	
		else
			return 2 
	end	
end
go
	
create proc ListarOdontologos
as
Begin
select * from Odontologo
end
go


--PACIENTE

create proc BuscarPacientesPorNomyApe
@Apellido varchar(20),
@Nombre varchar(20)
as
Begin
	Select * from Paciente where Apellido=@Apellido and Nombre=@Nombre
	
End
go

create proc Buscar20Pacientes 
as
Begin
	Select top 20 * from Paciente order by Id desc
	
End
go

create proc Buscar60Pacientes 
as
Begin
	Select top 60 * from Paciente order by Id desc
	
End
go


create proc BuscarUltimoPacienteSql
as
Begin
	Select top 1 * from Paciente order by Id desc
End
go

create proc BuscarPacientePorId  --BUSCAR PACIENTE POR FACTURA 
@Id int
as
Begin
	Select * from Paciente where Id=@Id
End
go

create proc BuscarPacientePorFactura  --BUSCAR PACIENTE POR FACTURA 
@factura varchar(20)
as
Begin
	Select * from Paciente inner join Carpeta
	on Paciente.Id = Carpeta.IdPaciente
	where Carpeta.Factura=@factura
End
go

create proc AgregarPaciente   --AGREGAR PACIENTE
@nom varchar(20),
@ape varchar(20),
@tel int,
@cel int,
@fechaDeNac date
as
Begin
	insert into Paciente values(@nom,@ape,@tel,@cel,@fechaDeNac,1)
End
go

create proc BuscarPacientesPorNombre
@nombre varchar(20)
as
Begin
	select * from Paciente where Nombre like @nombre+'%'
End
go

create proc BuscarPacientesPorApellido
@apellido varchar(20)
as
Begin
	select * from Paciente where Apellido like @apellido +'%'
End
go

create proc modificarPaciente   --MODIFICAR PACIENTE
@id int,
@nom varchar(20),
@ape varchar(20),
@tel int,
@cel int,
@fechaDeNac datetime
as
Begin
if(exists(select * from Paciente where Id=@Id))
   update Paciente set Nombre=@nom,Apellido=@ape,Telefono=@tel,Celular=@cel,FechaDeNac=@fechaDeNac
   where Id=@id

else
	return 1 -- no existe el paciente
End
go


create proc EliminarPaciente
@id int
as
Begin
if(exists(select * from Paciente where Id=@id))
	if(exists(select * from Paciente inner join Carpeta on Paciente.Id=Carpeta.IdPaciente where Id=@id))
		return 2 -- no se puede, pertenece a una carpeta
	else
		delete from Paciente where Id=@id;
else
	return 1 --no existe el paciente
End
go

create proc ListarPacientes
as
Begin
select * from Paciente where Activo=1
end
go


--OXI


create proc BuscarOxi
@factura varchar(20)
as
Begin
	Select * from Oxi 
	where Oxi.Factura=@factura
End
go

create proc AgregarOxi  --AGREGAR OXI
@fac varchar(10),
@fechaRealizado datetime,
@fechaPrometido datetime,
@cd bit,
@opt123 bit,
@informe bit,
@impresion bit,
@cerrada bit,
@cerradaPor int
as
Begin
	insert into Oxi values(@fac,@fechaRealizado,@fechaPrometido,@cd,@opt123,@informe,@impresion,@cerrada,@cerradaPor,1)
End
go


create proc EliminarOxi   --ELIMINAR OXI
@id int 
as
Begin
if(exists(select * from Oxi where Id=@id))
	delete from Oxi where id=@id
else
	return 1 -- no existe la oxi
End
go

create proc ListarOxisPendientes
as
begin
select * from Oxi inner join Carpeta
on Oxi.Factura=Carpeta.Factura
where Oxi.Activo=1 and Oxi.Cerrada=0
end
go

create proc ModificarOxi
@Factura varchar(20),
@FechaRealizado date,
@FechaPrometido date,
@Cd bit,
@Opt123 bit,
@Informe bit,
@Impresion bit,
@Cerrada bit,
@CerradaPor int
as
begin
update Oxi set Oxi.FechaRealizado=@FechaRealizado,
				Oxi.FechaPrometido=@FechaPrometido,
				oxi.Cd=@Cd,
				oxi.Opt123=@Opt123,
				oxi.Informe=@Informe,
				oxi.Impresion=@Impresion,
				oxi.Cerrada=@Cerrada,
				oxi.CerradaPor=@CerradaPor
where Oxi.Factura=@Factura
end 
go


--TOMOS


create proc BuscarTomografia		--BUSCAR TOMOGRAFIA
@factura varchar(20)
as
Begin
	Select * from Tomografia 
	where Tomografia.Factura=@factura
End
go


create proc AgregarTomografia   --AGREGAR TOMOGRAFIA
@orden varchar(40),
@impresiones int,
@informe bit,
@sinInforme bit,
@cds int,
@patologia varchar(20),
@tomadaPor int,
@informadaPor int,
@chequeadaPor int,
@fechaRealizado datetime,
@fechaPrometido datetime,
@cerrada bit,
@cerradaPor int,
@factura varchar(20),
@cs3d bit,
@implant bit,
@inVivo bit,
@otroSoft varchar(30)
as
Begin
insert into Tomografia values(@factura,@orden,@impresiones,@informe,@sinInforme,@cds,@patologia,@tomadaPor,@informadaPor,@chequeadaPor,@fechaRealizado,@fechaPrometido,@cerrada,@cerradaPor,@cs3d,@implant,@inVivo,@otroSoft,1)
End
go

create proc ModificarTomografia    --MODIFICAR TOMOGRAFIA
@factura varchar(10),
@fechaRealizado datetime,
@fechaPrometida datetime,
@tomadaPor int,
@informadaPor int,
@chequeadaPor int,
@orden varchar(40),
@impresiones int,
@informe bit,	
@patologia varchar(40),
@cds integer,
@sinInforme bit,
@cerrada bit,
@cerradaPor int,
@cs3d bit,
@implant bit,
@invivo bit,
@otroSoft varchar(20)
as
Begin
if(exists(select * from Tomografia where Factura=@factura))
update Tomografia set Tomografia.Orden=@orden,
					Tomografia.Impresiones=@impresiones,
					Tomografia.Informe=@informe,
					Tomografia.SinInforme=@sinInforme,
					Tomografia.Cds=@cds,
					Tomografia.Patologia=@patologia,
					Tomografia.TomadaPor=@tomadaPor,
					Tomografia.InformadaPor=@informadaPor,
					Tomografia.ChequeadaPor=@chequeadaPor,
					Tomografia.FechaRealizado=@fechaRealizado,
					Tomografia.FechaPrometida=@fechaPrometida,
					Tomografia.Cerrada=@cerrada,
					Tomografia.CerradaPor=@cerradaPor,
					Tomografia.Cs3dImagingSoft=@cs3d,
					Tomografia.ImplantViewer=@implant,
					Tomografia.InVivoSoft=@invivo,
					Tomografia.OtroSoftware=@otroSoft			   
where Tomografia.Factura=@factura

else
return 1 --no existe la tomografia
End
go

create proc EliminarTomografia   --ELIMINAR TOMOGRAFIA
@idEstudio int
as
Begin
if(exists(select * from Tomografia where Id=@idEstudio))
 delete from Tomografia where Id=@idEstudio
else
	return 1 -- no existe la tomografia
End
go

create proc ListarTomografiasPendientes
as
begin
select * from Tomografia inner join Carpeta
on Tomografia.Factura=Carpeta.Factura 
where Tomografia.Activo=1 and Tomografia.Cerrada=0
end
go
--SPAN


create proc BuscarSpan   -- BUSCAR SPAN
@factura varchar(20)
as
Begin
	Select * from Span 
	where Span.Factura=@factura
End
go

create proc AgregarSpan -- AGREGAR SPAN
@Factura varchar(10),
@FechaRealizado date,
@FechaPrometida date,		
@SinOpt bit,		
@Rb bit,	      
@Mc bit,			   
@Oli bit,				
@Bj bit,			
@Pow bit,		
@Quir bit,		
@Trevisi bit,			
@Hold bit,		
@Harv bit,		
@Sch bit,		
@Rick bit,				
@FotoDig bit,	
@TipoFotoDig varchar(20),
@IdentikitComentarios varchar(20),	
@Cd bit,
@Cerrado bit,
@CerradoPor int
as
Begin
	insert into Span values(@factura,@FechaRealizado,@FechaPrometida,@SinOpt,@Rb,@Mc,@Oli,@Bj,@Pow,@Quir,@Trevisi,@Hold,@Harv,@Sch,@Rick,@FotoDig,@TipoFotoDig,@IdentikitComentarios,@cd,@Cerrado,@CerradoPor,1)
End
go

create proc ModificarSpan  -- MODIFICAR SPAN
@Factura varchar(20),
@FechaRealizado date,
@FechaPrometido date,		
@SinOpt bit,		
@Rb bit,	      
@Mc bit,			   
@Oli bit,				
@Bj bit,			
@Pow bit,		
@Quir bit,		
@Trevisi bit,			
@Hold bit,		
@Harv bit,		
@Sch bit,		
@Rick bit,				
@FotoDig bit,	
@TipoFotoDig varchar(20),
@IdentikitComentarios varchar(20),	
@Cd bit,
@Cerrado bit,
@CerradaPor int
as
Begin

if(exists(select * from Span where Factura=@Factura))
begin
	update Span set Span.FechaRealizado=@FechaRealizado,
					Span.FechaPrometido=@FechaPrometido,
					Span.SinOpt=@SinOpt,
					Span.Rb=@Rb,
					Span.Mc=@Mc,
					Span.Oli=@Oli,
					Span.Bj=@Bj,			
					Span.Pow=@Pow,		
					Span.Quir=@Quir,		
					Span.Trevisi=@Trevisi,			
					Span.Hold=@Hold,		
					Span.Harv=@Harv,		
					Span.Sch=@Sch,		
					Span.Rick=@Rick,				
					Span.FotoDig=@FotoDig,	
					Span.TipoFotoDig=@TipoFotoDig,
					Span.IdentikitComentarios=@IdentikitComentarios,	
					Span.Cd=@Cd,
					Span.Cerrado=@Cerrado,
					Span.CerradaPor=@CerradaPor
where Span.Factura=@Factura
end
else
	return 1 --no existe el span
End
go

create proc EliminarSpan  -- ELIMINAR SPAN
@id int
as
Begin
if(exists(select * from Span where Id=@id))
delete from Span where Id=@id
else
	return 1 --no existe el span
End
GO

create proc ListarSpanPendientes
as
begin
select * from Span inner join Carpeta
on Span.Factura=Carpeta.Factura
where Span.Activo=1 and Span.Cerrado=0
end
go
--NEMO


create proc BuscarNemo
@factura varchar(20)
as
Begin
	Select * from NemoDocViewer
	where NemoDocViewer.Factura=@factura
End
go

create proc AgregarNemo   --AGREGAR NEMO
@factura varchar(20),
@fechaRealizado date,
@fechaPrometido date,				
@nemo bit,
@docViewer bit,		
@roth bit,
@ayala bit,	 
@pconTrat bit,
@psinTrat bit,
@visEst bit,
@rb bit,     
@mc bit,			   
@oli bit,				
@bj bit,			
@pow bit,		
@quir bit,					
@trevisi bit,
@hold bit ,
@harv bit,
@sch bit,
@rick bit,				
@fotoDig bit,	
@tipodeFoto varchar(20),
@identikitComentarios varchar(20),
@cd bit,
@RickFront bit,
@Modelo bit,
@sinOpt bit,
@software varchar(20),
@observaciones varchar(40),
@cerrado bit,
@cerradoPor int
as
Begin
if(not exists(select * from Carpeta where Carpeta.Factura=@factura))
 return 1
else
	begin
		
		insert into NemoDocViewer values(@factura,@fechaRealizado,@fechaPrometido,@nemo,@docViewer,@roth,@ayala,@pconTrat,@psinTrat,@visEst,@rb,@mc,@oli,@bj,@pow,@quir,@trevisi,@hold,@harv,@sch,@rick,@fotoDig,@tipodeFoto,@identikitComentarios,@cd,@RickFront,@Modelo,@sinOpt,@software,@observaciones,@cerrado,@cerradoPor,1)
	end
End
go

create proc ModificarNemo  --MODIFICAR NEMO
@factura varchar(20),
@fechaRealizado date,
@fechaPrometido date,				
@nemo bit,
@docViewer bit,		
@roth bit,
@ayala bit,	 
@pconTrat bit,
@psinTrat bit,
@visEst bit,
@rb bit,     
@mc bit,			   
@oli bit,				
@bj bit,			
@pow bit,		
@quir bit,					
@trevisi bit,
@hold bit ,
@harv bit,
@sch bit,
@rick bit,				
@fotoDig bit,	
@tipodeFoto varchar(20),
@identikitComentarios varchar(20),
@cd bit,
@RickFront bit,
@Modelo bit,
@sinOpt bit,
@software varchar(20),
@observaciones varchar(40),
@cerrado bit,
@cerradoPor int
as
Begin
if(not exists(select * from Carpeta where Carpeta.Factura=@factura))
 return 1
else
	begin	
		UPDATE NemoDocViewer SET 
		NemoDocViewer.factura=@factura,
		NemoDocViewer.FechaRealizado=@fechaRealizado,
		NemoDocViewer.FechaPrometido=@fechaPrometido,
		NemoDocViewer.Nemo=@nemo,
		NemoDocViewer.DocViewer=@docViewer,
		NemoDocViewer.Roth=@roth,
		NemoDocViewer.Ayala=@ayala,
		NemoDocViewer.PconTrat=@pconTrat,
		NemoDocViewer.PsinTrat=@psinTrat,
		NemoDocViewer.VisEst=@visEst,
		NemoDocViewer.Rb=@rb,
		NemoDocViewer.Mc=@mc,
		NemoDocViewer.Oli=@oli,
		NemoDocViewer.Bj=@bj,
		NemoDocViewer.Pow=@pow,
		NemoDocViewer.Quir=@quir,
		NemoDocViewer.Trevisi=@trevisi,
		NemoDocViewer.Hold=@hold,
		NemoDocViewer.Harv=@harv,
		NemoDocViewer.Sch=@sch,
		NemoDocViewer.Rick=@rick,
		NemoDocViewer.FotoDigital=@fotoDig,
		NemoDocViewer.TipoDeFotoDig=@tipodeFoto,
		NemoDocViewer.IdentikitComentarios=@identikitComentarios,
		NemoDocViewer.CD=@cd,
		NemoDocViewer.RickFront=@RickFront,
		NemoDocViewer.Modelo=@Modelo,
		NemoDocViewer.SinOpt=@sinOpt,
		NemoDocViewer.Software=@software,
		NemoDocViewer.Observaciones=@observaciones,
		NemoDocViewer.Cerrado=@cerrado,
		NemoDocViewer.cerradoPor=@cerradoPor
		where NemoDocViewer.Factura=@factura
	end
End

go

create proc EliminarNemo  --ELIMINAR NEMO
@id int
as
Begin
if(exists(select * from NemoDocViewer where Id=@id))
	delete from NemoDocViewer where Id=@id
else
	return 1 -- no existe el nemo
End
go

create proc ListarNemosPendientes
as
begin
select * from NemoDocViewer inner join Carpeta
on NemoDocViewer.Factura=Carpeta.Factura
where NemoDocViewer.Activo=1 and NemoDocViewer.Cerrado=0
end
go
--MODELO


create proc BuscarModelo -- BUSCAR MODELO
@factura varchar(20)
as
Begin
	Select * from Modelo
	where Modelo.Factura=@factura
End
go

create proc AgregarModelo  --AGREGAR MODELO
@factura varchar(20),
@clinica varchar(10),
@fechaRealizado date,
@fechaPrometido date,	
@modeloYMedio bit,
@estudioDeModelo bit,
@placaBase bit,
@paraArticulador bit,
@laboratorio varchar(20),
@observaciones varchar(40),
@tieneFotos bit,
@cerrada bit,
@cerradaPor int
as
Begin
if(not exists(select * from Modelo where Factura=@factura))
begin
	insert into Modelo values(@factura,@clinica,@fechaRealizado,@fechaPrometido,@modeloyMedio,@estudioDeModelo,@placaBase,@paraArticulador,@laboratorio,@observaciones,@tieneFotos,@cerrada,@cerradaPor,1)
end
else
	return 1 --ya existe un modelo ingresado
End
go

create proc modificarModelo  --MODIFICAR MODELO
@factura varchar(20),
@clinica varchar(10),
@fechaRealizado date,
@fechaPrometido date,	
@modeloYMedio bit,
@estudioDeModelo bit,
@placaBase bit,
@paraArticulador bit,
@laboratorio varchar(20),
@observaciones varchar(40),
@tieneFotos bit,
@cerrada bit,
@cerradaPor int
as
begin
	update Modelo set 
	 Modelo.Clinica=@clinica,
	 Modelo.FechaRealizado=@fechaRealizado,
	 Modelo.FechaPrometido=@fechaPrometido,
	 Modelo.ModeloYMedio=@modeloyMedio,
	 Modelo.EstudioDeModelo=@estudioDeModelo,
	 Modelo.PlacaBase=@placaBase,
	 Modelo.ParaArticulador=@paraArticulador,
	 Modelo.Laboratorio=@laboratorio,
	 Modelo.Observaciones=@observaciones,
	 Modelo.TieneFotos=@tieneFotos,
	 Modelo.Cerrada=@cerrada,
	 Modelo.CerradaPor=@cerradaPor,
	 Modelo.Activo=1
	 
	 where Factura=@factura
end
go

create proc EliminarFotosF
@id int
as
begin
delete from FotosFotografiaEsts where FotosFotografiaEsts.IdFotografiaEst=@id
end
go

create proc EliminarModelo	--ELIMINAR MODELO
@id int
as
begin
	delete from Modelo where Id=@id
end
go

create proc ListarModelosPendientes
as
begin
select * from Modelo inner join Carpeta 
on Modelo.Factura=Carpeta.Factura
where Modelo.Activo=1 and Modelo.Cerrada=0
end
go
--FOTOGRAFIAS

create proc AgregarFotografiaEst --AGREGAR ESTUDIO DE FOTOGRAFIAS
@factura varchar(20),
@fechaReal date,
@fechaProm date,
@frentePerfilSonrisa bit,
@intrabucal bit,
@overs bit,
@submenton bit,
@limpiadoPor int,
@emplantilladoPor int,
@impresoPor int,
@cerrado bit,
@cerradoPor int
as
begin select * from FotosFotografiaEsts
 if(not exists(select * from FotografiaEstudio where Factura=@factura))
	begin
		Insert into FotografiaEstudio values(@factura,@fechaReal,@fechaProm,@frentePerfilSonrisa,@intrabucal,@overs,@submenton,@limpiadoPor,@emplantilladoPor,@impresoPor,@cerrado,@cerradoPor,1)
		return 1 --se ingreso correctamente
	end
 else
	return 2 --ya se ha ingreso previamente un estudio
end
go

create proc ModificarFotografia
@factura varchar(20),
@fechaReal date,
@fechaProm date,
@frentePerfilSonrisa bit,
@intrabucal bit,
@overs bit,
@submenton bit,
@limpiadoPor int,
@emplantilladoPor int,
@impresoPor int,
@cerrado bit,
@cerradoPor int
as
begin


		update FotografiaEstudio set 
		FotografiaEstudio.FechaRealizado=@fechaReal,
		FotografiaEstudio.FechaPrometido=@fechaProm,FotografiaEstudio.FrentePerfilSonrisa=@frentePerfilSonrisa,
		FotografiaEstudio.Intrabucal=@intrabucal,
		FotografiaEstudio.OerJetYOverBite=@overs,
		FotografiaEstudio.Submenton=@submenton,
			FotografiaEstudio.LimpioPor=@limpiadoPor,
		FotografiaEstudio.EmplantilladoPor=@emplantilladoPor,
		FotografiaEstudio.ImpresoPor=@impresoPor,
		FotografiaEstudio.Cerrado=@cerrado,
		FotografiaEstudio.CerradoPor=@cerradoPor
		
	
end
go
create proc BuscarFotografiaEst
@factura varchar(20)
as
begin
select * from FotografiaEstudio where Factura=@factura
end
go

create proc BuscarFotografiasPorId
@id int
as
begin 
select * from Fotos inner join FotosFotografiaEsts
on Fotos.Id = FotosFotografiaEsts.IdFoto 
inner join FotografiaEstudio
on FotosFotografiaEsts.IdFotografiaEst=FotografiaEstudio.Id where FotografiaEstudio.Id=@id
end
go


create proc BuscarFotografiasModPorId
@id int
as
begin
select FotosDeModelos.Id,FotosDeModelos.FotoChica,FotosDeModelos.FotoGrande from FotosDeModelos inner join FotosModelos
on FotosDeModelos.Id = FotosModelos.IdFoto 
inner join Modelo
on FotosModelos.IdModelo=Modelo.Id where Modelo.Id=@id
end
go

create proc eliminarFotografia
@idEst int
as
begin
  delete from FotografiaEstudio where Id=@idEst
end
go
--create proc AgregarImagen
--@ruta varchar(40),
--@fotoGrande image,
--@fotoChica image
--as
--begin
--declare @idEstudio int;
--declare @idfoto int
--begin transaction

--	insert into Fotos values(@ruta,@fotoChica,@fotoGrande)
--	 if @@ERROR<>0
--				begin
--						rollback transaction
--						return -1
--				end
	
--	select @idfoto=MAX(Fotos.Id)from Fotos
--	if @@ERROR<>0
--				begin
--						rollback transaction
--						return -1
--				end
--	select @idEstudio=MAX(FotografiaEstudio.Id) from FotografiaEstudio
--	if @@ERROR<>0
--				begin
--						rollback transaction
--						return -1
--				end
	
--	insert into FotosFotografiaEsts values(@idfoto,@idEstudio,1)			
--	if @@ERROR<>0
--				begin
--						rollback transaction
--						return -1
--				end
--commit transaction
--return 1
--end
--go
create proc AgregarImagenConId --para modificar lista de fotos 
@idEstudio int,
@fotogrande image,
@fotochica image 
as
begin

declare @idfoto int
begin transaction

	insert into Fotos values(@fotochica,@fotogrande)
	 if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
	
	select @idfoto=MAX(Fotos.Id)from Fotos
	if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
	
	insert into FotosFotografiaEsts values(@idfoto,@idEstudio,1)			
	if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
commit transaction
return 1
end
go


create proc AgregarImagen
@fotogrande image,
@fotochica image 
as
begin
declare @idEstudio int;
declare @idfoto int
begin transaction

	insert into Fotos values(@fotochica,@fotogrande)
	 if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
	
	select @idfoto=MAX(Fotos.Id)from Fotos
	if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
	select @idEstudio=MAX(FotografiaEstudio.Id) from FotografiaEstudio
	if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
	
	insert into FotosFotografiaEsts values(@idfoto,@idEstudio,1)			
	if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
commit transaction
return 1
end
go

create proc AgregarImagenDeModelo
@fotoGrande image,
@fotoChica image
as
begin
declare @idEstudio int;
declare @idfoto int
begin transaction

	insert into FotosDeModelos values(@fotoChica,@fotoGrande)
	 if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
	
	select @idfoto=MAX(FotosDeModelos.Id)from FotosDeModelos
	if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
	select @idEstudio=MAX(Modelo.Id) from Modelo
				begin
						rollback transaction
						return -1
				end
	
	insert into FotosModelos values(@idfoto,@idEstudio,1)			
	if @@ERROR<>0
				begin
						rollback transaction
						return -1
				end
commit transaction
return 1
end
go

create proc listarFotografiasEstPendientes
as
begin
select * from FotografiaEstudio where FotografiaEstudio.Activo=1 and Cerrado=0
end
go

create proc GuardarRuta
@tipo int,
@ruta varchar(200)
as
Begin
	if not exists(select * from Rutas where tipo=@tipo)
		insert into Rutas values(@ruta,@tipo)
	else
		update rutas set ruta=@ruta,tipo=@tipo
end
go

create proc ObtenerRuta
@tipo int
as
begin 
	select * from Rutas where tipo=@tipo
end
go

DBCC CHECKIDENT (Odontologo, RESEED,0)
DBCC CHECKIDENT (DireccionesOdontologo, RESEED,0)
DBCC CHECKIDENT (Empleado, RESEED,0) 
/*

insert into Odontologo values('Sin','Doctor','0',0,'','','',1)
insert into Odontologo values('Nom_Odontologo_2','Ape_Odontologo_2','111111',09922222,'Rivera','Odon2@gmail.com','de 8:00 a 19hs',1)
insert into Odontologo values('Nom_Odontologo_3','Ape_Odontologo_3','111111',099133333,'Montevideo','Odon3@gmail.com','de 8:00 a 19hs',1)
insert into Odontologo values('Nom_Odontologo_4','Ape_Odontologo_4','111111',099144444,'Tacuarembo','Odon4@gmail.com','de 8:00 a 19hs',1)
insert into Odontologo values('Nom_Odontologo_5','Ape_Odontologo_5','111111',099545454,'Montevideo','Odon5@gmail.com','de 8:00 a 19hs',1)
insert into Odontologo values('Nom_Odontologo_6','Ape_Odontologo_6','111111',099666666,'Montevideo','Odon6@gmail.com','de 8:00 a 19hs',1)

*/
/*
insert into DireccionesOdontologo values(2,'direccion 1')
insert into DireccionesOdontologo values(2,'direccion 111')
insert into DireccionesOdontologo values(3,'direccion 2')
insert into DireccionesOdontologo values(3,'direccion 33')
insert into DireccionesOdontologo values(4,'direccion 4')
insert into DireccionesOdontologo values(5,'direccion 555')
insert into DireccionesOdontologo values(5,'direccion 6')
insert into DireccionesOdontologo values(5,'direccion 666')
*/

--usuario produccion--
insert into Empleado values('Sin','empleado','',0,'sdfdf654d5f','65498efsf','p',1)
insert into Empleado values('Carla','Mato','',0,'cmato','carla99','p',1)
insert into Empleado values('Isaura','Pardo','',0,'ipardo','isaura99','p',1)
insert into Empleado values('Federico','De La fuente','',0,'fdelafuente','federico99','p',1)
insert into Empleado values('Luciana','Jaureguy','',0,'ljaureguy','luciana99','p',1)
insert into Empleado values('Maira','Correa','',0,'mcorrea','maira99','p',1)
insert into Empleado values('Patricia','Costa','',0,'pcosta','patricia99','p',1)
insert into Empleado values('Fernando','Cardozo','',0,'fcardozo','fernando99','p',1)
insert into Empleado values('Victoria','Rostom','',0,'vrostom','victoria99','p',1)
insert into Empleado values('Bayardi','Gustavo','',0,'gbayardi','gustavo99','p',1)
insert into Empleado values('Forgues','Sandra','',0,'sforgues','sandra99','p',1)
insert into Empleado values('Romano','Mathias','',0,'mromano','mathias99','p',1)
insert into Empleado values('Alvarez','Johana','',0,'jalvarez','johana99','p',1)
insert into Empleado values('Techera','Martin','',0,'mtechera','martin99','p',1)
	

--usuarios tomografias--

insert into Empleado values('Pereira','Carla','',0,'cpereira','carla99','t',1)
insert into Empleado values('Torres','Fabiola','',0,'ftorres','fabiola99','t',1)
	
--usuarios administradores	select * from empleado
insert into Empleado values('Admin','Admin','',0,'Admin','admin123','admin',1)

--usuarios odontologos--	
insert into Empleado values('Fagundez','Gustavo','',0,'gfagundez','gustavo99','d',1)
insert into Empleado values('Jaureguy','Richard','',0,'rjaureguy','richard99','d',1)
insert into Empleado values('Cardozo','Matias','',0,'mcardozo','matias99','d',1)
insert into Empleado values('Cabral','Lucia','',0,'lcabral','lucia99','d',1)
insert into Empleado values('Jaureguy','Santiago','',0,'sjaureguy','santiago99','d',1)
insert into Empleado values('Grimberg','Susana','',0,'sgrimberg','susana99','d',1)

--usuarios asistentes--	
insert into Empleado values('Ferreira','Fabiana','',0,'ffereira','fabiana99','a',1)
insert into Empleado values('Gonzalez','Valeria','',0,'vgonzalez','valeria99','a',1)
insert into Empleado values('Ramirez','Silvia','',0,'sramirez','silvia99','a',1)
insert into Empleado values('Kholmanian','Emilia','',0,'ekholmanian','emilia99','a',1)
insert into Empleado values('Martinez','Julieta','',0,'jmartinez','julieta99','a',1)
insert into Empleado values('Carbajal','Claudia','',0,'ccarbajal','claudia','a',1)	

--usuarios recepcion--	
insert into Empleado values('Carnales','Susana','',0,'scarnales','susana99','r',1)
insert into Empleado values('Acosta','Yelena','',0,'yacosta','yelena99','r',1)
insert into Empleado values('Techera','Fabiana','',0,'ftechera','fabiana99','r',1)

--usuarios contabilidad--		
insert into Empleado values('Marella','Adriana','',0,'amarella','adriana99','c',1)
insert into Empleado values('Giusto','Fanny','',0,'fgiusto','fanny99','c',1)

--enero
insert into Carpeta values('c1111','Envia','5/1/15','1/1/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c2222','Envia','5/1/15','1/1/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c3333','Envia','5/1/15','1/1/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c4444','Envia','5/1/15','1/1/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c5555','Envia','5/1/15','1/1/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c6666','Envia','5/1/15','1/1/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c7777','Envia','5/1/15','1/1/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
--febrero
insert into Carpeta values('c111','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c222','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c333','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c444','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c555','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c666','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c777','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c111','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c222','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c333','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c444','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c555','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c666','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c777','Envia','5/2/15','1/2/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

--marzo
insert into Carpeta values('c11','Envia','5/2/15','1/3/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c22','Envia','5/2/15','1/3/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c33','Envia','5/2/15','1/3/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c44','Envia','5/2/15','1/3/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c55','Envia','5/2/15','1/3/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c66','Envia','5/2/15','1/3/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

--abril
insert into Carpeta values('55555','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('454545','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('4545','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('65656','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('244','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('325','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c5545','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c545r','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c333e8989r','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c7778884er','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c5556tt5er','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c666ett5t5r','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

insert into Carpeta values('53373','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('4gr5745','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('g475','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('675j656','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('274j4','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('327j5','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c5g7545','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c5g745r','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c337g3e8989r','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c7777g8884er','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c557g56tt5er','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c667g6ett5t5r','Envia','5/6/14','1/4/14','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

insert into Carpeta values('c111e2r','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c222er2','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c333er2','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c444er2','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c555er2','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c666er22','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

insert into Carpeta values('c111er3','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c222er3','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c333er3','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c444er3','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c555er3','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c666er3','Envia','5/2/15','1/4/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

--mayo
insert into Carpeta values('444er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('555er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('666er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('44er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('55er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('66er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('4744er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('5755er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('6766er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('4447er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('5557er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('6766er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('4447er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('5557er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('6676er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('444e7r44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('555e77r44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('666e77r44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('444e7r44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('555e7r44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('6766er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('4777744er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('55775er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('666777er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('4447er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('57755er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('67766er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('4744er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('57755er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('66uu6er44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('4744uer44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('555eur44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('666eur44','Envia','5/2/15','1/5/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

insert into Carpeta values('c111er31','Envia','5/2/15','1/6/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c222er31','Envia','5/2/15','1/6/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c333er31','Envia','5/2/15','1/6/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

insert into Carpeta values('5er31','Envia','5/2/15','1/7/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c255er31','Envia','5/2/15','1/7/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c333e531','Envia','5/2/15','1/7/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

insert into Carpeta values('5eroo31','Envia','5/2/15','1/8/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c25o5er31','Envia','5/2/15','1/8/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('coo333e531','Envia','5/2/15','1/8/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

insert into Carpeta values('5er3ff1','Envia','5/2/15','1/9/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c2f5er31','Envia','5/2/15','1/9/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c333ff531','Envia','5/2/15','1/9/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

insert into Carpeta values('5e4341','Envia','5/2/15','1/10/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('c2f8787r31','Envia','5/2/15','1/10/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('0000f531','Envia','5/2/15','1/10/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

insert into Carpeta values('5222e4341','Envia','5/2/15','1/11/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('11212c2f8787r31','Envia','5/2/15','1/11/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('34220000f531','Envia','5/2/15','1/11/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

insert into Carpeta values('522266661','Envia','5/2/15','1/12/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('112kkkk8787r31','Envia','5/2/15','1/12/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);
insert into Carpeta values('342200jkljk1','Envia','5/2/15','1/12/15','Cordon',1,16,1,'sin obs',1,0,'werwer',1,0,'asdasd',1);

select * from Carpeta
DBCC CHECKIDENT (Paciente, RESEED,0)
insert into Paciente values('Sin','Paciente','',0,'',1)
insert into Paciente values('Lopez','Mariel','321321651',0966665,'8/8/1990',1)
insert into Paciente values('Garcia','Marcos','686767867',044459565,'5/8/1990',1)
insert into Paciente values('Guazo','fernando','7878787',0664569565,'4/8/1990',1)
insert into Paciente values('Curoto','Gonzalo','23434344',05657765,'8/8/1990',1)
insert into Paciente values('Rodriguez','Miguel','23424444',09999565,'5/8/1999',1)
insert into Paciente values('Gonzalez','Ricardo','656456456',09999565,'8/8/1990',1)
insert into Paciente values('losano','Matias','7756545',095656565,'7/8/1998',1)
insert into Paciente values('Pache','Enrique','67744554',09999565,'8/7/1990',1)
insert into Paciente values('Liro','Carla','87786786',099565656,'9/9/1990',1)
*/
/*
