
  SELECT *
  FROM [dbo].[Books]

  SELECT *
  FROM [dbo].Categories

  SELECT *
  FROM [dbo].[Sets]
  
  SELECT *
  FROM [dbo].BooksCategoriesBindings
  
  SELECT *
  FROM [dbo].BooksSetsBindings



  INSERT INTO dbo.Books (Title, Author, [Description], Isbn)
  Values
('Foundation', 'Isaac Asimov', '', ''),
('Space Odyssey', 'Arthur C Clarke', '', ''),
('Ubik', 'Philip K Dick', '', ''),
('Next', 'Philip K Dick', '', ''),
('Shadows In Flight', 'Orson Scott Card', '', ''),
('Clean Code', 'Uncle Bob', '', '')



  INSERT INTO dbo.Books (Title, Author, [Description], Isbn)
  Values
('111', '111', '', ''),
('2', '2', '', ''),
('3', '3', '', ''),
('4', '4', '', ''),
('5', '5', '', '')

GO

  INSERT INTO dbo.Categories ([Name])
  Values
('IT'), ('Fantasy'), ('Sience-fiction'), ('Miscellaneous')

GO 

  INSERT INTO dbo.[Sets] ([Name])
  Values
('Enderverse'), ('Foundation')



INSERT INTO dbo.BooksCategoriesBindings (BookId, CategoryId)
Values
(
	(Select ID FROM dbo.Books WHERE [Title] = 'Clean Code'), 
	(Select ID FROM dbo.Categories WHERE [Name] = 'IT')
),
(
	(Select ID FROM dbo.Books WHERE [Title] = 'Foundation'), 
	(Select ID FROM dbo.Categories WHERE [Name] = 'Sience-fiction')
),
(
	(Select ID FROM dbo.Books WHERE [Title] = 'Space Odyssey'), 
	(Select ID FROM dbo.Categories WHERE [Name] = 'Sience-fiction')
),
(
	(Select ID FROM dbo.Books WHERE [Title] = 'Ubik'), 
	(Select ID FROM dbo.Categories WHERE [Name] = 'Sience-fiction')
),
(
	(Select ID FROM dbo.Books WHERE [Title] = 'Next'), 
	(Select ID FROM dbo.Categories WHERE [Name] = 'Sience-fiction')
),
(
	(Select ID FROM dbo.Books WHERE [Title] = 'Shadows In Flight'), 
	(Select ID FROM dbo.Categories WHERE [Name] = 'Sience-fiction')
)


INSERT INTO dbo.[BooksSetsBindings] (BookId, SetId)
Values
(
	(Select ID FROM dbo.Books WHERE [Title] = 'Shadows In Flight'), 
	(Select ID FROM dbo.[Sets] WHERE [Name] = 'Enderverse')
),
(
	(Select ID FROM dbo.Books WHERE [Title] = 'Foundation'), 
	(Select ID FROM dbo.[Sets] WHERE [Name] = 'Foundation')
)
