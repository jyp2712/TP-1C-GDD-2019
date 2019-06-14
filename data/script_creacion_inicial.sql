USE [GD1C2019]
 
SET QUOTED_IDENTIFIER OFF

IF EXISTS (SELECT * FROM SYS.SCHEMAS WHERE name = 'EYE_OF_THE_TRIGGER')
BEGIN
	DECLARE @Sql NVARCHAR(MAX) = '';

/*******  ELIMINACION DE CONSTRAINTS  *******/


	SELECT @Sql = @Sql + 'ALTER TABLE ' + QUOTENAME('EYE_OF_THE_TRIGGER') + '.' + QUOTENAME(t.name) + ' DROP CONSTRAINT ' + 		QUOTENAME(f.name)  + ';' + CHAR(13)
	FROM SYS.TABLES t 
	INNER JOIN SYS.FOREIGN_KEYS f ON f.parent_object_id = t.object_id 
	INNER JOIN SYS.SCHEMAS s ON t.SCHEMA_ID = s.SCHEMA_ID
	WHERE s.name = 'EYE_OF_THE_TRIGGER'
	ORDER BY t.name;
	PRINT @Sql
	EXEC  (@Sql)


/*******  ELIMINACION DE TABLAS  *******/


	DECLARE @SqlStatement NVARCHAR(MAX)
	SELECT @SqlStatement = COALESCE(@SqlStatement, N'') + N'DROP TABLE [EYE_OF_THE_TRIGGER].' + QUOTENAME(TABLE_NAME) + N';' + CHAR(13)
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER' AND TABLE_TYPE = 'BASE TABLE'
	PRINT @SqlStatement
	EXEC  (@SqlStatement)
END
GO


/*******  CREACION DE ESQUEMA  *******/


IF NOT EXISTS (SELECT * FROM SYS.SCHEMAS WHERE name = 'EYE_OF_THE_TRIGGER')
BEGIN
	EXEC ('CREATE SCHEMA [EYE_OF_THE_TRIGGER] AUTHORIZATION [gdCruceros2019]')
	PRINT '----- Esquema EYE_OF_THE_TRIGGER creado -----'
END
GO


