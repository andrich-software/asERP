-- MSSQL Initialization Script for asERP
-- This script creates the database and user for asERP

USE master;
GO

-- Create database if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'aserp_01')
BEGIN
    CREATE DATABASE aserp_01;
END
GO

-- Create login if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'aserp')
BEGIN
    CREATE LOGIN aserp WITH PASSWORD = 'aserp123!', CHECK_POLICY = OFF;
END
GO

-- Use the aserp database
USE aserp_01;
GO

-- Create user if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'aserp')
BEGIN
    CREATE USER aserp FOR LOGIN aserp;
END
GO

-- Grant necessary permissions
ALTER ROLE db_owner ADD MEMBER aserp;
GO

PRINT 'asERP database and user setup completed successfully.';
GO