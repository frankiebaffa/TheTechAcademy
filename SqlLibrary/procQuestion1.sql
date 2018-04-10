use [db_baffaLibrary]
go

create proc dbo.uspQuestion1 @branch varchar(30), @book varchar(30)
as
	select BranchName,Title,No_Of_Copies
	from BOOK_COPIES
	inner join LIBRARY_BRANCH on BOOK_COPIES.BranchId = LIBRARY_BRANCH.BranchId
	inner join BOOK on BOOK_COPIES.BookId = BOOK.BookId
	where
		BOOK.Title = @book and
		LIBRARY_BRANCH.BranchName = @branch
go

--exec dbo.uspQuestion1 @branch = 'Sharpstown', @book = 'The Lost Tribe'