use db_baffaLibrary
go

create proc dbo.uspQuestion3
as
	select Name from BORROWER
		left join BOOK_LOANS on BORROWER.CardNo = BOOK_LOANS.CardNo
		where BOOK_LOANS.BookId is null
go

--exec dbo.uspQuestion3