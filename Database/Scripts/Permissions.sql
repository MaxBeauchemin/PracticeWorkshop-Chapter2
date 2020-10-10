/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT NAME FROM sys.server_principals WHERE [name] = N'WorkshopUser')
BEGIN
	PRINT 'Adding Server Login: WorkshopUser'

	EXEC sp_addlogin @loginame='WorkshopUser',@passwd='hga0s09fha87hg'
END
GO

USE [$(DatabaseName)]

EXEC sp_addrole 'WorkshopRole'
GO
EXEC sp_addrolemember 'db_datareader', 'WorkshopRole'
GO
EXEC sp_addrolemember 'db_datawriter', 'WorkshopRole'
GO

/* Associate Roles to Users and grant dbaccess to users. */
PRINT 'Associating Database Users...'
GO
EXEC sp_grantdbaccess @loginame='WorkshopUser'
GO
EXEC sp_addrolemember 'WorkshopRole', 'WorkshopUser'
GO