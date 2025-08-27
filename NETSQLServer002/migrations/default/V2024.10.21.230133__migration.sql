ALTER TABLE [ShoppingCart] ADD [ShoppingCartDebug] nvarchar(40) NOT NULL CONSTRAINT ShoppingCartDebugShoppingCart_DEFAULT DEFAULT '';
ALTER TABLE [ShoppingCart] DROP CONSTRAINT ShoppingCartDebugShoppingCart_DEFAULT;

