use [db_baffaLibrary]
go

create proc dbo.uspQuestion2 @book varchar(30)
as
	select BranchName,No_Of_Copies
	from LIBRARY_BRANCH
		inner join BOOK_COPIES on LIBRARY_BRANCH.BranchId = BOOK_COPIES.BranchId
		inner join BOOK on BOOK_COPIES.BookId = BOOK.BookId
	where
		BOOK.Title = @book
go

--exec dbo.uspQuestion2 @book = 'The Lost Tribe'
