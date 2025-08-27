CREATE TABLE [Country] ([CountryId] smallint NOT NULL IDENTITY(1,1), [CountryName] nvarchar(40) NOT NULL , [CountryFlag] VARBINARY(MAX) NOT NULL , [CountryFlag_GXI] varchar(2048) NULL , PRIMARY KEY([CountryId]));
CREATE UNIQUE NONCLUSTERED INDEX [UCOUNTRY] ON [Country] ([CountryName] );

