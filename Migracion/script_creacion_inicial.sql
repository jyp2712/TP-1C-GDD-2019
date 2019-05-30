USE [GD1C2019]
 
SET QUOTED_IDENTIFIER OFF

IF EXISTS (SELECT * FROM SYS.SCHEMAS WHERE name = 'EYE_OF_THE_TRIGGER')
BEGIN
	DECLARE @Sql NVARCHAR(MAX) = '';

/*******  ELIMINACION DE CONSTRAINTS  *******/


	SELECT @Sql = @Sql + 'ALTER TABLE ' + QUOTENAME('EYE_OF_THE_TRIGGER') + '.' + QUOTENAME(t.name) + ' DROP CONSTRAINT ' + QUOTENAME(f.name)  + ';' + CHAR(13)
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
	[domi_piso] [numeric](18,0),
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
   	AND TABLE_NAME = 'Crucero' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[Crucero] (
	[cruc_id] [numeric](18,0) NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[cruc_codigo] [nvarchar](50),
	[cruc_fecha_alta] [datetime],
	[cruc_nombre] [nvarchar](255),
	[cruc_modelo] [nvarchar](50),
	[cruc_marca] [numeric](18,0),
	[cruc_estado] [bit] DEFAULT 1,
	CONSTRAINT FK_CRUCEROS_MARCA FOREIGN KEY ([cruc_marca]) REFERENCES [EYE_OF_THE_TRIGGER].[Marca] ([marc_id])
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
	[inhab_crucero_id] [numeric](18,0) NOT NULL,
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
    	AND TABLE_NAME = 'ServicioCrucero' 
	AND TABLE_SCHEMA = 'EYE_OF_THE_TRIGGER'
)
BEGIN
CREATE TABLE [EYE_OF_THE_TRIGGER].[ServicioCrucero] (
	[serv_id] [numeric](18,0) NOT NULL,
	[cruc_id] [numeric](18,0) NOT NULL,
	CONSTRAINT PK_SERVICIO_CRUCERO PRIMARY KEY ([serv_id], [cruc_id]),
	CONSTRAINT PK_SERVICIO_CRUCERO_SERVICIO FOREIGN KEY ([serv_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Servicio] ([serv_id]),
	CONSTRAINT PK_SERVICIO_CRUCERO_CRUCERO FOREIGN KEY ([cruc_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Crucero] ([cruc_id])
)
PRINT '----- Tabla EYE_OF_THE_TRIGGER.ServicioCrucero creada -----'
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
	[cabi_cruc_id] [numeric](18,0)
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
	[reco_precio] [numeric](18,2) NOT NULL
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
	[viaj_crucero_id] [numeric](18,0)
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
	[rese_crucero_id] [numeric](18,0),
	[rese_fecha_creacion] [datetime],
	[rese_viaje_id] [numeric](18,0),
	[rese_cabina_id] [numeric](18,0),	
	[rese_tipo_servicio_id] [numeric](18,0),
	[rese_estado_reserva] [numeric](18,0),
	[rese_cantidad_pasajeros] [numeric](1,0) DEFAULT 1,
	CONSTRAINT FK_RESERVA_CLIENTE FOREIGN KEY ([rese_cliente_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Cliente] ([clie_id]),
	CONSTRAINT FK_RESERVA_CRUCERO FOREIGN KEY ([rese_crucero_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Crucero] ([cruc_id]),
	CONSTRAINT FK_RESERVA_VIAJE FOREIGN KEY ([rese_viaje_id]) REFERENCES [EYE_OF_THE_TRIGGER].[Viaje] ([viaj_id]),
	CONSTRAINT FK_RESERVA_CABINA FOREIGN KEY ([rese_cabina_id])  REFERENCES [EYE_OF_THE_TRIGGER].[Cabina] ([cabi_id]),
	CONSTRAINT FK_RESERVA_TIPO_SERVICIO FOREIGN KEY ([rese_tipo_servicio_id])  REFERENCES [EYE_OF_THE_TRIGGER].[Servicio] ([serv_id]),
	CONSTRAINT FK_RESERVA_ESTADO FOREIGN KEY ([rese_estado_reserva])  REFERENCES [EYE_OF_THE_TRIGGER].[EstadoReserva] ([id])
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
 	[medio_cuotas] [numeric](2,0) DEFAULT 1
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
 	[pago_medio_id] [numeric](18,0)
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
		FECHA_SALIDA AS fecha_salida, FECHA_LLEGADA AS fecha_llegada, FECHA_LLEGADA_ESTIMADA AS fecha_llegada_estimada, 
		CRUCERO_IDENTIFICADOR AS crucero_identificador
	FROM gd_esquema.Maestra
	WHERE PASAJE_CODIGO IS NOT NULL
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaPasaje] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaRecorrido]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaRecorrido]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaRecorrido] AS
	SELECT DISTINCT RECORRIDO_CODIGO AS recorrido_codigo, RECORRIDO_PRECIO_BASE AS recorrido_precio_base, 
			PUERTO_DESDE AS puerto_desde, PUERTO_HASTA AS puerto_hasta
	FROM gd_esquema.Maestra
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaRecorrido] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaCabina]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaCabina]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaCabina] AS
	SELECT DISTINCT CABINA_NRO AS cabina_nro, CABINA_PISO AS cabina_piso, CABINA_TIPO AS cabina_tipo, 
			CABINA_TIPO_PORC_RECARGO AS cabina_tipo_porc_recargo, CRUCERO_IDENTIFICADOR AS crucero_identificador
	FROM gd_esquema.Maestra
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaCabina] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaCrucero]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaCrucero]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaCrucero] AS
	SELECT DISTINCT CRUCERO_IDENTIFICADOR AS crucero_identificador, CRU_FABRICANTE AS cru_fabricante,
			CRUCERO_MODELO AS crucero_modelo 
	FROM gd_esquema.Maestra
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaCrucero] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaReservaViaje]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaReservaViaje]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaReservaViaje] AS
	SELECT m1.RESERVA_CODIGO AS reserva_codigo, m2.PASAJE_CODIGO AS pasaje_codigo 
	FROM gd_esquema.Maestra m1 JOIN gd_esquema.Maestra m2
		ON m1.CRUCERO_IDENTIFICADOR = m2.CRUCERO_IDENTIFICADOR AND m1.RECORRIDO_CODIGO = m2.RECORRIDO_CODIGO 
		AND m1.CABINA_PISO = m2.CABINA_PISO AND m1.CABINA_NRO = m2.CABINA_NRO AND m1.FECHA_SALIDA = m2.FECHA_SALIDA 
		AND m1.FECHA_LLEGADA = m2.FECHA_LLEGADA AND m1.FECHA_LLEGADA_ESTIMADA = m2.FECHA_LLEGADA_ESTIMADA 
		AND m1.PUERTO_DESDE = m2.PUERTO_DESDE AND m1.PUERTO_HASTA = m2.PUERTO_HASTA
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


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaCabinaReserva]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaCabinaReserva]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaCabinaReserva] AS
	SELECT M.RESERVA_CODIGO AS reserva_codigo, 
		(SELECT vrv.pasaje_codigo FROM EYE_OF_THE_TRIGGER.vistaReservaViaje vrv WHERE M.RESERVA_CODIGO = vrv.reserva_codigo) AS pasaje_codigo,
		CABINA_PISO AS cabina_piso, CABINA_NRO AS cabina_nro
	FROM gd_esquema.Maestra M
	WHERE M.RESERVA_CODIGO IS NOT NULL
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaCabinaReserva] creada -----'


