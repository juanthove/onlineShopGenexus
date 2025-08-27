CREATE TABLE [PromotionProduct] ([PromotionId] smallint NOT NULL , [ProductId] smallint NOT NULL , PRIMARY KEY([PromotionId], [ProductId]));
CREATE NONCLUSTERED INDEX [IPROMOTIONPRODUCT1] ON [PromotionProduct] ([ProductId] );

ALTER TABLE [PromotionProduct] ADD CONSTRAINT [IPROMOTIONPRODUCT2] FOREIGN KEY ([PromotionId]) REFERENCES [Promotion] ([PromotionId]);
ALTER TABLE [PromotionProduct] ADD CONSTRAINT [IPROMOTIONPRODUCT1] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]);

