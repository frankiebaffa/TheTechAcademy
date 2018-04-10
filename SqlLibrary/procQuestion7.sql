use db_baffaLibrary
go

create proc dbo.uspQuestion7 @branch varchar(30), @author varchar(30)
as
	select BOOK.Title, BOOK_COPIES.No_Of_Copies
	from BOOK_COPIES
	inner join LIBRARY_BRANCH on BOOK_COPIES.BranchId = LIBRARY_BRANCH.BranchId
	inner join BOOK on BOOK_COPIES.BookId = BOOK.BookId
	inner join BOOK_AUTHORS on BOOK.BookId = BOOK_AUTHORS.BookId
	where LIBRARY_BRANCH.BranchName = @branch and BOOK_AUTHORS.AuthorName = @author
go

--exec dbo.uspQuestion7 @branch = 'Central', @author = 'Stephen King'