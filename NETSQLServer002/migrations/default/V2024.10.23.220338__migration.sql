CREATE TABLE [GXA0004] ([ProductId] smallint NOT NULL IDENTITY(1,1), [ProductName] nvarchar(40) NOT NULL , [ProductDescription] nvarchar(200) NOT NULL , [ProductPrice] decimal( 17, 2) NOT NULL , [ProductImage] VARBINARY(MAX) NOT NULL , [ProductImage_GXI] varchar(2048) NOT NULL , [SellerId] smallint NOT NULL , [SupplierId] smallint NOT NULL , [CategoryId] smallint NOT NULL , [ProductCountryId] smallint NOT NULL );
Run conversion program for table Product;
DROP TABLE [Product];
sp_rename '[GXA0004]', 'Product';
ALTER TABLE [Product] ADD PRIMARY KEY([ProductId]);
CREATE UNIQUE NONCLUSTERED INDEX [UPRODUCT] ON [Product] ([ProductName] );
CREATE NONCLUSTERED INDEX [IPRODUCT1] ON [Product] ([CategoryId] );
CREATE NONCLUSTERED INDEX [IPRODUCT2] ON [Product] ([SupplierId] );
CREATE NONCLUSTERED INDEX [IPRODUCT3] ON [Product] ([SellerId] );
CREATE NONCLUSTERED INDEX [IPRODUCT4] ON [Product] ([ProductCountryId] );

ALTER TABLE [ShoppingCartProducts] ADD CONSTRAINT [ISHOPPINGCARTPRODUCTS2] FOREIGN KEY ([ShoppingCartId]) REFERENCES [ShoppingCart] ([ShoppingCartId]);
ALTER TABLE [ShoppingCartProducts] ADD CONSTRAINT [ISHOPPINGCARTPRODUCTS1] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]);

ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT3] FOREIGN KEY ([SellerId]) REFERENCES [Seller] ([SellerId]);
ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT2] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([SupplierId]);
ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT1] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([CategoryId]);
ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT4] FOREIGN KEY ([ProductCountryId]) REFERENCES [Country] ([CountryId]);

