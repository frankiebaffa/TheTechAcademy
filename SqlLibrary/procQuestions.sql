use [db_baffaLibrary]
go

--Question 1
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

--Question 2

create proc dbo.uspQuestion2 @book varchar(30)
as
	select BranchName,No_Of_Copies
	from LIBRARY_BRANCH
		inner join BOOK_COPIES on LIBRARY_BRANCH.BranchId = BOOK_COPIES.BranchId
		inner join BOOK on BOOK_COPIES.BookId = BOOK.BookId
	where
		BOOK.Title = @book
go

--Question 3
create proc dbo.uspQuestion3
as
	select Name from BORROWER
		left join BOOK_LOANS on BORROWER.CardNo = BOOK_LOANS.CardNo
		where BOOK_LOANS.BookId is null
go

--Question 4
create proc dbo.uspQuestion4 @dueDate varchar(30)
as
	select BOOK.Title,BORROWER.Name,BORROWER.Address
	from BOOK_LOANS
	inner join BORROWER on BOOK_LOANS.CardNo = BORROWER.CardNo
	inner join BOOK on BOOK_LOANS.BookId = BOOK.BookId
	where BOOK_LOANS.DueDate = @dueDate
go

--Question 5
create proc dbo.uspQuestion5
as
	select BranchName,count(*) from LIBRARY_BRANCH
	inner join BOOK_LOANS on LIBRARY_BRANCH.BranchId = BOOK_LOANS.BranchId
	group by BranchName

go

--Question 6
create proc dbo.uspQuestion6
as
	select BORROWER.Name, BORROWER.Address, count(BOOK_LOANS.CardNo)
	from BORROWER
	inner join BOOK_LOANS on BORROWER.CardNo = BOOK_LOANS.CardNo
	group by BORROWER.Name, BORROWER.Address
	having count(BOOK_LOANS.CardNo) > 5
go

--Question 7
create proc dbo.uspQuestion7 @branch varchar(30), @author varchar(30)
as
	select BOOK.Title, BOOK_COPIES.No_Of_Copies
	from BOOK_COPIES
	inner join LIBRARY_BRANCH on BOOK_COPIES.BranchId = LIBRARY_BRANCH.BranchId
	inner join BOOK on BOOK_COPIES.BookId = BOOK.BookId
	inner join BOOK_AUTHORS on BOOK.BookId = BOOK_AUTHORS.BookId
	where LIBRARY_BRANCH.BranchName = @branch and BOOK_AUTHORS.AuthorName = @author
go

--Execute
exec dbo.uspQuestion1 @branch = 'Sharpstown', @book = 'The Lost Tribe';
exec dbo.uspQuestion2 @book = 'The Lost Tribe';
exec dbo.uspQuestion3;
exec dbo.uspQuestion4 @dueDate = '2018-02-03';
exec dbo.uspQuestion5;
exec dbo.uspQuestion6;
exec dbo.uspQuestion7 @branch = 'Central', @author = 'Stephen King';