
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/09/2019 17:25:42
-- Generated from EDMX file: C:\Users\37770\source\repos\everyday\AboutPersonDemo\WebApplication\Models\DDD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MY7W];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OrderOrderLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderLine] DROP CONSTRAINT [FK_OrderOrderLine];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderLineItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderLine] DROP CONSTRAINT [FK_OrderLineItem];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerCreditCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditCard] DROP CONSTRAINT [FK_CustomerCreditCard];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_CustomerOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Item] DROP CONSTRAINT [FK_ItemCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesOrder_inherits_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_SalesOrder] DROP CONSTRAINT [FK_SalesOrder_inherits_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_ReturnOrder_inherits_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_ReturnOrder] DROP CONSTRAINT [FK_ReturnOrder_inherits_Order];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[OrderLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderLine];
GO
IF OBJECT_ID(N'[dbo].[CreditCard]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditCard];
GO
IF OBJECT_ID(N'[dbo].[Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Item];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Order_SalesOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order_SalesOrder];
GO
IF OBJECT_ID(N'[dbo].[Order_ReturnOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order_ReturnOrder];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customer'
CREATE TABLE [dbo].[Customer] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LoginName] nvarchar(max)  NOT NULL,
    [CreateDate] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreateDate] nvarchar(max)  NOT NULL,
    [Customer_Id] int  NOT NULL
);
GO

-- Creating table 'OrderLine'
CREATE TABLE [dbo].[OrderLine] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] decimal(18,0)  NOT NULL,
    [Discount] int  NOT NULL,
    [Order_Id] int  NOT NULL,
    [Item_Id] int  NOT NULL
);
GO

-- Creating table 'CreditCard'
CREATE TABLE [dbo].[CreditCard] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Customer_Id] int  NOT NULL
);
GO

-- Creating table 'Item'
CREATE TABLE [dbo].[Item] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SalesPrice] decimal(18,0)  NOT NULL,
    [Category_Id] int  NOT NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Order_SalesOrder'
CREATE TABLE [dbo].[Order_SalesOrder] (
    [ShippingDate] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Order_ReturnOrder'
CREATE TABLE [dbo].[Order_ReturnOrder] (
    [ReturnDate] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [PK_Customer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderLine'
ALTER TABLE [dbo].[OrderLine]
ADD CONSTRAINT [PK_OrderLine]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CreditCard'
ALTER TABLE [dbo].[CreditCard]
ADD CONSTRAINT [PK_CreditCard]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Item'
ALTER TABLE [dbo].[Item]
ADD CONSTRAINT [PK_Item]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order_SalesOrder'
ALTER TABLE [dbo].[Order_SalesOrder]
ADD CONSTRAINT [PK_Order_SalesOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order_ReturnOrder'
ALTER TABLE [dbo].[Order_ReturnOrder]
ADD CONSTRAINT [PK_Order_ReturnOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Order_Id] in table 'OrderLine'
ALTER TABLE [dbo].[OrderLine]
ADD CONSTRAINT [FK_OrderOrderLine]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[Order]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderLine'
CREATE INDEX [IX_FK_OrderOrderLine]
ON [dbo].[OrderLine]
    ([Order_Id]);
GO

-- Creating foreign key on [Item_Id] in table 'OrderLine'
ALTER TABLE [dbo].[OrderLine]
ADD CONSTRAINT [FK_OrderLineItem]
    FOREIGN KEY ([Item_Id])
    REFERENCES [dbo].[Item]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderLineItem'
CREATE INDEX [IX_FK_OrderLineItem]
ON [dbo].[OrderLine]
    ([Item_Id]);
GO

-- Creating foreign key on [Customer_Id] in table 'CreditCard'
ALTER TABLE [dbo].[CreditCard]
ADD CONSTRAINT [FK_CustomerCreditCard]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerCreditCard'
CREATE INDEX [IX_FK_CustomerCreditCard]
ON [dbo].[CreditCard]
    ([Customer_Id]);
GO

-- Creating foreign key on [Customer_Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[Order]
    ([Customer_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'Item'
ALTER TABLE [dbo].[Item]
ADD CONSTRAINT [FK_ItemCategory]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemCategory'
CREATE INDEX [IX_FK_ItemCategory]
ON [dbo].[Item]
    ([Category_Id]);
GO

-- Creating foreign key on [Id] in table 'Order_SalesOrder'
ALTER TABLE [dbo].[Order_SalesOrder]
ADD CONSTRAINT [FK_SalesOrder_inherits_Order]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Order]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Order_ReturnOrder'
ALTER TABLE [dbo].[Order_ReturnOrder]
ADD CONSTRAINT [FK_ReturnOrder_inherits_Order]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Order]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------