

DROP TABLE [dbo].[BooksCategoriesBindings]
GO
DROP TABLE [dbo].[BooksSetsBindings]
GO
DROP TABLE [dbo].[Sets]
GO
DROP TABLE [dbo].[Categories]
GO
DROP TABLE [dbo].[Books]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Books](
	[ID] [int] identity(1,1) NOT NULL,
	[Timestamp] timestamp NOT NULL, 
	[Title] nvarchar(100) NOT NULL,
	[Author] nvarchar(100) NOT NULL,
	[Description] nvarchar(400) NOT NULL,
	[Isbn] nvarchar(100) NOT NULL,

	CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([ID] ASC)
) ON [PRIMARY]
GO

--------------------------------
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sets](
	[ID] [int] identity(1,1) NOT NULL,
	[Timestamp] timestamp NOT NULL, 
	[Name] nvarchar(100) NOT NULL,
	CONSTRAINT [PK_Set] PRIMARY KEY CLUSTERED ([ID] ASC)
) ON [PRIMARY]
GO

--------------------------


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories](
	[ID] [int] identity(1,1) NOT NULL,
	[Timestamp] timestamp NOT NULL, 
	[Name] nvarchar(100) NOT NULL,
	CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([ID] ASC)
) ON [PRIMARY]
GO

----------------------------------------



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BooksSetsBindings](
	[ID] [int] identity(1,1) NOT NULL,
	[Timestamp] timestamp NOT NULL, 
	BookId int NOT NULL,
	SetId int NOT NULL,
	CONSTRAINT [PK_BooksSetsBindings] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT FK_BooksSetsBindings_BookId FOREIGN KEY (BookId)  REFERENCES [Books](ID),
	CONSTRAINT FK_BooksSetsBindings_SetId FOREIGN KEY (SetId)  REFERENCES [Sets](ID)
) ON [PRIMARY]
GO


----------------------------------------

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BooksCategoriesBindings](
	[ID] [int] identity(1,1) NOT NULL,
	[Timestamp] timestamp NOT NULL, 
	BookId int NOT NULL,
	CategoryId int NOT NULL,
	CONSTRAINT [PK_BooksCategoriesBindings] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT FK_BooksCategoriesBindings_BookId FOREIGN KEY (BookId)  REFERENCES [Books](ID),
	CONSTRAINT FK_BooksCategoriesBindings_CategoryId FOREIGN KEY (CategoryId)  REFERENCES [Categories](ID)
) ON [PRIMARY]
GO