/*******  CREACION DE TABLAS  *******/


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Rol' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Rol] (
	[rol_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[rol_nombre] [nvarchar](255) CONSTRAINT UQ_NOMBRE_ROLES UNIQUE NOT NULL,
	[rol_estado] [bit] DEFAULT 1
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Rol creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Funcionalidad' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Funcionalidad] (
	[func_id][numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[func_nombre] [nvarchar](255) NOT NULL
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Funcionalidad creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Rol_Funcionalidad' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad] (
	[rol_id] [numeric](18,0) NOT NULL,
	[func_id] [numeric](18,0) NOT NULL
	CONSTRAINT PK_ROL_FUNCIONALIDAD PRIMARY KEY ([rol_id], [func_id]),
	CONSTRAINT FK_ROL_FUNCIONALIDAD_ROL FOREIGN KEY ([rol_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Rol] ([rol_id]),
	CONSTRAINT FK_ROL_FUNCIONALIDAD_FUNCIONALIDAD FOREIGN KEY ([func_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Funcionalidad] ([func_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Rol_Funcionalidad creada -----'
END
GO

IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Domicilio' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Domicilio] (
	[domi_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[domi_pais] [nvarchar](255),
	[domi_ciudad] [nvarchar](255),
	[domi_calle] [nvarchar](255),
	[domi_nro_calle] [numeric](18,0),
	[domi_piso] [nvarchar](50),
	[domi_dpto] [nvarchar](50),
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Domicilio creada -----'
END
GO

IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'TipoDocumento' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[TipoDocumento] (
	[id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_TIPODOCUMENTO UNIQUE NOT NULL
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.TipoDocumento creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    AND TABLE_NAME = 'Cliente' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Cliente] (
	[clie_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[clie_nombre] [nvarchar](255),
	[clie_apellido] [nvarchar](255),
	[clie_tipo_doc] [numeric](18,0),
	[clie_doc] [numeric](18,0),
	[clie_domicilio_id] [numeric](18,0),
	[clie_tel] [numeric](18,0),
	[clie_mail] [nvarchar](255),
	[clie_fecha_nac] [datetime]
	CONSTRAINT FK_PERSONA_TIPO_DOCUMENTO FOREIGN KEY ([clie_tipo_doc]) REFERENCES [EYE_OF_THE_TRIGGER].[TipoDocumento] ([id]),
	CONSTRAINT FK_PERSONA_DOMICILIO FOREIGN KEY ([clie_domicilio_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Domicilio] ([domi_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Cliente creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'User' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[User] (
	[user_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[user_usuario] [nvarchar](255) NOT NULL,
	[user_contrasenia] [varbinary](100) NOT NULL,
	[user_intentos_fallidos] [int] DEFAULT 0,
	[user_estado] [bit] DEFAULT 1
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.User creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'User_Rol' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[User_Rol] (
	[user_id] [numeric](18,0) NOT NULL,
	[rol_id] [numeric](18,0) NOT NULL,
	CONSTRAINT PK_USUARIO_ROL PRIMARY KEY ([user_id], [rol_id]),
	CONSTRAINT FK_USUARIO_ROL_USUARIO FOREIGN KEY ([user_id]) REFERENCES [EYE_OF_THE_TRIGGER].[User] ([user_id]),
	CONSTRAINT FK_USUARIO_ROL_ROL FOREIGN KEY ([rol_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Rol] ([rol_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.User_Rol creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Marca' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Marca] (
	[marc_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[marc_nombre] [nvarchar](255) CONSTRAINT UQ_DESC_MARCACRUCERO UNIQUE NOT NULL
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Marca creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Servicio' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Servicio] (
	[serv_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[serv_descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_REGIMEN UNIQUE NOT NULL,
	[serv_precio] [numeric](18,2) NOT NULL,
	[serv_estado] [bit] DEFAULT 1
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Servicio creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Crucero' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Crucero] (
	[cruc_id] [nvarchar](50) NOT NULL PRIMARY KEY,
	[cruc_fecha_alta] [datetime],
	[cruc_nombre] [nvarchar](255),
	[cruc_modelo] [nvarchar](50),
	[cruc_cant_cabinas] [numeric](4,0),
	[cruc_marca] [numeric](18,0),
	[cruc_servicio] [numeric](18,0),
	[cruc_estado] [bit] DEFAULT 1,
	CONSTRAINT FK_CRUCEROS_MARCA FOREIGN KEY ([cruc_marca]) REFERENCES [EYE_OF_THE_TRIGGER].[Marca] ([marc_id]),
	CONSTRAINT FK_CRUCEROS_SERVICIO FOREIGN KEY ([cruc_servicio]) REFERENCES [EYE_OF_THE_TRIGGER].[Servicio] ([serv_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Crucero creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'CruceroInhabilitado' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[CruceroInhabilitado] (
	[inhab_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[inhab_crucero_id] [nvarchar](50) NOT NULL,
	[inhab_fecha_inicio] [datetime],
	[inhab_fecha_fin] [datetime],
	[inhab_motivo] [nvarchar](255),
	[inhab_definitiva] [bit] DEFAULT 0
	CONSTRAINT FK_MANTENIMIENTO_CRUCERO FOREIGN KEY ([inhab_crucero_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Crucero] ([cruc_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.CruceroInhabilitado creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'TipoCabina' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[TipoCabina] (
	[id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_TIPOCABINA UNIQUE NOT NULL,
	[porcentaje_agregado] [numeric](18,2)
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.TipoCabina creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Cabina' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Cabina] (
	[cabi_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[cabi_numero] [numeric](18,0),
	[cabi_piso] [numeric](18,0),
	[cabi_tipo_cabina] [numeric](18,0),
	[cabi_cruc_id] [nvarchar](50)
	CONSTRAINT FK_CABINAS_CRUCERO FOREIGN KEY ([cabi_cruc_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Crucero] ([cruc_id]),
	CONSTRAINT FK_CABINAS_TIPO FOREIGN KEY ([cabi_tipo_cabina]) REFERENCES [EYE_OF_THE_TRIGGER].[TipoCabina] ([id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Cabina creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Puerto' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Puerto] (
	[puer_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[puer_nombre] [nvarchar](255) CONSTRAINT UQ_NOMB_PUERTO UNIQUE NOT NULL,
	[puer_estado] [bit] DEFAULT 1
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Puerto creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Ciudad' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Ciudad] (
	[ciud_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[ciud_nombre] [nvarchar](255),
	[ciud_puerto_id] [numeric](18,0)
	CONSTRAINT FK_CIUDAD_PUERTO FOREIGN KEY ([ciud_puerto_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Puerto] ([puer_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Ciudad creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Recorrido' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Recorrido] (
	[reco_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[reco_codigo] [numeric](18,0),
	[reco_origen_id] [numeric](18,0),
 	[reco_destino_id] [numeric](18,0),
	[reco_precio] [numeric](18,2) NOT NULL,
	[reco_estado] [bit] DEFAULT 1
	CONSTRAINT FK_RECORRIDO_CIUDAD_ORIGEN FOREIGN KEY ([reco_origen_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Ciudad] ([ciud_id]),
	CONSTRAINT FK_RECORRIDO_CIUDAD_DESTINO FOREIGN KEY ([reco_destino_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Ciudad] ([ciud_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Recorrido creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Viaje' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Viaje] (
	[viaj_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[viaj_codigo] [numeric](18,0),
	[viaj_fecha_inicio] [datetime],
	[viaj_fecha_fin] [datetime],
	[viaj_fecha_fin_estimada] [datetime],
	[viaj_crucero_id] [nvarchar](50),
	[viaj_estado] [bit] DEFAULT 1
	CONSTRAINT FK_VIAJE_CRUCERO FOREIGN KEY ([viaj_crucero_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Crucero] ([cruc_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Viaje creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'RecorridoViaje' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[RecorridoViaje] (
	[reco_id] [numeric](18,0) NOT NULL,
	[viaj_id] [numeric](18,0) NOT NULL,
	CONSTRAINT PK_RECORRIDO_VIAJE PRIMARY KEY ([reco_id], [viaj_id]),
	CONSTRAINT PK_RECORRIDO_VIAJE_RECORRIDO FOREIGN KEY ([reco_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Recorrido] ([reco_id]),
	CONSTRAINT PK_RECORRIDO_VIAJE_VIAJE FOREIGN KEY ([viaj_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Viaje] ([viaj_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.RecorridoViaje creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'EstadoReserva' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[EstadoReserva] (
	[id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_ESTADO_RESERVA UNIQUE NOT NULL
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.EstadoReserva creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Reserva' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Reserva] (
	[rese_id] [numeric](18,0) NOT NULL PRIMARY KEY,
	[rese_cliente_id] [numeric](18,0),
	[rese_crucero_id] [nvarchar](50),
	[rese_fecha_creacion] [datetime],
	[rese_viaje_id] [numeric](18,0),
	[rese_cabina_id] [numeric](18,0),	
	[rese_estado_reserva] [numeric](18,0),
	[rese_cantidad_pasajeros] [numeric](1,0),
	CONSTRAINT FK_RESERVA_CLIENTE FOREIGN KEY ([rese_cliente_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Cliente] ([clie_id]),
	CONSTRAINT FK_RESERVA_CRUCERO FOREIGN KEY ([rese_crucero_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Crucero] ([cruc_id]),
	CONSTRAINT FK_RESERVA_VIAJE FOREIGN KEY ([rese_viaje_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Viaje] ([viaj_id]),
	CONSTRAINT FK_RESERVA_CABINA FOREIGN KEY ([rese_cabina_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Cabina] ([cabi_id]),
	CONSTRAINT FK_RESERVA_ESTADO FOREIGN KEY ([rese_estado_reserva]) REFERENCES [EYE_OF_THE_TRIGGER].[EstadoReserva] ([id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Reserva creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'CabinasReservadas' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[CabinasReservadas](
	[rese_id][numeric](18,0) NOT NULL,
	[cabi_id][numeric](18,0) NOT NULL,
	CONSTRAINT FK_CABINAS_RESERVADAS PRIMARY KEY ([rese_id], [cabi_id]),
	CONSTRAINT FK_CABINAS_RESERVADAS_RESERVA FOREIGN KEY ([rese_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Reserva] ([rese_id]),
	CONSTRAINT FK_CABINAS_RESERVADAS_CABINA FOREIGN KEY ([cabi_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Cabina] ([cabi_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.CabinasReservadas creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'CancelacionReserva' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[CancelacionReserva] (
	[canc_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[canc_fecha] [datetime],
	[canc_motivo] [nvarchar](255),
	[canc_reserva_id] [numeric](18,0) NOT NULL
	CONSTRAINT FK_CANCELACION_RESERVA_RESERVA FOREIGN KEY ([canc_reserva_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Reserva] ([rese_id]),
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.CancelacionReserva creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'MedioDePago' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[MedioDePago] (
	[medio_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[medio_descripcion] [nvarchar](255) CONSTRAINT UQ_DESC_MEDIO_DE_PAGO UNIQUE,
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.MedioDePago creada -----'
END
GO

IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Pago' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Pago] (
	[pago_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
 	[pago_medio_id] [numeric](18,0),
	[pago_medio_cuotas] [numeric](2,0)
	CONSTRAINT FK_PAGO_MEDIO_DE_PAGO FOREIGN KEY ([pago_medio_id]) REFERENCES [EYE_OF_THE_TRIGGER].[MedioDePago] ([medio_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Pago creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Factura' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Factura] (
	[fact_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[fact_viaje_id] [numeric](18,0),
	[fact_monto_total] [numeric] (18,2),
	[fact_fecha] [datetime],
	CONSTRAINT FK_FACTURA_VIAJE FOREIGN KEY ([fact_viaje_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Viaje] ([viaj_id])	
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Factura creada -----'
END
GO


IF NOT EXISTS (
	SELECT 1 
	FROM INFORMATION_SCHEMA.TABLES 
	WHERE TABLE_TYPE = 'BASE TABLE' 
    	AND TABLE_NAME = 'Compra' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Compra] (
	[comp_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[comp_reserva_id] [numeric](18,0),
	[comp_pago_id] [numeric](18,0),	
	[comp_fact_id] [numeric](18,0)
	CONSTRAINT FK_COMPRA_RESERVA FOREIGN KEY ([comp_reserva_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Reserva] ([rese_id]),
	CONSTRAINT FK_COMPRA_PAGO FOREIGN KEY ([comp_pago_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Pago] ([pago_id]),		
  CONSTRAINT FK_COMPRA_FACTURA FOREIGN KEY ([comp_fact_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Factura] ([fact_id])	
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.Compra creada -----'
END
GO


/*******  VISTAS  *******/


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaCliente]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaCliente]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaCliente] AS

	SELECT CLI_NOMBRE AS clie_nombre, CLI_APELLIDO AS clie_apellido, CLI_DNI AS clie_dni, CLI_TELEFONO AS clie_tel, CLI_MAIL AS clie_mail, 
			CLI_FECHA_NAC AS clie_fecha_nac, LEFT(CLI_DIRECCION, PATINDEX('%[a-z][0-9]%', CLI_DIRECCION)) AS clie_domicilio, 
			CAST(SUBSTRING(CLI_DIRECCION, PATINDEX('%[a-z][0-9]%', CLI_DIRECCION) + 1, LEN(CLI_DIRECCION)) AS INT) AS clie_domicilio_numero 
	FROM gd_esquema.Maestra
	GROUP BY CLI_NOMBRE, CLI_APELLIDO, CLI_DNI, CLI_TELEFONO, CLI_MAIL, CLI_FECHA_NAC, CLI_DIRECCION
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaCliente] creada -----'

IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaPasaje]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaPasaje]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaPasaje] AS
	SELECT PASAJE_CODIGO AS pasaje_codigo, PASAJE_PRECIO AS pasaje_precio, PASAJE_FECHA_COMPRA AS pasaje_fecha_compra,
					FECHA_SALIDA AS fecha_salida, FECHA_LLEGADA AS fecha_llegada, FECHA_LLEGADA_ESTIMADA AS fecha_llegada_estimada, CRUCERO_IDENTIFICADOR AS crucero_identificador
	FROM gd_esquema.Maestra
	WHERE PASAJE_CODIGO IS NOT NULL
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaPasaje] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaRecorrido]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaRecorrido]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaRecorrido] AS
	SELECT DISTINCT RECORRIDO_CODIGO AS recorrido_codigo, RECORRIDO_PRECIO_BASE AS recorrido_precio_base, PUERTO_DESDE AS puerto_desde, PUERTO_HASTA AS puerto_hasta
	FROM gd_esquema.Maestra
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaRecorrido] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaCabina]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaCabina]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaCabina] AS
	SELECT DISTINCT CABINA_NRO AS cabina_nro, CABINA_PISO AS cabina_piso, CABINA_TIPO AS cabina_tipo, CABINA_TIPO_PORC_RECARGO AS cabina_tipo_porc_recargo,
					CRUCERO_IDENTIFICADOR AS crucero_identificador
	FROM gd_esquema.Maestra
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaCabina] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaCrucero]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaCrucero]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaCrucero] AS
	SELECT DISTINCT CRUCERO_IDENTIFICADOR AS crucero_identificador, CRU_FABRICANTE AS cru_fabricante, CRUCERO_MODELO AS crucero_modelo FROM gd_esquema.Maestra
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaCrucero] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaReservaViaje]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaReservaViaje]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaReservaViaje] AS
	SELECT m1.RESERVA_CODIGO AS reserva_codigo, m2.PASAJE_CODIGO AS pasaje_codigo 
	FROM gd_esquema.Maestra m1 JOIN gd_esquema.Maestra m2
		ON m1.CRUCERO_IDENTIFICADOR = m2.CRUCERO_IDENTIFICADOR AND m1.RECORRIDO_CODIGO = m2.RECORRIDO_CODIGO AND m1.CABINA_PISO = m2.CABINA_PISO
		AND m1.CABINA_NRO = m2.CABINA_NRO AND m1.FECHA_SALIDA = m2.FECHA_SALIDA AND m1.FECHA_LLEGADA = m2.FECHA_LLEGADA 
		AND m1.FECHA_LLEGADA_ESTIMADA = m2.FECHA_LLEGADA_ESTIMADA AND m1.PUERTO_DESDE = m2.PUERTO_DESDE AND m1.PUERTO_HASTA = m2.PUERTO_HASTA
	group by m1.RESERVA_CODIGO, m2.PASAJE_CODIGO
	having m1.RESERVA_CODIGO is not null and m2.PASAJE_CODIGO is not null
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaReservaViaje] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaReserva]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaReserva]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaReserva] AS
	SELECT M.RESERVA_CODIGO AS reserva_codigo, M.RESERVA_FECHA AS reserva_fecha,
			(SELECT clie_id FROM EYE_OF_THE_TRIGGER.Cliente WHERE clie_doc = M.CLI_DNI AND clie_nombre = m.CLI_NOMBRE) AS cli_identificador,
			CRUCERO_IDENTIFICADOR AS crucero_identificador
	FROM gd_esquema.Maestra M 
	WHERE M.RESERVA_CODIGO IS NOT NULL
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaReserva] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaRecorridoViaje]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaRecorridoViaje]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaRecorridoViaje] AS
	SELECT DISTINCT RECORRIDO_CODIGO AS recorrido_codigo, PASAJE_CODIGO AS pasaje_codigo
	FROM gd_esquema.Maestra
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaRecorridoViaje] creada -----'


/*******  MIGRACION  *******/


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarDomicilio]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarDomicilio]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarDomicilio] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Domicilio -----'

INSERT INTO EYE_OF_THE_TRIGGER.Domicilio (domi_calle, domi_nro_calle)
	SELECT DISTINCT clie_domicilio, clie_domicilio_numero
	FROM [EYE_OF_THE_TRIGGER].[vistaCliente]
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarCliente]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarCliente]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarCliente] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Cliente -----'

INSERT INTO EYE_OF_THE_TRIGGER.Cliente (clie_nombre, clie_apellido, clie_tipo_doc, clie_doc, clie_domicilio_id, clie_tel, clie_mail, clie_fecha_nac)
	SELECT clie_nombre, clie_apellido, 1, clie_dni,
	(SELECT domi_id
	FROM EYE_OF_THE_TRIGGER.Domicilio
	WHERE domi_calle = clie_domicilio AND domi_nro_calle = clie_domicilio_numero),
	clie_tel, clie_mail, clie_fecha_nac
	FROM [EYE_OF_THE_TRIGGER].[vistaCliente]
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarMarca]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarMarca]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarMarca] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Marca -----'

INSERT INTO EYE_OF_THE_TRIGGER.Marca (marc_nombre)
	SELECT DISTINCT cru_fabricante
	FROM [EYE_OF_THE_TRIGGER].[vistaCrucero]
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarCrucero]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarCrucero]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarCrucero] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Crucero -----'

INSERT INTO EYE_OF_THE_TRIGGER.Crucero (cruc_id, cruc_modelo, cruc_marca, cruc_cant_cabinas, cruc_servicio)
	SELECT v.crucero_identificador, v.crucero_modelo,
	(SELECT marc_id FROM EYE_OF_THE_TRIGGER.Marca WHERE marc_nombre = v.cru_fabricante),
	(SELECT count(*)
	FROM EYE_OF_THE_TRIGGER.vistaCabina vcab
	WHERE vcab.crucero_identificador = v.crucero_identificador), 1
	FROM [EYE_OF_THE_TRIGGER].[vistaCrucero] v
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarTipoCabina]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarTipoCabina]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarTipoCabina] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.TipoCabina -----'

INSERT INTO EYE_OF_THE_TRIGGER.TipoCabina (descripcion, porcentaje_agregado)
	SELECT DISTINCT cabina_tipo, cabina_tipo_porc_recargo
	FROM [EYE_OF_THE_TRIGGER].[vistaCabina]
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarCabina]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarCabina]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarCabina] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Cabina -----'
INSERT INTO EYE_OF_THE_TRIGGER.Cabina (cabi_numero, cabi_piso, cabi_tipo_cabina, cabi_cruc_id)
	SELECT cabina_nro, cabina_piso, 
	(SELECT tc.id FROM EYE_OF_THE_TRIGGER.TipoCabina tc WHERE tc.descripcion = cabina_tipo), 
	crucero_identificador
	FROM [EYE_OF_THE_TRIGGER].[vistaCabina]
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarViaje]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarViaje]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarViaje] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Viaje -----'

INSERT INTO EYE_OF_THE_TRIGGER.Viaje (viaj_codigo, viaj_fecha_inicio, viaj_fecha_fin, viaj_fecha_fin_estimada, viaj_crucero_id, viaj_estado)
	SELECT pasaje_codigo, fecha_salida, fecha_llegada, fecha_llegada_estimada, crucero_identificador, 0
	FROM [EYE_OF_THE_TRIGGER].[vistaPasaje]
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarPuerto]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarPuerto]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarPuerto] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Puerto -----'

INSERT INTO EYE_OF_THE_TRIGGER.Puerto (puer_nombre)
	SELECT puerto_desde 
	FROM [EYE_OF_THE_TRIGGER].[vistaRecorrido]
	UNION
	SELECT puerto_hasta
	FROM [EYE_OF_THE_TRIGGER].[vistaRecorrido]
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarCiudad]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarCiudad]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarCiudad] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Ciudad -----'

INSERT INTO EYE_OF_THE_TRIGGER.Ciudad (ciud_puerto_id)
	SELECT puer_id
	FROM EYE_OF_THE_TRIGGER.Puerto
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarRecorrido]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarRecorrido]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarRecorrido] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Recorrido -----'

INSERT INTO EYE_OF_THE_TRIGGER.Recorrido (reco_codigo, reco_origen_id , reco_destino_id, reco_precio)
	SELECT recorrido_codigo,
	(SELECT origenC.ciud_id FROM EYE_OF_THE_TRIGGER.Ciudad origenC JOIN EYE_OF_THE_TRIGGER.Puerto origenP ON origenC.ciud_puerto_id = origenP.puer_id 
	WHERE origenP.puer_nombre = puerto_desde), 
	(SELECT destinoC.ciud_id FROM EYE_OF_THE_TRIGGER.Ciudad destinoC JOIN EYE_OF_THE_TRIGGER.Puerto destinoP ON destinoC.ciud_puerto_id = destinoP.puer_id 
	WHERE destinoP.puer_nombre = puerto_hasta) , recorrido_precio_base
	FROM [EYE_OF_THE_TRIGGER].[vistaRecorrido]
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarRecorridoViaje]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarRecorridoViaje]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarRecorridoViaje] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.RecorridoViaje -----'

INSERT INTO EYE_OF_THE_TRIGGER.RecorridoViaje (reco_id, viaj_id)
	SELECT DISTINCT reco_id, viaj_id
	FROM [EYE_OF_THE_TRIGGER].[vistaRecorridoViaje]
	JOIN EYE_OF_THE_TRIGGER.Recorrido ON reco_codigo = recorrido_codigo
	JOIN EYE_OF_THE_TRIGGER.Viaje ON viaj_codigo = pasaje_codigo
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarFactura]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarFactura]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarFactura] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Factura -----'

INSERT INTO EYE_OF_THE_TRIGGER.Factura (fact_viaje_id, fact_monto_total, fact_fecha)
	SELECT (SELECT viaj_id FROM EYE_OF_THE_TRIGGER.Viaje WHERE viaj_codigo = pasaje_codigo), pasaje_precio, pasaje_fecha_compra
	FROM [EYE_OF_THE_TRIGGER].[vistaPasaje]
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarReserva]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarReserva]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarReserva] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Reserva -----'

INSERT INTO EYE_OF_THE_TRIGGER.Reserva (rese_id, rese_cliente_id, rese_crucero_id, rese_fecha_creacion, rese_viaje_id)
	SELECT DISTINCT vr.reserva_codigo, vr.cli_identificador, v.viaj_crucero_id, reserva_fecha, v.viaj_id
	FROM [EYE_OF_THE_TRIGGER].[vistaReserva] vr
	JOIN EYE_OF_THE_TRIGGER.vistaReservaViaje vrv ON vr.reserva_codigo = vrv.reserva_codigo
	JOIN EYE_OF_THE_TRIGGER.Viaje v ON v.viaj_codigo = vrv.pasaje_codigo
UPDATE EYE_OF_THE_TRIGGER.Reserva SET rese_estado_reserva = 1
GO


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[importarCompra]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[importarCompra]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[importarCompra] AS
PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Compra -----'

INSERT INTO EYE_OF_THE_TRIGGER.Compra (comp_reserva_id, comp_fact_id)
	SELECT reserva_codigo, fact_id 
	FROM [EYE_OF_THE_TRIGGER].[vistaReservaViaje]
	JOIN EYE_OF_THE_TRIGGER.Viaje ON pasaje_codigo = viaj_codigo
	JOIN EYE_OF_THE_TRIGGER.Factura ON viaj_id = fact_viaje_id
GO



/*******  INSERTS EN TABLAS  *******/


PRINT''
PRINT '----- Insertando Tipos de Documento -----'
INSERT INTO EYE_OF_THE_TRIGGER.TipoDocumento (descripcion)
VALUES ('DNI'), ('Pasaporte'), ('LC'), ('LE')


PRINT''
PRINT '----- Realizando inserts a tabla EYE_OF_THE_TRIGGER.EstadoReserva -----'
INSERT INTO EYE_OF_THE_TRIGGER.EstadoReserva (descripcion) 
VALUES ('Reserva correcta'), ('Reserva modificada'), ('Reserva pendiente'), ('Reserva cancelada por Baja de Crucero'), ('Reserva vencida')


PRINT''
PRINT '----- Insertando Servicios -----'
INSERT INTO EYE_OF_THE_TRIGGER.Servicio (serv_descripcion, serv_estado, serv_precio) 
VALUES ('Sin servicio', 1, 0), ('All inclusive', 1, 1000), ('Pensión completa sin bebidas', 1, 300)


EXEC EYE_OF_THE_TRIGGER.importarDomicilio
GO
PRINT''
PRINT '----- Domicilios importados -----'


EXEC EYE_OF_THE_TRIGGER.importarCliente
GO
CREATE nonclustered index IDX_Cliente on EYE_OF_THE_TRIGGER.Cliente(clie_doc, clie_nombre)
PRINT''
PRINT '----- Clientes importados -----'


EXEC EYE_OF_THE_TRIGGER.importarMarca
GO
PRINT''
PRINT '----- Marcas importadas -----'


EXEC EYE_OF_THE_TRIGGER.importarCrucero
GO
PRINT''
PRINT '----- Cruceros importados -----'


EXEC EYE_OF_THE_TRIGGER.importarTipoCabina
GO
PRINT''
PRINT '----- Tipos de Cabina importadas -----'


EXEC EYE_OF_THE_TRIGGER.importarCabina
GO
PRINT''
PRINT '----- Cabinas importadas -----'


EXEC EYE_OF_THE_TRIGGER.importarViaje
GO
PRINT''
PRINT '----- Viajes importados -----'


EXEC EYE_OF_THE_TRIGGER.importarPuerto
GO
PRINT''
PRINT '----- Puertos importados -----'


EXEC EYE_OF_THE_TRIGGER.importarCiudad
GO
PRINT''
PRINT '----- Ciudades importadas -----'


EXEC EYE_OF_THE_TRIGGER.importarRecorrido
GO
PRINT''
PRINT '----- Recorridos importados -----'


EXEC EYE_OF_THE_TRIGGER.importarRecorridoViaje
GO
PRINT''
PRINT '----- Recorridos por Viaje importados -----'


EXEC EYE_OF_THE_TRIGGER.importarFactura
GO
PRINT''
PRINT '----- Facturas importadas -----'


EXEC EYE_OF_THE_TRIGGER.importarReserva
GO
PRINT''
PRINT '----- Reservas importadas -----'


EXEC EYE_OF_THE_TRIGGER.importarCompra
GO
PRINT''
PRINT '----- Compras importadas -----'


PRINT''
PRINT '----- Insertando Roles -----'
INSERT INTO EYE_OF_THE_TRIGGER.Rol (Rol_Nombre) 
VALUES ('Administrador General'), ('Administrador'), ('Cliente')


PRINT''
PRINT '----- Insertando Funcionalidades -----'
INSERT INTO EYE_OF_THE_TRIGGER.Funcionalidad (func_nombre) 
VALUES ('Administrar Roles'), ('Administrar Usuarios'), ('Administrar Puertos'), ('Administrar Recorridos'), ('Administrar Cruceros'),
('Administrar Viajes'), ('Listado EstadiDstico'), ('Realizar Compras y/o Reservas')


PRINT''
PRINT '----- Insertando Funcionalidades a los distintos roles -----'
INSERT INTO EYE_OF_THE_TRIGGER.Rol_Funcionalidad (rol_id, func_id)
VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),
(2,3),(2,4),(2,5),(2,6),(2,7),(2,8),(3,8)


PRINT''
PRINT '----- Insertando Usuario "admin" -----'
INSERT INTO EYE_OF_THE_TRIGGER.[User] (user_usuario, user_contrasenia) 
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e')), ('admin_funcional', HASHBYTES('SHA2_256', 'w23e'))


PRINT''
PRINT '----- Insertando Roles para "admin" -----'
INSERT INTO EYE_OF_THE_TRIGGER.User_Rol (user_id, rol_id) 
VALUES (1,1), (2,2)


PRINT''
PRINT '----- Insertando Formas de pago -----'
INSERT INTO EYE_OF_THE_TRIGGER.MedioDePago (medio_descripcion) VALUES ('Efectivo'), ('Tarjeta de Credito'), ('Tarjeta de Debito')


/*******  SP para la APP  *******/


PRINT''
IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[buscarRolNombre]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].buscarRolNombre
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[buscarRolNombre] (
    @rol_nombre varchar(255)
) AS
BEGIN
	SELECT * FROM [EYE_OF_THE_TRIGGER].[Rol] WHERE rol_nombre LIKE '%' + @rol_nombre + '%';
END;
GO
PRINT '----- STORED PROCEDURE para buscar rol por nombre [EYE_OF_THE_TRIGGER].[buscarRolNombre] CREADO -----'


PRINT''
IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[login]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[login]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[login] (
    @user_name varchar(255),
    @user_contrasenia varchar(255),
	@Resultado bit output
) AS
BEGIN
	declare @intentosFallidos INT;
	declare @cantidadUsuarios INT;

	SELECT @intentosFallidos = [user_intentos_fallidos] FROM GD1C2019.EYE_OF_THE_TRIGGER.[User] WHERE user_usuario = @user_name;
	IF(@intentosFallidos > 2)
	BEGIN
		RAISERROR('Usuario bloqueado por cantidad de reintentos', 11, 1) WITH SETERROR;
	END

	SELECT @cantidadUsuarios = COUNT(*) FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[User] WHERE user_usuario=@user_name AND user_contrasenia=HASHBYTES('SHA2_256', @user_contrasenia);

	IF (@cantidadUsuarios > 0)
	BEGIN 
		UPDATE [EYE_OF_THE_TRIGGER].[User] SET [user_intentos_fallidos] = 0 WHERE [User].[user_usuario] = @user_name;
		SET @Resultado = 1;
	END
	ELSE
	BEGIN
		UPDATE [EYE_OF_THE_TRIGGER].[User] SET [user_intentos_fallidos] = (@intentosFallidos + 1) WHERE [User].[user_usuario] = @user_name;
		IF(@intentosFallidos + 1 > 2)
		BEGIN
			UPDATE [EYE_OF_THE_TRIGGER].[User] SET [user_estado] = 0 WHERE [User].[user_usuario] = @user_name;
			RAISERROR('Usuario bloqueado por cantidad de reintentos', 11, 1) WITH SETERROR;
		END
		SET @Resultado = 0;
	END;
END;
GO
PRINT '----- STORED PROCEDURE para Login [EYE_OF_THE_TRIGGER].[login] CREADO -----'


PRINT''
IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[funcionalidades]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].funcionalidades
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].funcionalidades (@user_name varchar(255)) AS
BEGIN
SELECT * 
FROM Funcionalidad f JOIN Rol_Funcionalidad rf ON f.func_id = rf.func_id JOIN Rol r ON r.rol_id = rf.rol_id AND r.rol_estado=1 JOIN User_Rol ur ON r.rol_id = ur.rol_id JOIN [User] u ON u.[user_id] = ur.[user_id]
WHERE u.user_usuario = @user_name
END  
GO
PRINT '----- STORED PROCEDURE para Login [EYE_OF_THE_TRIGGER].[funcionalidades] CREADO -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[crearRol]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].[crearRol]
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].[crearRol] (
    @rol_nombre varchar(255),
	@func_id_list varchar(255)
) AS
BEGIN
	BEGIN TRANSACTION
	/* Verifico que no exista otro con el mismo nombre */
	declare @rol_id_existente int;

	SELECT @rol_id_existente = [rol_id] FROM [EYE_OF_THE_TRIGGER].[Rol] WHERE rol_nombre = @rol_nombre;
	IF (@rol_id_existente iS NOT NULL)
	BEGIN
		ROLLBACK TRANSACTION
		RAISERROR('El nombre seleccionado ya existe', 12, 1) WITH SETERROR;
	END
	
	/* Inserto el rol nuevo */
	INSERT INTO [EYE_OF_THE_TRIGGER].[Rol] ([rol_nombre], [rol_estado]) VALUES (@rol_nombre, 1)
	SELECT @rol_id_existente = rol_id FROM [EYE_OF_THE_TRIGGER].[Rol] WHERE rol_nombre = @rol_nombre;

	/* Inserto las funcionalidades del rol nuevo */
	declare @IdsTable TABLE(value int)
	-- SELECT value From STRING_SPLIT(@func_id_list, ',');
	INSERT INTO @IdsTable SELECT * From [EYE_OF_THE_TRIGGER].[SplitString](@func_id_list, ',');
	 -- SELECT @IdsTable = From STRING_SPLIT(@func_id_list, ',');

	DECLARE @MyCursor CURSOR;
	DECLARE @MyField int;
	BEGIN
		SET @MyCursor = CURSOR FOR
		select value from @IdsTable      

		OPEN @MyCursor 
		FETCH NEXT FROM @MyCursor 
		INTO @MyField

		WHILE @@FETCH_STATUS = 0
		BEGIN
		  /*
			 YOUR ALGORITHM GOES HERE   
		  */

		INSERT INTO [EYE_OF_THE_TRIGGER].[Rol_Funcionalidad]
				   ([rol_id]
				   ,[func_id])
			 VALUES
				   (@rol_id_existente, @MyField)


		  /* */
		  FETCH NEXT FROM @MyCursor 
		  INTO @MyField 
		END; 

		CLOSE @MyCursor ;
		DEALLOCATE @MyCursor;
	END;
	COMMIT TRANSACTION

END;
GO
PRINT''
PRINT '----- STORED PROCEDURE para crear rol [EYE_OF_THE_TRIGGER].[crearRol] CREADO -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[top5_recorridos_mas_pasajes_comprados]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].top5_recorridos_mas_pasajes_comprados
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].top5_recorridos_mas_pasajes_comprados(@semestre as bigint, @anio as bigint) AS

SELECT DISTINCT TOP 5
		r.reco_codigo AS codigo_recorrido, count(DISTINCT v.viaj_id) cant_viajes,
		(SELECT TOP 1 p.puer_nombre 
		FROM EYE_OF_THE_TRIGGER.Puerto p JOIN EYE_OF_THE_TRIGGER.Ciudad c ON c.ciud_puerto_id = p.puer_id
		JOIN EYE_OF_THE_TRIGGER.Recorrido r1 ON c.ciud_id = r1.reco_origen_id
		WHERE r1.reco_id = (select TOP 1 r2.reco_id from EYE_OF_THE_TRIGGER.Recorrido r2 WHERE r2.reco_codigo = r.reco_codigo ORDER BY r2.reco_id)) AS puerto_origen,
		(SELECT TOP 1 p.puer_nombre 
		FROM EYE_OF_THE_TRIGGER.Puerto p JOIN EYE_OF_THE_TRIGGER.Ciudad c ON c.ciud_puerto_id = p.puer_id
		JOIN EYE_OF_THE_TRIGGER.Recorrido r1 ON c.ciud_id = r1.reco_destino_id
		WHERE r1.reco_id = (select TOP 1 r2.reco_id from EYE_OF_THE_TRIGGER.Recorrido r2 WHERE r2.reco_codigo = r.reco_codigo ORDER BY r2.reco_id DESC)) AS puerto_destino
FROM EYE_OF_THE_TRIGGER.Recorrido r 
JOIN EYE_OF_THE_TRIGGER.RecorridoViaje rv ON r.reco_id = rv.reco_id
JOIN EYE_OF_THE_TRIGGER.Viaje v ON rv.viaj_id = v.viaj_id
JOIN EYE_OF_THE_TRIGGER.Reserva res ON res.rese_viaje_id = v.viaj_id
WHERE res.rese_estado_reserva = 1 AND (FLOOR(MONTH(res.rese_fecha_creacion)/2) + 1) = @semestre
	AND YEAR(res.rese_fecha_creacion) = @anio
GROUP BY r.reco_codigo
ORDER BY cant_viajes DESC

GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[top5_recorridos_mas_pasajes_comprados] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[top5_recorridos_mas_cabinas_libres_viaje_realizado]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].top5_recorridos_mas_cabinas_libres_viaje_realizado
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].top5_recorridos_mas_cabinas_libres_viaje_realizado(@semestre as bigint, @anio as bigint) AS

SELECT DISTINCT TOP 5
		r.reco_codigo AS codigo_recorrido, 
		((SELECT c1.cruc_cant_cabinas
		FROM EYE_OF_THE_TRIGGER.Crucero c1
		WHERE c1.cruc_id = res.rese_crucero_id) - 
		SUM(ISNULL(res.rese_cantidad_pasajeros, 1))) cant_cabinas_libres,
		(SELECT TOP 1 p.puer_nombre 
		FROM EYE_OF_THE_TRIGGER.Puerto p JOIN EYE_OF_THE_TRIGGER.Ciudad c ON c.ciud_puerto_id = p.puer_id
		JOIN EYE_OF_THE_TRIGGER.Recorrido r1 ON c.ciud_id = r1.reco_origen_id
		WHERE r1.reco_id = (select TOP 1 r2.reco_id from EYE_OF_THE_TRIGGER.Recorrido r2 WHERE r2.reco_codigo = r.reco_codigo ORDER BY r2.reco_id)) AS puerto_origen,
		(SELECT TOP 1 p.puer_nombre 
		FROM EYE_OF_THE_TRIGGER.Puerto p JOIN EYE_OF_THE_TRIGGER.Ciudad c ON c.ciud_puerto_id = p.puer_id
		JOIN EYE_OF_THE_TRIGGER.Recorrido r1 ON c.ciud_id = r1.reco_destino_id
		WHERE r1.reco_id = (select TOP 1 r2.reco_id from EYE_OF_THE_TRIGGER.Recorrido r2 WHERE r2.reco_codigo = r.reco_codigo ORDER BY r2.reco_id DESC)) AS puerto_destino
FROM EYE_OF_THE_TRIGGER.Recorrido r 
JOIN EYE_OF_THE_TRIGGER.RecorridoViaje rv ON r.reco_id = rv.reco_id
JOIN EYE_OF_THE_TRIGGER.Viaje v ON rv.viaj_id = v.viaj_id
JOIN EYE_OF_THE_TRIGGER.Reserva res ON res.rese_viaje_id = v.viaj_id
WHERE res.rese_estado_reserva = 1 AND (FLOOR(MONTH(res.rese_fecha_creacion)/2) + 1) = @semestre
	AND YEAR(res.rese_fecha_creacion) = @anio
GROUP BY r.reco_codigo, res.rese_crucero_id
ORDER BY cant_cabinas_libres DESC

GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[top5_recorridos_mas_cabinas_libres_viaje_realizado] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[top5_cruceros_con_mayor_periodo_inhabilitado]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].top5_cruceros_con_mayor_periodo_inhabilitado
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].top5_cruceros_con_mayor_periodo_inhabilitado(@semestre as bigint, @anio as bigint) AS

SELECT DISTINCT TOP 5
		inhab_crucero_id, inhab_fecha_inicio, inhab_fecha_fin, inhab_motivo, 
		DATEDIFF(DAY, inhab_fecha_inicio,inhab_fecha_fin) cant_dias_inhabilitado
FROM EYE_OF_THE_TRIGGER.CruceroInhabilitado
WHERE (FLOOR(MONTH(inhab_fecha_inicio)/2) + 1) = @semestre
	AND YEAR(inhab_fecha_inicio) = @anio
ORDER BY cant_dias_inhabilitado DESC

GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[top5_cruceros_con_mayor_periodo_inhabilitado] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[recorrido_finalizado]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].recorrido_finalizado
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].recorrido_finalizado(@Codigo as bigint, @FechaActual as DATETIME) AS

