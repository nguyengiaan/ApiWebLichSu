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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240216130754_up1')
BEGIN
    CREATE TABLE [Catogery] (
        [ID_CATOGERY] int NOT NULL IDENTITY,
        [NAME_CATOGERY] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Catogery] PRIMARY KEY ([ID_CATOGERY])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240216130754_up1')
BEGIN
    CREATE TABLE [Users] (
        [ID_USER] int NOT NULL IDENTITY,
        [NAME_USER] nvarchar(100) NOT NULL,
        [USERNAME] nvarchar(100) NOT NULL,
        [PASSWORD_USER] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([ID_USER])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240216130754_up1')
BEGIN
    CREATE TABLE [Comment] (
        [COMNENT_ID] int NOT NULL IDENTITY,
        [ID_USER] int NOT NULL,
        [CONTENT_COMMENT] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Comment] PRIMARY KEY ([COMNENT_ID]),
        CONSTRAINT [FK_Comment_Users_ID_USER] FOREIGN KEY ([ID_USER]) REFERENCES [Users] ([ID_USER]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240216130754_up1')
BEGIN
    CREATE TABLE [History] (
        [ID_HISTORY] int NOT NULL IDENTITY,
        [CONTENT] nvarchar(max) NOT NULL,
        [ID_USER] int NOT NULL,
        [DATESUBMIT] datetime2 NOT NULL,
        [ID_CATOGERY] int NOT NULL,
        [TITLE] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_History] PRIMARY KEY ([ID_HISTORY]),
        CONSTRAINT [FK_History_Catogery_ID_CATOGERY] FOREIGN KEY ([ID_CATOGERY]) REFERENCES [Catogery] ([ID_CATOGERY]) ON DELETE CASCADE,
        CONSTRAINT [FK_History_Users_ID_USER] FOREIGN KEY ([ID_USER]) REFERENCES [Users] ([ID_USER]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240216130754_up1')
BEGIN
    CREATE TABLE [Permission] (
        [PER_ID] int NOT NULL IDENTITY,
        [ID_USER] int NOT NULL,
        [CONTENT_PERMISSION] nvarchar(10) NOT NULL,
        CONSTRAINT [PK_Permission] PRIMARY KEY ([PER_ID]),
        CONSTRAINT [FK_Permission_Users_ID_USER] FOREIGN KEY ([ID_USER]) REFERENCES [Users] ([ID_USER]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240216130754_up1')
BEGIN
    CREATE INDEX [IX_Comment_ID_USER] ON [Comment] ([ID_USER]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240216130754_up1')
BEGIN
    CREATE INDEX [IX_History_ID_CATOGERY] ON [History] ([ID_CATOGERY]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240216130754_up1')
BEGIN
    CREATE INDEX [IX_History_ID_USER] ON [History] ([ID_USER]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240216130754_up1')
BEGIN
    CREATE INDEX [IX_Permission_ID_USER] ON [Permission] ([ID_USER]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240216130754_up1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240216130754_up1', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240313084713_AddIdentity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240313084713_AddIdentity', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240321161821_1')
BEGIN
    CREATE TABLE [Quest] (
        [Id_quest] int NOT NULL IDENTITY,
        [Question] nvarchar(max) NOT NULL,
        [ID_USER] int NOT NULL,
        CONSTRAINT [PK_Quest] PRIMARY KEY ([Id_quest]),
        CONSTRAINT [FK_Quest_Users_ID_USER] FOREIGN KEY ([ID_USER]) REFERENCES [Users] ([ID_USER]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240321161821_1')
BEGIN
    CREATE TABLE [AnswerQuest] (
        [id_Answer] int NOT NULL IDENTITY,
        [answer] nvarchar(max) NOT NULL,
        [Id_quest] int NOT NULL,
        CONSTRAINT [PK_AnswerQuest] PRIMARY KEY ([id_Answer]),
        CONSTRAINT [FK_AnswerQuest_Quest_Id_quest] FOREIGN KEY ([Id_quest]) REFERENCES [Quest] ([Id_quest]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240321161821_1')
BEGIN
    CREATE TABLE [Question] (
        [Id_Question] int NOT NULL IDENTITY,
        [Question_quest] nvarchar(max) NOT NULL,
        [Id_quest] int NOT NULL,
        [AnswerQuestid_Answer] int NOT NULL,
        CONSTRAINT [PK_Question] PRIMARY KEY ([Id_Question]),
        CONSTRAINT [FK_Question_AnswerQuest_AnswerQuestid_Answer] FOREIGN KEY ([AnswerQuestid_Answer]) REFERENCES [AnswerQuest] ([id_Answer]) ON DELETE CASCADE,
        CONSTRAINT [FK_Question_Quest_Id_quest] FOREIGN KEY ([Id_quest]) REFERENCES [Quest] ([Id_quest]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240321161821_1')
BEGIN
    CREATE UNIQUE INDEX [IX_AnswerQuest_Id_quest] ON [AnswerQuest] ([Id_quest]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240321161821_1')
BEGIN
    CREATE INDEX [IX_Quest_ID_USER] ON [Quest] ([ID_USER]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240321161821_1')
BEGIN
    CREATE INDEX [IX_Question_AnswerQuestid_Answer] ON [Question] ([AnswerQuestid_Answer]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240321161821_1')
BEGIN
    CREATE INDEX [IX_Question_Id_quest] ON [Question] ([Id_quest]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240321161821_1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240321161821_1', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240326055955_addtablequex')
BEGIN
    CREATE TABLE [QuestCollection] (
        [id_questcollection] int NOT NULL IDENTITY,
        [title_collection] nvarchar(max) NOT NULL,
        [image_quest] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_QuestCollection] PRIMARY KEY ([id_questcollection])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240326055955_addtablequex')
BEGIN
    ALTER TABLE [Quest] ADD [id_questcollection] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240326055955_addtablequex')
BEGIN
    ALTER TABLE [Quest] ADD CONSTRAINT [FK_QuestCollection] FOREIGN KEY ([id_questcollection]) REFERENCES [QuestCollection] ([id_questcollection]) ON UPDATE CASCADE ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240326055955_addtablequex')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240326055955_addtablequex', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082212_add-migration drop-key')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240330082212_add-migration drop-key', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    ALTER TABLE [Comment] DROP CONSTRAINT [FK_Comment_Users_ID_USER];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    ALTER TABLE [Comment] ADD [Id] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    ALTER TABLE [Comment] ADD CONSTRAINT [FK_Comment_Users_ID_USER] FOREIGN KEY ([id]) REFERENCES [AspNetUsers] ([id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    ALTER TABLE [History] DROP CONSTRAINT [FK_History_Users_ID_USER];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    ALTER TABLE [History] ADD [Id] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    ALTER TABLE [History] ADD CONSTRAINT [FK_History_Users_ID_USER] FOREIGN KEY ([Id]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    ALTER TABLE [Permission] DROP CONSTRAINT [FK_Permission_Users_ID_USER];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    DROP TABLE [Permission];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    ALTER TABLE [Quest] DROP CONSTRAINT [FK_Quest_Users_ID_USER];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    ALTER TABLE [Quest] ADD [Id] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    ALTER TABLE [Quest] ADD CONSTRAINT [FK_Quest_Users_ID_USER] FOREIGN KEY ([Id]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    DROP TABLE [Users];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240330082443_drop_column')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240330082443_drop_column', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240331082041_up2')
BEGIN
    DROP INDEX [IX_Quest_ID_USER] ON [Quest];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240331082041_up2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Quest]') AND [c].[name] = N'ID_USER');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Quest] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Quest] DROP COLUMN [ID_USER];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240331082041_up2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240331082041_up2', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240403161630_up4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240403161630_up4', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404144353_ụp')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240404144353_ụp', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404144444_up6')
BEGIN
    ALTER TABLE [Quest] ADD [UsersID_USER] nvarchar(255) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404144444_up6')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240404144444_up6', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404151850_up7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240404151850_up7', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404153247_up11')
BEGIN
    EXEC sp_rename N'[Question].[AnswerQuestid_Answer]', N'id_Answer', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404153247_up11')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240404153247_up11', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404154444_up12')
BEGIN
    ALTER TABLE [Question] ADD [AnswerQuestid_Answer] nvarchar(255) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404154444_up12')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240404154444_up12', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404160004_úp3')
BEGIN
    ALTER TABLE [QuestCollection] ADD [Id] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404160004_úp3')
BEGIN
    ALTER TABLE [QuestCollection] ADD CONSTRAINT [FK_QuestCollection_Users_ID_USER] FOREIGN KEY ([id]) REFERENCES [AspNetUsers] ([id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240404160004_úp3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240404160004_úp3', N'6.0.0');
END;
GO

COMMIT;
GO

