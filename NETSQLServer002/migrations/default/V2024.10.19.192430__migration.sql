CREATE TABLE [ShoppingCart] ([ShoppingCartId] smallint NOT NULL IDENTITY(1,1), [CustomerId] smallint NOT NULL , [ShoppingCartTotalCost] decimal( 17, 2) NOT NULL , [ShoppingCartDate] datetime NOT NULL , PRIMARY KEY([ShoppingCartId]));
CREATE NONCLUSTERED INDEX [ISHOPPINGCART1] ON [ShoppingCart] ([CustomerId] );

ALTER TABLE [ShoppingCart] ADD CONSTRAINT [ISHOPPINGCART1] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]);

