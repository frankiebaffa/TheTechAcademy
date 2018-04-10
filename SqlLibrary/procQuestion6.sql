use db_baffaLibrary
go

create proc dbo.uspQuestion6
as
	select BORROWER.Name, BORROWER.Address, count(BOOK_LOANS.CardNo)
	from BORROWER
	inner join BOOK_LOANS on BORROWER.CardNo = BOOK_LOANS.CardNo
	group by BORROWER.Name, BORROWER.Address
	having count(BOOK_LOANS.CardNo) > 5
go

exec dbo.uspQuestion6