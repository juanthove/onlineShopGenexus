ALTER TABLE [Customer] ALTER COLUMN [CustomerDirectionDestination] nvarchar(40) NOT NULL;

ALTER TABLE [ShoppingCart] DROP COLUMN [ShoppingCartTotalCost];

CREATE TABLE [ShoppingCartProducts] ([ShoppingCartId] smallint NOT NULL , [ProductId] smallint NOT NULL , [ProductQuantity] decimal( 10) NOT NULL , PRIMARY KEY([ShoppingCartId], [ProductId]));
CREATE NONCLUSTERED INDEX [ISHOPPINGCARTPRODUCTS1] ON [ShoppingCartProducts] ([ProductId] );

ALTER TABLE [ShoppingCartProducts] ADD CONSTRAINT [ISHOPPINGCARTPRODUCTS2] FOREIGN KEY ([ShoppingCartId]) REFERENCES [ShoppingCart] ([ShoppingCartId]);
ALTER TABLE [ShoppingCartProducts] ADD CONSTRAINT [ISHOPPINGCARTPRODUCTS1] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]);