SELECT *
FROM EYE_OF_THE_TRIGGER.Recorrido r JOIN EYE_OF_THE_TRIGGER.RecorridoViaje rv ON r.reco_id = rv.reco_id JOIN Viaje v ON v.viaj_id = rv.viaj_id
WHERE v.viaj_fecha_fin < @FechaActual AND r.reco_codigo = @Codigo

GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[recorrido_finalizado] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[actualizar_recorrido]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].actualizar_recorrido
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].actualizar_recorrido(@id as bigint, @Codigo as bigint, @PuertoDesde as varchar(50), @PuertoHasta as varchar(50),
@Precio as float) AS

DECLARE  @puertoInicio as int, @puertoFin as int

SET @puertoInicio = (SELECT ciud_id FROM [EYE_OF_THE_TRIGGER].Ciudad JOIN [EYE_OF_THE_TRIGGER].Puerto ON ciud_puerto_id = puer_id WHERE puer_nombre=@PuertoDesde)
SET @puertoFin = (SELECT ciud_id FROM [EYE_OF_THE_TRIGGER].Ciudad JOIN [EYE_OF_THE_TRIGGER].Puerto ON ciud_puerto_id = puer_id WHERE puer_nombre=@PuertoHasta)

UPDATE [EYE_OF_THE_TRIGGER].Recorrido SET reco_codigo = @Codigo, reco_origen_id = @puertoInicio, reco_destino_id = @puertoFin, reco_precio = @Precio, reco_estado = 1
WHERE reco_id = @id  
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[actualizar_recorrido] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[recorrido_existente]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].recorrido_existente
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].recorrido_existente(@Codigo as bigint, @PuertoOrigen as varchar(MAX), @PuertoDestino as varchar(MAX)) AS

