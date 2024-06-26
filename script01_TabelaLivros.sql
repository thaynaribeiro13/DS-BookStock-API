IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_LIVROS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Gênero] nvarchar(max) NOT NULL,
    [Autor] nvarchar(max) NOT NULL,
    [RegistroLivro] int NOT NULL,
    CONSTRAINT [PK_TB_LIVROS] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Autor', N'Gênero', N'Nome', N'RegistroLivro') AND [object_id] = OBJECT_ID(N'[TB_LIVROS]'))
    SET IDENTITY_INSERT [TB_LIVROS] ON;
INSERT INTO [TB_LIVROS] ([Id], [Autor], [Gênero], [Nome], [RegistroLivro])
VALUES (1, N'Emily Trunko', N'Drama', N'Últimas Mensagens Recebidas', 0),
(2, N'Taylor Jenkins Reid', N'Romance', N'Os Sete Maridos de Evelyn Hugo', 0),
(3, N'C. C. Hunter', N'Romance', N'Eu e Esse Meu Coração', 0),
(4, N'Suzanne Collins', N'Distopia Adolescente', N'Jogos Vorazes', 0),
(5, N'V. E. Schwab', N'Fantasia', N'A Sociedade Invisível de Addie LaRue', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Autor', N'Gênero', N'Nome', N'RegistroLivro') AND [object_id] = OBJECT_ID(N'[TB_LIVROS]'))
    SET IDENTITY_INSERT [TB_LIVROS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240429001119_InitialCreate', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_LIVROS] DROP CONSTRAINT [PK_TB_LIVROS];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_LIVROS]') AND [c].[name] = N'Nome');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TB_LIVROS] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TB_LIVROS] ALTER COLUMN [Nome] varchar(200) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_LIVROS]') AND [c].[name] = N'Gênero');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TB_LIVROS] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [TB_LIVROS] ALTER COLUMN [Gênero] varchar(200) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_LIVROS]') AND [c].[name] = N'Autor');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TB_LIVROS] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [TB_LIVROS] ALTER COLUMN [Autor] varchar(200) NOT NULL;
GO

ALTER TABLE [TB_LIVROS] ADD [UsuarioId] int NULL;
GO

ALTER TABLE [TB_LIVROS] ADD CONSTRAINT [PK_TB_LIVROS] PRIMARY KEY ([Id]);
GO

CREATE TABLE [TB_USUARIOS] (
    [Id] int NOT NULL IDENTITY,
    [Username] varchar(200) NOT NULL,
    [Nome] varchar(200) NOT NULL DEFAULT 'Comprador',
    [Email] varchar(200) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [listaLivro] int NOT NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Id])
);
GO

UPDATE [TB_LIVROS] SET [UsuarioId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_LIVROS] SET [UsuarioId] = 1
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_LIVROS] SET [UsuarioId] = 1
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_LIVROS] SET [UsuarioId] = 1
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_LIVROS] SET [UsuarioId] = 1
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Nome', N'PasswordHash', N'PasswordSalt', N'Username', N'listaLivro') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Id], [Email], [Nome], [PasswordHash], [PasswordSalt], [Username], [listaLivro])
VALUES (1, 'seuEmail@gmail.com', 'Admin', 0xC4A3466EFB335DDF6A5E972D4783DCF1EFC0D7EF2A41D1BB5BB828417CA9C8DEF930D64F41F7F10E452D90F3F36BDCFB89992C937475D4355D9A450A79F1B12F, 0x21127D2EB34F0E6934A3337289F0D0A246FB45CC382B7A7E25EFFF469176542AFF5ADB1D8CD6A6A9B843961379909E44C4AA61F1EAE6DD242FCB1BC513FFA59C86737742237183FF1E1A6F77C625FC894D688ADC715C819FB496574949CF1D684B16F0CBF732E5B28DBD12678A5C98DC550FF3E485D4AF21BB1E3B63C59FB74C, 'UsuarioAdmin', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Nome', N'PasswordHash', N'PasswordSalt', N'Username', N'listaLivro') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;
GO

CREATE INDEX [IX_TB_LIVROS_UsuarioId] ON [TB_LIVROS] ([UsuarioId]);
GO

ALTER TABLE [TB_LIVROS] ADD CONSTRAINT [FK_TB_LIVROS_TB_USUARIOS_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIOS] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240430230006_MigracaoInicial', N'8.0.4');
GO

COMMIT;
GO

