CREATE TABLE [dbo].[OrderLineItems]
(
	[OrderLineItemId]			INT				NOT NULL		IDENTITY(1,1)		PRIMARY KEY,
	[OrderId]					INT				NOT NULL,
	[ProductId]					INT				NOT NULL
)
GO

ALTER TABLE [dbo].[OrderLineItems]
ADD FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([OrderId]) 
GO

ALTER TABLE [dbo].[OrderLineItems]
ADD FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId]) 
GO