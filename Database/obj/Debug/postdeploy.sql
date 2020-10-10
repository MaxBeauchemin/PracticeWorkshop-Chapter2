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

PRINT 'Adding Products'

SET IDENTITY_INSERT [dbo].[Products] ON

INSERT INTO [dbo].[Products] 
				(ProductId, Code,		[Description],				CurrentPrice)

SELECT			1,			'XBCTRL',	'Xbox One Controller',		40.00
UNION SELECT	2,			'XBX',		'Xbox One',					250.00
UNION SELECT	3,			'PS4CTRL',	'Playstation 4 Controller',	40.00

SET IDENTITY_INSERT [dbo].[Products] OFF
PRINT 'Adding Orders'

SET IDENTITY_INSERT [dbo].[Orders] ON

INSERT INTO [dbo].[Orders] 
				(OrderId,	OrderNumber, CreatedBy, CreatedTimestamp)

SELECT			1,			'000100',	'Shrek',	GETDATE()
UNION SELECT	2,			'000200',	'Fiona',	GETDATE()

SET IDENTITY_INSERT [dbo].[Orders] OFF
PRINT 'Adding Order Line Items'

SET IDENTITY_INSERT [dbo].[OrderLineItems] ON

INSERT INTO [dbo].[OrderLineItems] 
				(OrderLineItemId,	OrderId,	ProductId)

SELECT			1,					1,			1
UNION SELECT	2,					1,			2
UNION SELECT	3,					2,			1
UNION SELECT	4,					2,			1
UNION SELECT	5,					2,			1

SET IDENTITY_INSERT [dbo].[OrderLineItems] OFF

GO
