USE [EFRawQueriesDemo]

CREATE TABLE [dbo].[Movies] (
    [Id]          INT             NOT NULL,
    [Title]       NVARCHAR (200)  NOT NULL,
    [Overview]    NVARCHAR (200)  NULL,
    [ReleaseDate] DATETIME        NULL,
    [Popularity]  REAL            NULL,
    [VoteCount]   INT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE PROCEDURE GetMoviesById
@Id INT
AS
SELECT * FROM Movies WHERE Id = @Id

GO

CREATE PROCEDURE GetMoviesByOverview
@Overview NVARCHAR(200)
AS
SELECT * FROM Movies WHERE Overview = @Overview OR (@Overview IS NULL AND Overview IS NULL)

GO

CREATE PROCEDURE GetMoviesByVoteCount
@VoteCount INT NULL
AS
SELECT * FROM Movies WHERE VoteCount = @VoteCount OR (@VoteCount IS NULL AND VoteCount IS NULL)

GO

CREATE PROCEDURE GetMovies
@Id INT,
@Overview NVARCHAR(200) = NULL,
@VoteCount INT = NULL
AS
SELECT * FROM Movies WHERE 
Id = @Id 
AND Overview = @Overview OR (@Overview IS NULL)
AND VoteCount = @VoteCount OR (@VoteCount IS NULL)

GO

INSERT [dbo].[Movies] ([Id], [Title], [Overview], [ReleaseDate], [Popularity], [VoteCount]) VALUES (1, N'Movie1', N'Overview1', CAST(N'2023-12-20T00:00:00.000' AS DateTime), CAST(5.12 AS Decimal(18, 2)), 3)
INSERT [dbo].[Movies] ([Id], [Title], [Overview], [ReleaseDate], [Popularity], [VoteCount]) VALUES (2, N'Movie2', N'Overview2', CAST(N'2023-12-21T00:00:00.000' AS DateTime), CAST(9.81 AS Decimal(18, 2)), 5)
INSERT [dbo].[Movies] ([Id], [Title], [Overview], [ReleaseDate], [Popularity], [VoteCount]) VALUES (3, N'Movie3', NULL, NULL, NULL, NULL)
GO