IF OBJECT_ID('[EYE_OF_THE_TRIGGER].[vistaRecorridoViaje]', 'V') IS NOT NULL 
DROP VIEW [EYE_OF_THE_TRIGGER].[vistaRecorridoViaje]
GO

CREATE VIEW [EYE_OF_THE_TRIGGER].[vistaRecorridoViaje] AS
	SELECT DISTINCT RECORRIDO_CODIGO AS recorrido_codigo, PASAJE_CODIGO AS pasaje_codigo
	FROM gd_esquema.Maestra
GO
PRINT '----- Vista [EYE_OF_THE_TRIGGER].[vistaRecorridoViaje] creada -----'


/*******  MIGRACION  *******/


PRINT''
PRINT '----- Realizando inserts a tabla EYE_OF_THE_TRIGGER.TipoDocumento -----'
INSERT INTO EYE_OF_THE_TRIGGER.TipoDocumento (descripcion)
VALUES ('DNI')


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Domicilio -----'
INSERT INTO EYE_OF_THE_TRIGGER.Domicilio (domi_calle, domi_nro_calle)
SELECT DISTINCT clie_domicilio, clie_domicilio_numero
FROM [EYE_OF_THE_TRIGGER].[vistaCliente]


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Cliente -----'
INSERT INTO EYE_OF_THE_TRIGGER.Cliente (clie_nombre, clie_apellido, clie_tipo_doc, clie_doc, clie_domicilio_id, clie_tel, clie_mail, clie_fecha_nac)
SELECT clie_nombre, clie_apellido, 1, clie_dni,
(
SELECT domi_id
FROM EYE_OF_THE_TRIGGER.Domicilio
WHERE domi_calle = clie_domicilio AND domi_nro_calle = clie_domicilio_numero),
clie_tel, clie_mail, clie_fecha_nac
FROM [EYE_OF_THE_TRIGGER].[vistaCliente]


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Marca -----'
INSERT INTO EYE_OF_THE_TRIGGER.Marca (marc_nombre)
SELECT DISTINCT cru_fabricante
FROM [EYE_OF_THE_TRIGGER].[vistaCrucero]


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Crucero -----'
INSERT INTO EYE_OF_THE_TRIGGER.Crucero (cruc_codigo, cruc_modelo, cruc_marca)
SELECT crucero_identificador, crucero_modelo,
(SELECT marc_id FROM EYE_OF_THE_TRIGGER.Marca WHERE marc_nombre = cru_fabricante)
FROM [EYE_OF_THE_TRIGGER].[vistaCrucero]



PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.TipoCabina -----'
INSERT INTO EYE_OF_THE_TRIGGER.TipoCabina (descripcion, porcentaje_agregado)
SELECT DISTINCT cabina_tipo, cabina_tipo_porc_recargo
FROM [EYE_OF_THE_TRIGGER].[vistaCabina]


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Cabina -----'
INSERT INTO EYE_OF_THE_TRIGGER.Cabina (cabi_numero, cabi_piso, cabi_tipo_cabina, cabi_cruc_id)
SELECT cabina_nro, cabina_piso, 
(SELECT tc.id FROM EYE_OF_THE_TRIGGER.TipoCabina tc WHERE tc.descripcion = cabina_tipo), 
(SELECT cruc_id FROM EYE_OF_THE_TRIGGER.Crucero WHERE cruc_codigo = crucero_identificador)
FROM [EYE_OF_THE_TRIGGER].[vistaCabina]


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Viaje -----'
INSERT INTO EYE_OF_THE_TRIGGER.Viaje (viaj_codigo, viaj_fecha_inicio, viaj_fecha_fin, viaj_fecha_fin_estimada, viaj_crucero_id)
SELECT pasaje_codigo, fecha_salida, fecha_llegada, fecha_llegada_estimada,
(SELECT cruc_id FROM EYE_OF_THE_TRIGGER.Crucero WHERE cruc_codigo = crucero_identificador)
FROM [EYE_OF_THE_TRIGGER].[vistaPasaje]


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Puerto -----'
INSERT INTO EYE_OF_THE_TRIGGER.Puerto (puer_nombre)
SELECT puerto_desde 
FROM [EYE_OF_THE_TRIGGER].[vistaRecorrido]
INTERSECT
SELECT puerto_hasta
FROM [EYE_OF_THE_TRIGGER].[vistaRecorrido]


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Ciudad -----'
INSERT INTO EYE_OF_THE_TRIGGER.Ciudad (ciud_puerto_id)
SELECT puer_id
FROM EYE_OF_THE_TRIGGER.Puerto


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Recorrido -----'
INSERT INTO EYE_OF_THE_TRIGGER.Recorrido (reco_codigo, reco_origen_id , reco_destino_id, reco_precio)
SELECT recorrido_codigo,
(SELECT origenC.ciud_id FROM EYE_OF_THE_TRIGGER.Ciudad origenC JOIN EYE_OF_THE_TRIGGER.Puerto origenP ON origenC.ciud_puerto_id = origenP.puer_id 
WHERE origenP.puer_nombre = puerto_desde), 
(SELECT destinoC.ciud_id FROM EYE_OF_THE_TRIGGER.Ciudad destinoC JOIN EYE_OF_THE_TRIGGER.Puerto destinoP ON destinoC.ciud_puerto_id = destinoP.puer_id 
WHERE destinoP.puer_nombre = puerto_hasta) , recorrido_precio_base
FROM [EYE_OF_THE_TRIGGER].[vistaRecorrido]


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.RecorridoViaje -----'
INSERT INTO EYE_OF_THE_TRIGGER.RecorridoViaje (reco_id, viaj_id)
SELECT DISTINCT reco_id, viaj_id
FROM [EYE_OF_THE_TRIGGER].[vistaRecorridoViaje]
JOIN EYE_OF_THE_TRIGGER.Recorrido ON reco_codigo = recorrido_codigo
JOIN EYE_OF_THE_TRIGGER.Viaje ON viaj_codigo = pasaje_codigo


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Factura -----'
INSERT INTO EYE_OF_THE_TRIGGER.Factura (fact_viaje_id, fact_monto_total, fact_fecha)
SELECT (SELECT viaj_id FROM EYE_OF_THE_TRIGGER.Viaje WHERE viaj_codigo = pasaje_codigo), pasaje_precio, pasaje_fecha_compra
FROM [EYE_OF_THE_TRIGGER].[vistaPasaje]


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Reserva -----'
INSERT INTO EYE_OF_THE_TRIGGER.Reserva (rese_id, rese_cliente_id, rese_crucero_id, rese_fecha_creacion, rese_viaje_id)
SELECT DISTINCT vr.reserva_codigo, vr.cli_identificador, 
v.viaj_crucero_id, reserva_fecha,
v.viaj_id
FROM [EYE_OF_THE_TRIGGER].[vistaReserva] vr
JOIN EYE_OF_THE_TRIGGER.vistaReservaViaje vrv ON vr.reserva_codigo = vrv.reserva_codigo
JOIN EYE_OF_THE_TRIGGER.Viaje v ON v.viaj_codigo = vrv.pasaje_codigo


