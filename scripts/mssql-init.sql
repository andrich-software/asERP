-- MSSQL Initialization Script for asToolkit
-- This script creates the database and user for asToolkit

USE master;
GO

-- Create database if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'astoolkit_01')
BEGIN
    CREATE DATABASE astoolkit_01;
END
GO

-- Create login if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'astoolkit')
BEGIN
    CREATE LOGIN astoolkit WITH PASSWORD = 'astoolkit123!', CHECK_POLICY = OFF;
END
GO

-- Use the astoolkit database
USE astoolkit_01;
GO

-- Create user if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'astoolkit')
BEGIN
    CREATE USER astoolkit FOR LOGIN astoolkit;
END
GO

-- Grant necessary permissions
ALTER ROLE db_owner ADD MEMBER astoolkit;
GO

PRINT 'asToolkit database and user setup completed successfully.';
GO