
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/06/2019 17:43:41
-- Generated from EDMX file: C:\Users\tian\source\repos\ConsoleApp1\everyday\AboutPersonDemo\WebApplication\Models\ModelFirst.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [Id] uniqueidentifier  NOT NULL,
    [OrderNumer] nvarchar(max)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [Status] smallint  NOT NULL
);
GO

-- Creating table 'OrderItem'
CREATE TABLE [dbo].[OrderItem] (
    [Id] uniqueidentifier  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Quantity] int  NOT NULL,
    [Order_Id] uniqueidentifier  NOT NULL,
    [Product_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [SalePrice] decimal(18,0)  NOT NULL,
    [PurchasePrice] decimal(18,0)  NOT NULL,
    [Category_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Status] smallint  NOT NULL,
    [ParentId] int  NOT NULL,
    [IsLeaf] bit  NOT NULL
);
GO

-- Creating table 'CategoryProery'
CREATE TABLE [dbo].[CategoryProery] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [IsRequire] bit  NOT NULL,
    [IsMult] bit  NOT NULL,
    [SortOrder] int  NOT NULL,
    [Category_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'CategoryProeryValue'
CREATE TABLE [dbo].[CategoryProeryValue] (
    [Id] uniqueidentifier  NOT NULL,
    [ValueData] nvarchar(max)  NOT NULL,
    [SortOrder] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [CategoryProery_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'OrderContract'
CREATE TABLE [dbo].[OrderContract] (
    [Id] uniqueidentifier  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Quantity] int  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [Unit] nvarchar(max)  NOT NULL,
    [Product_Id] uniqueidentifier  NOT NULL,
    [Order_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderItem'
ALTER TABLE [dbo].[OrderItem]
ADD CONSTRAINT [PK_OrderItem]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoryProery'
ALTER TABLE [dbo].[CategoryProery]
ADD CONSTRAINT [PK_CategoryProery]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoryProeryValue'
ALTER TABLE [dbo].[CategoryProeryValue]
ADD CONSTRAINT [PK_CategoryProeryValue]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderContract'
ALTER TABLE [dbo].[OrderContract]
ADD CONSTRAINT [PK_OrderContract]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Order_Id] in table 'OrderItem'
ALTER TABLE [dbo].[OrderItem]
ADD CONSTRAINT [FK_OrderOrderItem]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[Order]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderItem'
CREATE INDEX [IX_FK_OrderOrderItem]
ON [dbo].[OrderItem]
    ([Order_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'CategoryProery'
ALTER TABLE [dbo].[CategoryProery]
ADD CONSTRAINT [FK_Category_CategoryProery]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Category_CategoryProery'
CREATE INDEX [IX_FK_Category_CategoryProery]
ON [dbo].[CategoryProery]
    ([Category_Id]);
GO

-- Creating foreign key on [CategoryProery_Id] in table 'CategoryProeryValue'
ALTER TABLE [dbo].[CategoryProeryValue]
ADD CONSTRAINT [FK_CategoryProery_CategoryProeryValue]
    FOREIGN KEY ([CategoryProery_Id])
    REFERENCES [dbo].[CategoryProery]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryProery_CategoryProeryValue'
CREATE INDEX [IX_FK_CategoryProery_CategoryProeryValue]
ON [dbo].[CategoryProeryValue]
    ([CategoryProery_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'OrderItem'
ALTER TABLE [dbo].[OrderItem]
ADD CONSTRAINT [FK_OrderItem_Product]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Product]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItem_Product'
CREATE INDEX [IX_FK_OrderItem_Product]
ON [dbo].[OrderItem]
    ([Product_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_Category_Product]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Category_Product'
CREATE INDEX [IX_FK_Category_Product]
ON [dbo].[Product]
    ([Category_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'OrderContract'
ALTER TABLE [dbo].[OrderContract]
ADD CONSTRAINT [FK_OrderContract_Product]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Product]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderContract_Product'
CREATE INDEX [IX_FK_OrderContract_Product]
ON [dbo].[OrderContract]
    ([Product_Id]);
GO

-- Creating foreign key on [Order_Id] in table 'OrderContract'
ALTER TABLE [dbo].[OrderContract]
ADD CONSTRAINT [FK_OrderOrderContract]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[Order]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderContract'
CREATE INDEX [IX_FK_OrderOrderContract]
ON [dbo].[OrderContract]
    ([Order_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------