PRINT''
PRINT '----- Realizando inserts tabla EYE_OF_THE_TRIGGER.Compra -----'
INSERT INTO EYE_OF_THE_TRIGGER.Compra (comp_reserva_id, comp_fact_id)
SELECT reserva_codigo, fact_id 
FROM [EYE_OF_THE_TRIGGER].[vistaReservaViaje]
JOIN EYE_OF_THE_TRIGGER.Viaje ON pasaje_codigo = viaj_codigo
JOIN EYE_OF_THE_TRIGGER.Factura ON viaj_id = fact_viaje_id



/*******  INSERTS EN TABLAS  *******/


PRINT''
PRINT '----- Realizando inserts a tabla EYE_OF_THE_TRIGGER.EstadoReserva -----'
INSERT INTO EYE_OF_THE_TRIGGER.EstadoReserva (descripcion) 
VALUES ('Reserva correcta'),('Reserva modificada'),
('Reserva cancelada por Cliente'), ('Reserva vencida')

PRINT''
PRINT '----- Insertando Roles -----'
INSERT INTO EYE_OF_THE_TRIGGER.Rol (Rol_Nombre) 
VALUES ('Administrador General'), ('Administrador'), ('Cliente')


PRINT''
PRINT '----- Insertando Funcionalidades -----'
INSERT INTO EYE_OF_THE_TRIGGER.Funcionalidad (func_nombre) 
VALUES ('Administrar Roles'), ('Administrar Cruceros'), ('Administrar Reservas'), ('Listado Estadístico')


PRINT''
PRINT '----- Insertando Funcionalidades a los distintos roles -----'
INSERT INTO EYE_OF_THE_TRIGGER.Rol_Funcionalidad (rol_id, func_id)
VALUES (1,1),(1,2),(1,3),(1,4),(2,2),(2,3),(3,3)


PRINT''
PRINT '----- Insertando Usuario "admin" -----'
INSERT INTO EYE_OF_THE_TRIGGER.[User] (user_usuario, user_contrasenia) VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'))


PRINT''
PRINT '----- Insertando Roles para "admin" -----'
INSERT INTO EYE_OF_THE_TRIGGER.User_Rol (user_id, rol_id) 
VALUES (1,1)


PRINT''
PRINT '----- Insertando Formas de pago -----'
INSERT INTO EYE_OF_THE_TRIGGER.MedioDePago (medio_descripcion) VALUES ('Efectivo'), ('Tarjeta de Credito'), ('Tarjeta de Debito')


PRINT''
PRINT '----- Insertando Tipos de Documento -----'
INSERT INTO EYE_OF_THE_TRIGGER.TipoDocumento (descripcion)
VALUES ('Pasaporte'), ('LC'), ('LE')