DECLARE  @puertoInicio varchar(MAX), @puertoFin varchar(MAX)

SET @puertoInicio = (SELECT MIN(Item) FROM [EYE_OF_THE_TRIGGER].[SplitString] (@PuertoOrigen, '-'))
SET @PuertoDestino = (SELECT MIN(Item) FROM [EYE_OF_THE_TRIGGER].[SplitString] (@PuertoDestino, '-'))

SELECT *
FROM EYE_OF_THE_TRIGGER.Recorrido r JOIN EYE_OF_THE_TRIGGER.Ciudad c1 ON r.reco_origen_id = c1.ciud_id JOIN EYE_OF_THE_TRIGGER.Ciudad c2 ON r.reco_destino_id = c2.ciud_id
JOIN EYE_OF_THE_TRIGGER.Puerto p1 ON p1.puer_nombre = @puertoInicio JOIN Puerto p ON p.puer_nombre = @PuertoDestino
WHERE r.reco_codigo = @Codigo

GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[recorrido_existente] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[crucero_no_disponible]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].crucero_no_disponible
GO
CREATE PROCEDURE [EYE_OF_THE_TRIGGER].crucero_no_disponible(@Crucero as varchar(255), @FechaInicio as DATETIME, @FechaFin as DATETIME) AS

SELECT *
FROM EYE_OF_THE_TRIGGER.Crucero c JOIN EYE_OF_THE_TRIGGER.Viaje ON viaj_crucero_id = cruc_id
WHERE cruc_id = @Crucero AND ((viaj_fecha_inicio BETWEEN @FechaInicio AND @FechaFin) OR 
(viaj_fecha_fin_estimada BETWEEN @FechaInicio AND @FechaFin))

GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[crucero_no_disponible] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[insertar_viaje]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].insertar_viaje
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].insertar_viaje(@Codigo as int, @Recorrido as int, @FechaInicio as DATETIME, @FechaFin as DATETIME, @Crucero as varchar(50)) AS
BEGIN
	INSERT INTO EYE_OF_THE_TRIGGER.Viaje (viaj_codigo, viaj_fecha_inicio , viaj_fecha_fin_estimada, viaj_crucero_id)
	VALUES (@Codigo, @FechaInicio,  @FechaFin, @Crucero)
	INSERT INTO EYE_OF_THE_TRIGGER.RecorridoViaje (viaj_id, reco_id)
	VALUES ((select MAX(viaj_id) from EYE_OF_THE_TRIGGER.Viaje) , @Recorrido)
	RETURN 0
END
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[insertar_viaje] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[insertar_cliente]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].insertar_cliente
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].insertar_cliente
(@Nombre as varchar(255), @Apellido as varchar(255), @TipoDocumento as int, @Documento as int,
@Calle as varchar(255), @Numero as int, @Piso as varchar(255), @Dpto as varchar(255),
@Ciudad as varchar(255), @Pais as varchar(255), @Telefono as int, @Email as varchar(255), @FechaNac as DATETIME) AS

BEGIN
	DECLARE @IdDom as int
	SET @IdDom = (SELECT domi_id FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Domicilio] WHERE domi_calle= @Calle AND domi_nro_calle=@Numero
                     AND domi_piso=@Piso AND domi_dpto= @Dpto AND domi_ciudad=@Ciudad AND domi_pais=@Pais)
	
	IF @IdDom IS NULL
	BEGIN
	INSERT INTO EYE_OF_THE_TRIGGER.Domicilio (domi_pais, domi_ciudad , domi_calle, domi_nro_calle, domi_piso, domi_dpto)
	VALUES (@Pais, @Ciudad, @Calle, @Numero, @Piso, @Dpto)
	SET @IdDom = (select MAX(domi_id) from EYE_OF_THE_TRIGGER.Domicilio)
	END

	INSERT INTO EYE_OF_THE_TRIGGER.Cliente (clie_nombre, clie_apellido, clie_tipo_doc, clie_doc, clie_domicilio_id, clie_tel, clie_mail, clie_fecha_nac)
	VALUES (@Nombre, @Apellido, @TipoDocumento, @Documento, @IdDom, @Telefono, @Email, @FechaNac)
	RETURN 0
