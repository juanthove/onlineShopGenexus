CREATE TABLE [Promotion] ([PromotionId] smallint NOT NULL IDENTITY(1,1), [PromotionDescription] nvarchar(200) NOT NULL , [PromotionImage] VARBINARY(MAX) NOT NULL , [PromotionImage_GXI] varchar(2048) NULL , [PromotionDateStart] datetime NOT NULL , [PromotionDateFinish] datetime NOT NULL , PRIMARY KEY([PromotionId]));

CREATE TABLE [Supplier] ([SupplierId] smallint NOT NULL IDENTITY(1,1), [SupplierName] nvarchar(40) NOT NULL , PRIMARY KEY([SupplierId]));
CREATE UNIQUE NONCLUSTERED INDEX [USUPPLIER] ON [Supplier] ([SupplierName] );

CREATE TABLE [PointCard] ([PointCardId] smallint NOT NULL IDENTITY(1,1), [CustomerId] smallint NOT NULL , [PointCardPoints] int NOT NULL , [PointCardVIP] BIT NOT NULL , PRIMARY KEY([PointCardId]));
CREATE UNIQUE NONCLUSTERED INDEX [UPOINTCARD] ON [PointCard] ([CustomerId] );

CREATE TABLE [Customer] ([CustomerId] smallint NOT NULL IDENTITY(1,1), [CustomerName] nvarchar(40) NOT NULL , [CountryId] smallint NOT NULL , [CustomerDirectionDestination] smallint NOT NULL , [CustomerEmail] nvarchar(100) NOT NULL , [CustomerPhone] nchar(20) NOT NULL , PRIMARY KEY([CustomerId]));
CREATE NONCLUSTERED INDEX [ICUSTOMER1] ON [Customer] ([CountryId] );

CREATE TABLE [Product] ([ProductId] smallint NOT NULL IDENTITY(1,1), [ProductName] nvarchar(40) NOT NULL , [ProductDescription] nvarchar(200) NOT NULL , [ProductPrice] decimal( 17, 2) NOT NULL , [ProductImage] VARBINARY(MAX) NOT NULL , [ProductImage_GXI] varchar(2048) NULL , [SellerId] smallint NOT NULL , [SupplierId] smallint NOT NULL , [CategoryId] smallint NOT NULL , PRIMARY KEY([ProductId]));
CREATE UNIQUE NONCLUSTERED INDEX [UPRODUCT] ON [Product] ([ProductName] );
CREATE NONCLUSTERED INDEX [IPRODUCT1] ON [Product] ([CategoryId] );
CREATE NONCLUSTERED INDEX [IPRODUCT2] ON [Product] ([SupplierId] );
CREATE NONCLUSTERED INDEX [IPRODUCT3] ON [Product] ([SellerId] );

CREATE TABLE [Seller] ([SellerId] smallint NOT NULL IDENTITY(1,1), [SellerName] smallint NOT NULL , [SellerPhoto] VARBINARY(MAX) NOT NULL , [SellerPhoto_GXI] varchar(2048) NULL , [CountryId] smallint NOT NULL , PRIMARY KEY([SellerId]));
CREATE NONCLUSTERED INDEX [ISELLER1] ON [Seller] ([CountryId] );

CREATE TABLE [Category] ([CategoryId] smallint NOT NULL IDENTITY(1,1), [CategoryName] nvarchar(40) NOT NULL , PRIMARY KEY([CategoryId]));
CREATE UNIQUE NONCLUSTERED INDEX [UCATEGORY] ON [Category] ([CategoryName] );

ALTER TABLE [Seller] ADD CONSTRAINT [ISELLER1] FOREIGN KEY ([CountryId]) REFERENCES [Country] ([CountryId]);

ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT3] FOREIGN KEY ([SellerId]) REFERENCES [Seller] ([SellerId]);
ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT2] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([SupplierId]);
ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT1] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([CategoryId]);

ALTER TABLE [Customer] ADD CONSTRAINT [ICUSTOMER1] FOREIGN KEY ([CountryId]) REFERENCES [Country] ([CountryId]);

ALTER TABLE [PointCard] ADD CONSTRAINT [IPOINTCARD1] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]);

