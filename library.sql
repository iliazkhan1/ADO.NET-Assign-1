CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100)
);

CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200),
    AuthorID INT FOREIGN KEY REFERENCES Authors(AuthorID),
    PublishedYear INT,
    IsAvailable BIT
);

INSERT INTO Authors (Name)
VALUES 
('J.K. Rowling'),
('George R.R. Martin'),
('J.R.R. Tolkien'),
('Dan Brown'),
('Agatha Christie');

INSERT INTO Books (Title, AuthorID, PublishedYear, IsAvailable)
VALUES 
('Harry Potter and the Sorcerer''s Stone', 1, 1997, 1),
('A Game of Thrones', 2, 1996, 1),
('The Hobbit', 3, 1937, 1),
('The Da Vinci Code', 4, 2003, 1),
('Murder on the Orient Express', 5, 1934, 1),
('Harry Potter and the Chamber of Secrets', 1, 1998, 1),
('A Clash of Kings', 2, 1998, 0),
('The Lord of the Rings', 3, 1954, 1),
('Angels and Demons', 4, 2000, 0),
('And Then There Were None', 5, 1939, 1);

CREATE PROCEDURE AddBook
    @Title NVARCHAR(200),
    @AuthorID INT,
    @PublishedYear INT,
    @IsAvailable BIT
AS
BEGIN
    INSERT INTO Books (Title, AuthorID, PublishedYear, IsAvailable)
    VALUES (@Title, @AuthorID, @PublishedYear, @IsAvailable);
END;


CREATE PROCEDURE GetAllBooks
AS
BEGIN
    SELECT 
        b.BookID, 
        b.Title, 
        a.Name AS Author, 
        b.PublishedYear, 
        b.IsAvailable
    FROM Books b
    JOIN Authors a ON b.AuthorID = a.AuthorID;
END;

CREATE PROCEDURE UpdateBook
    @BookID INT,
    @Title NVARCHAR(200),
    @AuthorID INT,
    @PublishedYear INT,
    @IsAvailable BIT
AS
BEGIN
    UPDATE Books
    SET 
        Title = @Title,
        AuthorID = @AuthorID,
        PublishedYear = @PublishedYear,
        IsAvailable = @IsAvailable
    WHERE BookID = @BookID;
END;

CREATE PROCEDURE DeleteBook
    @BookID INT
AS
BEGIN
    DELETE FROM Books WHERE BookID = @BookID;
END;




select *  from Authors
select * from Books B JOIN Authors A ON A.AuthorID = B.AuthorID order by 1 desc