END
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[insertar_cliente] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[actualizar_cliente]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].actualizar_cliente
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].actualizar_cliente
(@IdCliente as int, @Nombre as varchar(255), @Apellido as varchar(255), @TipoDocumento as int, @Documento as int,
@Calle as varchar(255), @Numero as int, @Piso as varchar(255), @Dpto as varchar(255),
@Ciudad as varchar(255), @Pais as varchar(255), @Telefono as int, @Email as varchar(255), @FechaNac as DATETIME) AS

BEGIN
	DECLARE @IdDom as int
	SET @IdDom = (SELECT domi_id FROM [GD1C2019].[EYE_OF_THE_TRIGGER].[Domicilio] WHERE domi_calle= @Calle AND domi_nro_calle=@Numero
                     AND domi_piso=@Piso AND domi_dpto= @Dpto AND domi_ciudad=@Ciudad AND domi_pais=@Pais)
	
	IF @IdDom IS NULL
	BEGIN
	INSERT INTO EYE_OF_THE_TRIGGER.Domicilio (domi_pais, domi_ciudad , domi_calle, domi_nro_calle, domi_piso, domi_dpto)
	VALUES (@Pais, @Ciudad, @Calle, @Numero, @Piso, @Dpto)
	SET @IdDom = (select MAX(domi_id) from EYE_OF_THE_TRIGGER.Domicilio)
	END

	UPDATE EYE_OF_THE_TRIGGER.Cliente 
	SET clie_nombre = @Nombre, clie_apellido = @Apellido, clie_tipo_doc = @TipoDocumento, 
	clie_doc = @Documento, clie_domicilio_id = @IdDom, clie_tel = @Telefono, clie_mail = @Email, clie_fecha_nac = @FechaNac
	WHERE clie_id = @IdCliente
	RETURN 0
END
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[actualizar_cliente] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[ciudad_id]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].ciudad_id
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].ciudad_id(@Puerto as varchar(MAX)) AS

DECLARE @PuertoNom varchar(MAX)
SET @PuertoNom = (SELECT MIN(Item) FROM [EYE_OF_THE_TRIGGER].[SplitString] (@Puerto, '-'))

SELECT c.ciud_id
FROM EYE_OF_THE_TRIGGER.Ciudad c JOIN EYE_OF_THE_TRIGGER.Puerto p ON c.ciud_puerto_id = p.puer_id
WHERE p.puer_nombre = @PuertoNom
RETURN 1
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[ciudad_id] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[insertar_recorrido]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].insertar_recorrido
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].insertar_recorrido(@Codigo as int, @CiudadOrigen as int, @CiudadDestino as int, @Precio as float) AS
BEGIN
	INSERT INTO EYE_OF_THE_TRIGGER.Recorrido (reco_codigo, reco_origen_id , reco_destino_id, reco_precio)
	VALUES (@Codigo, @CiudadOrigen, @CiudadDestino, @Precio)
	RETURN 0
END
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[insertar_recorrido] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[buscar_recorridos]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].buscar_recorridos
GO

IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[buscar_recorridos]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].buscar_recorridos
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].buscar_recorridos AS
BEGIN
SELECT r.reco_id, r.reco_codigo ,
		(SELECT TOP 1 p.puer_nombre 
		FROM EYE_OF_THE_TRIGGER.Puerto p JOIN EYE_OF_THE_TRIGGER.Ciudad c ON c.ciud_puerto_id = p.puer_id
		JOIN EYE_OF_THE_TRIGGER.Recorrido r1 ON c.ciud_id = r1.reco_origen_id
		WHERE r1.reco_id = (select TOP 1 r2.reco_id from EYE_OF_THE_TRIGGER.Recorrido r2 WHERE r2.reco_codigo = r.reco_codigo ORDER BY r2.reco_id)) AS puerto_origen,
		(SELECT TOP 1 p.puer_nombre 
		FROM EYE_OF_THE_TRIGGER.Puerto p JOIN EYE_OF_THE_TRIGGER.Ciudad c ON c.ciud_puerto_id = p.puer_id
		JOIN EYE_OF_THE_TRIGGER.Recorrido r1 ON c.ciud_id = r1.reco_destino_id
		WHERE r1.reco_id = (select TOP 1 r2.reco_id from EYE_OF_THE_TRIGGER.Recorrido r2 WHERE r2.reco_codigo = r.reco_codigo ORDER BY r2.reco_id DESC)) AS puerto_destino,
		reco_precio
FROM EYE_OF_THE_TRIGGER.Recorrido r 
JOIN EYE_OF_THE_TRIGGER.RecorridoViaje rv ON r.reco_id = rv.reco_id
JOIN EYE_OF_THE_TRIGGER.Viaje v ON rv.viaj_id = v.viaj_id
JOIN EYE_OF_THE_TRIGGER.Reserva res ON res.rese_viaje_id = v.viaj_id
WHERE r.reco_estado = 1
GROUP BY r.reco_id, r.reco_codigo, reco_precio
END
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[buscar_recorridos] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[insertar_crucero]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].insertar_crucero
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].insertar_crucero(@Codigo as varchar(50), @FechaAlta as DATETIME, @Nombre as varchar(255),
@Modelo as varchar(50), @Servicio as int, @Marca as int, @Cabinas as int) AS
BEGIN
	INSERT INTO EYE_OF_THE_TRIGGER.Crucero(cruc_id, cruc_fecha_alta, cruc_nombre, cruc_modelo, cruc_servicio, cruc_marca, cruc_cant_cabinas)
	VALUES (@Codigo, @FechaAlta, @Nombre, @Modelo, @Servicio, @Marca, @Cabinas)
	RETURN 0
