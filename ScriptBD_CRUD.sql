USE [master]
GO

CREATE DATABASE [ApiRestFluentDapper]
GO
USE ApiRestFluentDapper
GO
IF  EXISTS (select * from sysobjects where name='Producto' and xtype='U')
BEGIN
    DROP TABLE Producto
END
GO

CREATE TABLE Producto
(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(300) NOT NULL,
	Precio DECIMAL(14,2) NOT NULL,
	Stock INT NOT NULL,
	FechaRegistro DATETIME NOT NULL
)