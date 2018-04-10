use db_baffaLibrary
go

create proc dbo.uspQuestion4 @dueDate varchar(30)
as
	select BOOK.Title,BORROWER.Name,BORROWER.Address
	from BOOK_LOANS
	inner join BORROWER on BOOK_LOANS.CardNo = BORROWER.CardNo
	inner join BOOK on BOOK_LOANS.BookId = BOOK.BookId
	where BOOK_LOANS.DueDate = @dueDate
go

exec dbo.uspQuestion4 @dueDate = '2018-02-03'