use db_baffaLibrary
go

create proc dbo.uspQuestion5
as
	select BranchName,count(*) from LIBRARY_BRANCH
	inner join BOOK_LOANS on LIBRARY_BRANCH.BranchId = BOOK_LOANS.BranchId
	group by BranchName

go

exec dbo.uspQuestion5