END
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[insertar_crucero] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[insertar_cabina]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].insertar_cabina
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].insertar_cabina(@Numero as int, @Piso as int, @Tipo as int, @Codigo as varchar(50)) AS
BEGIN
	INSERT INTO EYE_OF_THE_TRIGGER.Cabina(cabi_numero, cabi_piso, cabi_tipo_cabina, cabi_cruc_id)
	VALUES (@Numero, @Piso, @Tipo, @Codigo)
	RETURN 0
END
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[insertar_cabina] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[actualizar_crucero_estado]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].actualizar_crucero_estado
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].actualizar_crucero_estado(@Codigo as varchar(50), @Motivo as varchar(255), @FechaFin as DATETIME, @FechaActual as DATETIME) AS

UPDATE EYE_OF_THE_TRIGGER.Crucero SET cruc_estado = 0 WHERE cruc_id = @Codigo
IF @Motivo = 'Baja Definitiva'
BEGIN
INSERT INTO EYE_OF_THE_TRIGGER.CruceroInhabilitado (inhab_crucero_id, inhab_motivo, inhab_fecha_inicio, inhab_definitiva)
VALUES (@Codigo, @Motivo, @FechaActual, 1)
END
ELSE
BEGIN
INSERT INTO EYE_OF_THE_TRIGGER.CruceroInhabilitado (inhab_crucero_id, inhab_motivo, inhab_fecha_inicio, inhab_fecha_fin)
VALUES (@Codigo, @Motivo, @FechaActual, @FechaFin)
END
RETURN 0
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[actualizar_crucero_estado] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[baja_viaje_por_crucero]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].baja_viaje_por_crucero
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].baja_viaje_por_crucero(@Id as int, @FechaActual as DATETIME) AS

UPDATE EYE_OF_THE_TRIGGER.Viaje SET viaj_estado = 0
WHERE viaj_id = @Id

UPDATE [EYE_OF_THE_TRIGGER].Reserva SET rese_estado_reserva = (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva cancelada por Baja de Crucero') 
WHERE rese_viaje_id = @Id

INSERT INTO  [EYE_OF_THE_TRIGGER].CancelacionReserva (canc_fecha, canc_reserva_id, canc_motivo)
SELECT @FechaActual, rese_id, 'Cancelacion por baja de Crucero'
FROM EYE_OF_THE_TRIGGER.Reserva
WHERE rese_viaje_id = @Id

RETURN 0
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[baja_viaje_por_crucero] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[correr_fecha_reserva]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].correr_fecha_reserva
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].correr_fecha_reserva(@Id as int, @Dias as int) AS

UPDATE EYE_OF_THE_TRIGGER.Viaje SET viaj_fecha_inicio = DATEADD(day, @Dias, viaj_fecha_inicio), viaj_fecha_fin_estimada = DATEADD(day, @Dias, viaj_fecha_fin_estimada)
WHERE viaj_id= @Id

UPDATE EYE_OF_THE_TRIGGER.Reserva SET rese_estado_reserva = (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva modificada') 
WHERE rese_viaje_id = @Id

RETURN 1
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[correr_fecha_reserva] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[actualizar_crucero]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].actualizar_crucero
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].actualizar_crucero(@Codigo as varchar(50), @Nombre as varchar(255),
@Modelo as varchar(255), @Servicio as varchar(255), @Marca as varchar(255)) AS

UPDATE [EYE_OF_THE_TRIGGER].Crucero SET cruc_nombre = @Nombre, cruc_modelo = @Modelo, 
cruc_servicio = (SELECT [serv_id] FROM [EYE_OF_THE_TRIGGER].Servicio WHERE [serv_descripcion] = @Servicio), 
cruc_marca = (SELECT [marc_id] FROM [EYE_OF_THE_TRIGGER].Marca WHERE [marc_nombre] = @Marca) 
WHERE cruc_id = @Codigo  
RETURN 0
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[actualizar_crucero] creada -----'



IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[actualizar_reemplazar_crucero]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].actualizar_reemplazar_crucero
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].actualizar_reemplazar_crucero(@Crucero as varchar(50), @Viaje as int) AS

DECLARE @CruceroNuevo as varchar(50)
DECLARE @FechaInicio as DATETIME
DECLARE @FechaFin as DATETIME

SET @FechaInicio = (SELECT viaj_fecha_inicio FROM EYE_OF_THE_TRIGGER.Viaje WHERE viaj_id = @Viaje)
SET @FechaFin = (SELECT viaj_fecha_fin_estimada FROM EYE_OF_THE_TRIGGER.Viaje WHERE viaj_id = @Viaje)

SET @CruceroNuevo = (SELECT TOP 1 c1.cruc_id FROM EYE_OF_THE_TRIGGER.Crucero c1 JOIN EYE_OF_THE_TRIGGER.Crucero c2 ON c1.cruc_id != c2.cruc_id AND c1.cruc_servicio = c2.cruc_servicio AND c1.cruc_modelo = c2.cruc_modelo AND c1.cruc_marca = c2.cruc_marca
WHERE c1.cruc_estado = 1 AND c2.cruc_id = @Crucero AND c1.cruc_id NOT IN(SELECT c3.cruc_id FROM EYE_OF_THE_TRIGGER.Crucero c3 JOIN EYE_OF_THE_TRIGGER.Viaje v ON v.viaj_crucero_id = c3.cruc_id
																		WHERE (v.viaj_fecha_inicio NOT BETWEEN @FechaInicio AND @FechaFin) AND (v.viaj_fecha_fin_estimada NOT BETWEEN @FechaInicio AND @FechaFin)))

IF @CruceroNuevo IS NULL
BEGIN
	RETURN -1
END
ELSE
BEGIN
	UPDATE EYE_OF_THE_TRIGGER.Viaje SET viaj_crucero_id = @CruceroNuevo
	WHERE viaj_id = @Viaje

	UPDATE EYE_OF_THE_TRIGGER.Reserva SET rese_crucero_id = @CruceroNuevo, rese_estado_reserva = (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva modificada')
	WHERE rese_viaje_id = @Viaje

END

RETURN 0
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[actualizar_reemplazar_crucero] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[reemplazar_crucero_reserva]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].reemplazar_crucero_reserva
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].reemplazar_crucero_reserva(@Crucero as varchar(50), @Viaje as int, @CruceroAnterior as varchar(50)) AS

UPDATE EYE_OF_THE_TRIGGER.Viaje SET viaj_crucero_id = @Crucero
WHERE viaj_id = @Viaje

UPDATE EYE_OF_THE_TRIGGER.Reserva SET rese_crucero_id = @Crucero, rese_estado_reserva = (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva modificada')
WHERE rese_viaje_id = @Viaje

RETURN 1

GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[reemplazar_crucero_reserva] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[replicar_cabinas]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].replicar_cabinas
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].replicar_cabinas(@Crucero as varchar(50), @CruceroAnterior as varchar(50)) AS

INSERT INTO EYE_OF_THE_TRIGGER.Cabina (cabi_numero, cabi_piso, cabi_tipo_cabina, cabi_cruc_id)
SELECT cabi_numero, cabi_piso, cabi_tipo_cabina, @Crucero
FROM EYE_OF_THE_TRIGGER.Cabina 
WHERE cabi_cruc_id = @CruceroAnterior

RETURN 1

GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[replicar_cabinas] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[verificar_reservas_vencidas]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].verificar_reservas_vencidas
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].verificar_reservas_vencidas (@FechaActual as varchar(255)) AS
BEGIN

