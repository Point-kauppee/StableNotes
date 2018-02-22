
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/25/2017 13:28:14
-- Generated from EDMX file: C:\Users\eero\Source\Repos\StableNotes\StableNotes\Models\StableNotesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EkaDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Action_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action] DROP CONSTRAINT [FK_Action_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_Action_ToTable_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action] DROP CONSTRAINT [FK_Action_ToTable_1];
GO
IF OBJECT_ID(N'[dbo].[FK_Action_ToTable_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action] DROP CONSTRAINT [FK_Action_ToTable_2];
GO
IF OBJECT_ID(N'[dbo].[FK_Action_ToTable_3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action] DROP CONSTRAINT [FK_Action_ToTable_3];
GO
IF OBJECT_ID(N'[dbo].[FK_Action_ToTable_4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action] DROP CONSTRAINT [FK_Action_ToTable_4];
GO
IF OBJECT_ID(N'[dbo].[FK_Action_ToTable_5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action] DROP CONSTRAINT [FK_Action_ToTable_5];
GO
IF OBJECT_ID(N'[dbo].[FK_Action_ToTable_6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action] DROP CONSTRAINT [FK_Action_ToTable_6];
GO
IF OBJECT_ID(N'[dbo].[FK_Address_ToTable_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address] DROP CONSTRAINT [FK_Address_ToTable_1];
GO
IF OBJECT_ID(N'[dbo].[FK_Horse_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Horse] DROP CONSTRAINT [FK_Horse_ToTable];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Action]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Action];
GO
IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[Care]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Care];
GO
IF OBJECT_ID(N'[dbo].[Food]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Food];
GO
IF OBJECT_ID(N'[dbo].[Foodsupplement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Foodsupplement];
GO
IF OBJECT_ID(N'[dbo].[Hoofing]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hoofing];
GO
IF OBJECT_ID(N'[dbo].[Horse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Horse];
GO
IF OBJECT_ID(N'[dbo].[Medicine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Medicine];
GO
IF OBJECT_ID(N'[dbo].[Phone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phone];
GO
IF OBJECT_ID(N'[dbo].[Stable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stable];
GO
IF OBJECT_ID(N'[dbo].[Training]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Training];
GO
IF OBJECT_ID(N'[kauppeedbModelStoreContainer].[Event]', 'U') IS NOT NULL
    DROP TABLE [kauppeedbModelStoreContainer].[Event];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Action'
CREATE TABLE [dbo].[Action] (
    [ActionId] nvarchar(10)  NOT NULL,
    [Date] datetime  NULL,
    [Start] datetime  NULL,
    [End] datetime  NULL,
    [Note] nvarchar(50)  NULL,
    [HorseId] nvarchar(10)  NULL,
    [HoofingId] nvarchar(10)  NULL,
    [FoodsupplementId] nvarchar(10)  NULL,
    [FoodId] nvarchar(10)  NULL,
    [CareId] nvarchar(10)  NULL,
    [MedicineId] nvarchar(10)  NULL,
    [TrainingId] nvarchar(10)  NULL
);
GO

-- Creating table 'Address'
CREATE TABLE [dbo].[Address] (
    [AddressId] nvarchar(10)  NOT NULL,
    [Streetname] nvarchar(50)  NULL,
    [Postnumber] nvarchar(50)  NULL,
    [Community] nvarchar(50)  NULL,
    [PersonId] nvarchar(10)  NULL,
    [StableId] nvarchar(10)  NULL
);
GO

-- Creating table 'Care'
CREATE TABLE [dbo].[Care] (
    [CareId] nvarchar(10)  NOT NULL,
    [Type] nvarchar(50)  NULL,
    [Quantity] nvarchar(50)  NULL,
    [Note] nvarchar(50)  NULL,
    [PersonId] nvarchar(10)  NULL
);
GO

-- Creating table 'Food'
CREATE TABLE [dbo].[Food] (
    [FoodId] nvarchar(10)  NOT NULL,
    [Type] nvarchar(50)  NULL,
    [Quantity] nvarchar(50)  NULL,
    [Note] nvarchar(50)  NULL,
    [URL] nvarchar(100)  NULL,
    [Purchaced] datetime  NULL
);
GO

-- Creating table 'Foodsupplement'
CREATE TABLE [dbo].[Foodsupplement] (
    [FoodsupplementId] nvarchar(10)  NOT NULL,
    [Type] nvarchar(50)  NULL,
    [Quantity] nvarchar(50)  NULL,
    [Note] nvarchar(50)  NULL,
    [URL] nvarchar(100)  NULL,
    [Withdrawalperiod] nvarchar(50)  NULL,
    [Purchaced] datetime  NULL
);
GO

-- Creating table 'Hoofing'
CREATE TABLE [dbo].[Hoofing] (
    [HoofingId] nvarchar(10)  NOT NULL,
    [Frontshoe] nvarchar(50)  NULL,
    [Frontsize] nvarchar(50)  NULL,
    [Frontangle] nvarchar(50)  NULL,
    [Frontlength] nvarchar(50)  NULL,
    [Backshoe] nvarchar(50)  NULL,
    [Backsize] nvarchar(50)  NULL,
    [Backangle] nvarchar(50)  NULL,
    [Backlength] nvarchar(50)  NULL
);
GO

-- Creating table 'Horse'
CREATE TABLE [dbo].[Horse] (
    [HorseId] nvarchar(10)  NOT NULL,
    [Horsename] nvarchar(50)  NOT NULL,
    [Horseregisternumber] nvarchar(50)  NULL,
    [HorseURL] nvarchar(100)  NULL,
    [Horsenote] nvarchar(100)  NULL,
    [Horsecreated] datetime  NULL,
    [StableId] nvarchar(10)  NULL,
    [PersonId] nvarchar(10)  NULL,
    [UserId] nvarchar(10)  NULL
);
GO

-- Creating table 'Medicine'
CREATE TABLE [dbo].[Medicine] (
    [MedicineId] nvarchar(10)  NOT NULL,
    [Type] nvarchar(50)  NULL,
    [Quantity] nvarchar(50)  NULL,
    [Note] nvarchar(50)  NULL,
    [URL] nvarchar(100)  NULL,
    [Withdrawalperiod] nvarchar(50)  NULL,
    [Purchaced] datetime  NULL
);
GO

-- Creating table 'Phone'
CREATE TABLE [dbo].[Phone] (
    [PhoneId] nvarchar(10)  NOT NULL,
    [Number] nvarchar(50)  NULL,
    [Number_1] nvarchar(50)  NULL,
    [Number_2] nvarchar(50)  NULL,
    [PersonId] nvarchar(10)  NULL
);
GO

-- Creating table 'Stable'
CREATE TABLE [dbo].[Stable] (
    [StableId] nvarchar(10)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Registernumber] nvarchar(50)  NULL,
    [Note] nvarchar(50)  NULL,
    [Created] datetime  NULL,
    [UserId] nvarchar(10)  NULL
);
GO

-- Creating table 'Training'
CREATE TABLE [dbo].[Training] (
    [TrainingId] nvarchar(10)  NOT NULL,
    [Type] nvarchar(50)  NULL,
    [Quantity] nvarchar(50)  NULL,
    [Note] nvarchar(50)  NULL
);
GO

-- Creating table 'Event'
CREATE TABLE [dbo].[Event] (
    [id] int  NOT NULL,
    [text] nvarchar(50)  NULL,
    [eventstart] nvarchar(10)  NULL,
    [eventend] nvarchar(10)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ActionId] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [PK_Action]
    PRIMARY KEY CLUSTERED ([ActionId] ASC);
GO

-- Creating primary key on [AddressId] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [PK_Address]
    PRIMARY KEY CLUSTERED ([AddressId] ASC);
GO

-- Creating primary key on [CareId] in table 'Care'
ALTER TABLE [dbo].[Care]
ADD CONSTRAINT [PK_Care]
    PRIMARY KEY CLUSTERED ([CareId] ASC);
GO

-- Creating primary key on [FoodId] in table 'Food'
ALTER TABLE [dbo].[Food]
ADD CONSTRAINT [PK_Food]
    PRIMARY KEY CLUSTERED ([FoodId] ASC);
GO

-- Creating primary key on [FoodsupplementId] in table 'Foodsupplement'
ALTER TABLE [dbo].[Foodsupplement]
ADD CONSTRAINT [PK_Foodsupplement]
    PRIMARY KEY CLUSTERED ([FoodsupplementId] ASC);
GO

-- Creating primary key on [HoofingId] in table 'Hoofing'
ALTER TABLE [dbo].[Hoofing]
ADD CONSTRAINT [PK_Hoofing]
    PRIMARY KEY CLUSTERED ([HoofingId] ASC);
GO

-- Creating primary key on [HorseId] in table 'Horse'
ALTER TABLE [dbo].[Horse]
ADD CONSTRAINT [PK_Horse]
    PRIMARY KEY CLUSTERED ([HorseId] ASC);
GO

-- Creating primary key on [MedicineId] in table 'Medicine'
ALTER TABLE [dbo].[Medicine]
ADD CONSTRAINT [PK_Medicine]
    PRIMARY KEY CLUSTERED ([MedicineId] ASC);
GO

-- Creating primary key on [PhoneId] in table 'Phone'
ALTER TABLE [dbo].[Phone]
ADD CONSTRAINT [PK_Phone]
    PRIMARY KEY CLUSTERED ([PhoneId] ASC);
GO

-- Creating primary key on [StableId] in table 'Stable'
ALTER TABLE [dbo].[Stable]
ADD CONSTRAINT [PK_Stable]
    PRIMARY KEY CLUSTERED ([StableId] ASC);
GO

-- Creating primary key on [TrainingId] in table 'Training'
ALTER TABLE [dbo].[Training]
ADD CONSTRAINT [PK_Training]
    PRIMARY KEY CLUSTERED ([TrainingId] ASC);
GO

-- Creating primary key on [id] in table 'Event'
ALTER TABLE [dbo].[Event]
ADD CONSTRAINT [PK_Event]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HorseId] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [FK_Action_ToTable]
    FOREIGN KEY ([HorseId])
    REFERENCES [dbo].[Horse]
        ([HorseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_ToTable'
CREATE INDEX [IX_FK_Action_ToTable]
ON [dbo].[Action]
    ([HorseId]);
GO

-- Creating foreign key on [HoofingId] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [FK_Action_ToTable_1]
    FOREIGN KEY ([HoofingId])
    REFERENCES [dbo].[Hoofing]
        ([HoofingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_ToTable_1'
CREATE INDEX [IX_FK_Action_ToTable_1]
ON [dbo].[Action]
    ([HoofingId]);
GO

-- Creating foreign key on [FoodsupplementId] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [FK_Action_ToTable_2]
    FOREIGN KEY ([FoodsupplementId])
    REFERENCES [dbo].[Foodsupplement]
        ([FoodsupplementId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_ToTable_2'
CREATE INDEX [IX_FK_Action_ToTable_2]
ON [dbo].[Action]
    ([FoodsupplementId]);
GO

-- Creating foreign key on [FoodId] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [FK_Action_ToTable_3]
    FOREIGN KEY ([FoodId])
    REFERENCES [dbo].[Food]
        ([FoodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_ToTable_3'
CREATE INDEX [IX_FK_Action_ToTable_3]
ON [dbo].[Action]
    ([FoodId]);
GO

-- Creating foreign key on [CareId] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [FK_Action_ToTable_4]
    FOREIGN KEY ([CareId])
    REFERENCES [dbo].[Care]
        ([CareId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_ToTable_4'
CREATE INDEX [IX_FK_Action_ToTable_4]
ON [dbo].[Action]
    ([CareId]);
GO

-- Creating foreign key on [MedicineId] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [FK_Action_ToTable_5]
    FOREIGN KEY ([MedicineId])
    REFERENCES [dbo].[Medicine]
        ([MedicineId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_ToTable_5'
CREATE INDEX [IX_FK_Action_ToTable_5]
ON [dbo].[Action]
    ([MedicineId]);
GO

-- Creating foreign key on [TrainingId] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [FK_Action_ToTable_6]
    FOREIGN KEY ([TrainingId])
    REFERENCES [dbo].[Training]
        ([TrainingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_ToTable_6'
CREATE INDEX [IX_FK_Action_ToTable_6]
ON [dbo].[Action]
    ([TrainingId]);
GO

-- Creating foreign key on [StableId] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [FK_Address_ToTable_1]
    FOREIGN KEY ([StableId])
    REFERENCES [dbo].[Stable]
        ([StableId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Address_ToTable_1'
CREATE INDEX [IX_FK_Address_ToTable_1]
ON [dbo].[Address]
    ([StableId]);
GO

-- Creating foreign key on [StableId] in table 'Horse'
ALTER TABLE [dbo].[Horse]
ADD CONSTRAINT [FK_Horse_ToTable]
    FOREIGN KEY ([StableId])
    REFERENCES [dbo].[Stable]
        ([StableId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Horse_ToTable'
CREATE INDEX [IX_FK_Horse_ToTable]
ON [dbo].[Horse]
    ([StableId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------