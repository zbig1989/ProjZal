
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/03/2018 14:01:15
-- Generated from EDMX file: c:\users\mati\documents\visual studio 2017\Projects\Fabryka2018\Fabryka2018\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FabrykaSPTI];
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

-- Creating table 'HaleSet'
CREATE TABLE [dbo].[HaleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Hala_Nazwa] nvarchar(max)  NOT NULL,
    [Adres] nvarchar(max)  NULL
);
GO

-- Creating table 'MaszynySet'
CREATE TABLE [dbo].[MaszynySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Maszyna_Nazwa] nvarchar(max)  NOT NULL,
    [Numer_ewidencji] decimal(18,0)  NULL,
    [Data_uruchomienia] datetime  NULL,
    [HalaId] int  NOT NULL,
    [HaleId] int  NOT NULL
);
GO

-- Creating table 'OperatorzySet'
CREATE TABLE [dbo].[OperatorzySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Imie] nvarchar(max)  NOT NULL,
    [Nazwisko] nvarchar(max)  NOT NULL,
    [Placa] float  NOT NULL,
    [Data_zatrrudnienia] datetime  NULL
);
GO

-- Creating table 'MaszynyOperatorzy'
CREATE TABLE [dbo].[MaszynyOperatorzy] (
    [Maszyny_Id] int  NOT NULL,
    [Operatorzy_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'HaleSet'
ALTER TABLE [dbo].[HaleSet]
ADD CONSTRAINT [PK_HaleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MaszynySet'
ALTER TABLE [dbo].[MaszynySet]
ADD CONSTRAINT [PK_MaszynySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperatorzySet'
ALTER TABLE [dbo].[OperatorzySet]
ADD CONSTRAINT [PK_OperatorzySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Maszyny_Id], [Operatorzy_Id] in table 'MaszynyOperatorzy'
ALTER TABLE [dbo].[MaszynyOperatorzy]
ADD CONSTRAINT [PK_MaszynyOperatorzy]
    PRIMARY KEY CLUSTERED ([Maszyny_Id], [Operatorzy_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HaleId] in table 'MaszynySet'
ALTER TABLE [dbo].[MaszynySet]
ADD CONSTRAINT [FK_HaleMaszyny]
    FOREIGN KEY ([HaleId])
    REFERENCES [dbo].[HaleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HaleMaszyny'
CREATE INDEX [IX_FK_HaleMaszyny]
ON [dbo].[MaszynySet]
    ([HaleId]);
GO

-- Creating foreign key on [Maszyny_Id] in table 'MaszynyOperatorzy'
ALTER TABLE [dbo].[MaszynyOperatorzy]
ADD CONSTRAINT [FK_MaszynyOperatorzy_Maszyny]
    FOREIGN KEY ([Maszyny_Id])
    REFERENCES [dbo].[MaszynySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Operatorzy_Id] in table 'MaszynyOperatorzy'
ALTER TABLE [dbo].[MaszynyOperatorzy]
ADD CONSTRAINT [FK_MaszynyOperatorzy_Operatorzy]
    FOREIGN KEY ([Operatorzy_Id])
    REFERENCES [dbo].[OperatorzySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaszynyOperatorzy_Operatorzy'
CREATE INDEX [IX_FK_MaszynyOperatorzy_Operatorzy]
ON [dbo].[MaszynyOperatorzy]
    ([Operatorzy_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------