DECLARE @Reserva as int
DECLARE c2 CURSOR for SELECT rese_id FROM EYE_OF_THE_TRIGGER.Reserva 
						WHERE rese_estado_reserva = (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva pendiente') 
						AND (convert(datetime, @FechaActual) - rese_fecha_creacion) > 3 


OPEN c2
FETCH NEXT FROM c2 INTO @Reserva

IF @@FETCH_STATUS <> 0
RETURN 
WHILE @@FETCH_STATUS = 0
BEGIN
UPDATE EYE_OF_THE_TRIGGER.Reserva SET rese_estado_reserva = (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva vencida') 
WHERE rese_id = @Reserva

FETCH NEXT FROM c2 INTO @Reserva
END

CLOSE c2
DEALLOCATE c2
END

GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[verificar_reservas_vencidas] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[liberar_cabina]', 'TR') IS NOT NULL 
DROP TRIGGER [EYE_OF_THE_TRIGGER].liberar_cabina
GO

CREATE TRIGGER [EYE_OF_THE_TRIGGER].liberar_cabina ON [EYE_OF_THE_TRIGGER].Reserva AFTER UPDATE AS
BEGIN

DECLARE @Reserva AS INT, @Cabina AS INT
DECLARE c1 CURSOR for SELECT r.rese_id, cr.cabi_id FROM [EYE_OF_THE_TRIGGER].Reserva r JOIN [EYE_OF_THE_TRIGGER].CabinasReservadas cr ON r.rese_id = cr.cabi_id
					 WHERE r.rese_estado_reserva = (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva vencida') OR r.rese_estado_reserva = (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva cancelada por Baja de Crucero')

OPEN c1
FETCH NEXT FROM c1 INTO @Reserva, @Cabina

IF @@FETCH_STATUS <> 0
RETURN 
WHILE @@FETCH_STATUS = 0
BEGIN
DELETE FROM [EYE_OF_THE_TRIGGER].CabinasReservadas WHERE cabi_id = @Cabina AND rese_id = @Reserva

FETCH NEXT FROM c1 INTO @Reserva, @Cabina
END

CLOSE c1
DEALLOCATE c1
END

GO
PRINT '----- Trigger [EYE_OF_THE_TRIGGER].[liberar_cabina] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[facturar]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].facturar
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].facturar (@Reserva as int, @Viaje as int, @Crucero as varchar(50), @MedioDePago as varchar(255), @Cuotas as int, @FechaActual as DATETIME) AS
BEGIN
DECLARE @PrecioRecorrido as float, @PorcentajeAgregado as float, @PrecioServicio as float
SET @PrecioRecorrido = (SELECT SUM(r.reco_precio) FROM EYE_OF_THE_TRIGGER.Recorrido r JOIN EYE_OF_THE_TRIGGER.RecorridoViaje rv ON r.reco_id=rv.reco_id AND rv.viaj_id=@Viaje)
SET @PrecioServicio = (SELECT serv_precio FROM EYE_OF_THE_TRIGGER.Servicio JOIN EYE_OF_THE_TRIGGER.Crucero ON cruc_id=@Crucero AND cruc_servicio = serv_id)
SET @PorcentajeAgregado = (SELECT porcentaje_agregado FROM EYE_OF_THE_TRIGGER.TipoCabina JOIN EYE_OF_THE_TRIGGER.Cabina c ON c.cabi_tipo_cabina=id JOIN EYE_OF_THE_TRIGGER.CabinasReservadas cr ON c.cabi_id= cr.cabi_id AND cr.rese_id=@Reserva )
 
INSERT INTO EYE_OF_THE_TRIGGER.Pago (pago_medio_id, pago_medio_cuotas)
VALUES ((SELECT medio_id FROM EYE_OF_THE_TRIGGER.MedioDePago WHERE medio_descripcion = @MedioDePago), @Cuotas)

INSERT INTO EYE_OF_THE_TRIGGER.Factura (fact_viaje_id, fact_fecha, fact_monto_total)
VALUES (@Viaje, @FechaActual, (@PrecioRecorrido+@PrecioServicio) + (@PrecioRecorrido+@PrecioServicio)*@PorcentajeAgregado)

INSERT INTO EYE_OF_THE_TRIGGER.Compra (comp_reserva_id, comp_pago_id, comp_fact_id)
VALUES (@Reserva, (select MAX(pago_id) from EYE_OF_THE_TRIGGER.Pago), (select MAX(fact_id) from EYE_OF_THE_TRIGGER.Factura))

END
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[facturar] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[reservar]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].reservar
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].reservar (@Cliente as int, @Crucero as varchar(50), @FechaActual as DATETIME, @Viaje as int, @Cabina as int, @Pasajeros as int) AS
BEGIN

INSERT INTO EYE_OF_THE_TRIGGER.Reserva (rese_id, rese_cliente_id, rese_crucero_id, rese_fecha_creacion, rese_viaje_id, rese_cabina_id, rese_estado_reserva, rese_cantidad_pasajeros)
VALUES ((SELECT MAX(rese_id)+1 FROM EYE_OF_THE_TRIGGER.Reserva), @Cliente, @Crucero, @FechaActual, @Viaje, @Cabina, (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva pendiente'), @Pasajeros)

INSERT INTO EYE_OF_THE_TRIGGER.CabinasReservadas (rese_id, cabi_id)
VALUES ((SELECT MAX(rese_id) FROM EYE_OF_THE_TRIGGER.Reserva), @Cabina)

END
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[reservar] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[abonar_reserva]', 'TR') IS NOT NULL 
DROP TRIGGER [EYE_OF_THE_TRIGGER].abonar_reserva
GO

CREATE TRIGGER [EYE_OF_THE_TRIGGER].abonar_reserva ON [EYE_OF_THE_TRIGGER].Compra AFTER INSERT AS
BEGIN

DECLARE @Reserva as int
SET @Reserva = (select comp_reserva_id from EYE_OF_THE_TRIGGER.Compra where comp_id=(select MAX(c1.comp_id) from EYE_OF_THE_TRIGGER.Compra c1))

UPDATE EYE_OF_THE_TRIGGER.Reserva SET rese_estado_reserva = (SELECT id FROM EYE_OF_THE_TRIGGER.EstadoReserva WHERE descripcion='Reserva correcta')
WHERE rese_id = @Reserva

END

GO
PRINT '----- Trigger [EYE_OF_THE_TRIGGER].[abonar_reserva] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[cabinas_reservadas]', 'TR') IS NOT NULL 
DROP TRIGGER [EYE_OF_THE_TRIGGER].cabinas_reservadas
GO

CREATE TRIGGER [EYE_OF_THE_TRIGGER].cabinas_reservadas ON [EYE_OF_THE_TRIGGER].Reserva AFTER UPDATE AS
BEGIN

IF (SELECT rese_crucero_id FROM inserted) != (SELECT rese_crucero_id FROM deleted)
BEGIN
UPDATE EYE_OF_THE_TRIGGER.CabinasReservadas SET cabi_id = (SELECT TOP 1 c.cabi_id FROM EYE_OF_THE_TRIGGER.Cabina c WHERE cabi_cruc_id = (SELECT rese_crucero_id FROM inserted) AND c.cabi_id NOT IN(SELECT cabi_id FROM CabinasReservadas))
WHERE rese_id = (SELECT rese_id FROM inserted)
END
END

GO
PRINT '----- Trigger [EYE_OF_THE_TRIGGER].[cabinas_reservadas] creada -----'



IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[contarReservas]', 'P') IS NOT NULL 
DROP PROCEDURE [EYE_OF_THE_TRIGGER].contarReservas
GO

CREATE PROCEDURE [EYE_OF_THE_TRIGGER].contarReservas (@idReserva as [numeric](18,0)) AS
BEGIN
SELECT COUNT(*) FROM EYE_OF_THE_TRIGGER.Reserva WHERE rese_id=@idReserva;

END
GO
PRINT '----- Procedure [EYE_OF_THE_TRIGGER].[contarReservas] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[recorrido_modificado]', 'TR') IS NOT NULL 
DROP TRIGGER [EYE_OF_THE_TRIGGER].cabinas_reservadas
GO

CREATE TRIGGER [EYE_OF_THE_TRIGGER].recorrido_modificado ON [EYE_OF_THE_TRIGGER].Recorrido AFTER UPDATE AS
BEGIN

DECLARE @Anterior as int, @Posterior as int
SET @Anterior = (SELECT reco_codigo FROM [EYE_OF_THE_TRIGGER].Recorrido WHERE reco_id = (SELECT r1.reco_id FROM inserted r1)-1)
SET @Posterior = (SELECT reco_codigo FROM [EYE_OF_THE_TRIGGER].Recorrido WHERE reco_id = (SELECT r1.reco_id FROM inserted r1)+1)

IF @Anterior IS NOT NULL AND (@Anterior = (SELECT r1.reco_codigo FROM inserted r1)) 
BEGIN
UPDATE EYE_OF_THE_TRIGGER.Recorrido SET reco_destino_id = (SELECT r1.reco_origen_id FROM inserted r1)
WHERE reco_id = (SELECT r1.reco_id FROM inserted r1)-1
END

IF @Posterior IS NOT NULL AND (@Posterior = (SELECT r1.reco_codigo FROM inserted r1)) 
BEGIN
UPDATE EYE_OF_THE_TRIGGER.Recorrido SET reco_origen_id = (SELECT r1.reco_destino_id FROM inserted r1)
WHERE reco_id = (SELECT r1.reco_id FROM inserted r1)+1
END

END

GO
PRINT '----- Trigger [EYE_OF_THE_TRIGGER].[recorrido_modificado] creada -----'



/*******  Funciones para la APP  *******/


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[SplitString]', N'TF') IS NOT NULL 
DROP FUNCTION [EYE_OF_THE_TRIGGER].[SplitString]
GO

CREATE FUNCTION [EYE_OF_THE_TRIGGER].[SplitString]
(    
      @Input NVARCHAR(MAX),
      @Character CHAR(1)
)
RETURNS @Output TABLE (
      Item NVARCHAR(1000)
)
AS
BEGIN
      DECLARE @StartIndex INT, @EndIndex INT
 
      SET @StartIndex = 1
      IF SUBSTRING(@Input, LEN(@Input) - 1, LEN(@Input)) <> @Character
      BEGIN
            SET @Input = @Input + @Character
      END
 
      WHILE CHARINDEX(@Character, @Input) > 0
      BEGIN
            SET @EndIndex = CHARINDEX(@Character, @Input)
           
            INSERT INTO @Output(Item)
            SELECT SUBSTRING(@Input, @StartIndex, @EndIndex - 1)
           
            SET @Input = SUBSTRING(@Input, @EndIndex + 1, LEN(@Input))
      END
 
      RETURN
END
GO
PRINT''
PRINT '----- funcion para splitear strings [EYE_OF_THE_TRIGGER].[SplitString] CREADA -----'
