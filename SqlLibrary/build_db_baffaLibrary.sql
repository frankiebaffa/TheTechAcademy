/*=====================
	create database
=====================*/

create database db_baffaLibrary
go

use db_baffaLibrary;

/*==================
	create tables
==================*/

create table PUBLISHER (
	Name varchar(50) primary key not null,
		--fk_name BOOK.PublisherName
	Address varchar(50) not null,
	Phone varchar(20) not null
);

create table BOOK (
	BookId int primary key not null identity (1,1),
		--fk_BookIdCopies BOOK_COPIES.BookId
		--fk_BookIdLoans BOOK_LOANS.BookId
		--fk_BookIdAuthors BOOK_AUTHORS.BookId
	Title varchar(50) not null,
	PublisherName varchar(50) not null constraint fk_name foreign key references PUBLISHER(Name) on update cascade on delete cascade
);

create table BORROWER (
	CardNo int primary key not null identity(1000,1),
		--fk_CardNo BOOK_LOANS.CardNo
	Name varchar(50) not null,
	Address varchar(50) not null,
	Phone varchar(50) not null
);

create table BOOK_AUTHORS (
	BookId int not null constraint fk_BookIdAuthors foreign key references BOOK(BookId) on update cascade on delete cascade,
	AuthorName varchar(50) not null
);

create table LIBRARY_BRANCH (
	BranchId int not null primary key identity(1,1),
		--fk_BranchIdLoans BOOK_LOANS.BranchId
		--fk_BranchIdCopies BOOK_COPIES.BranchId
	BranchName varchar(50) not null,
	Address varchar(50) not null
);

create table BOOK_LOANS (
	BookId int not null constraint fk_BookIdLoans foreign key references BOOK(BookId) on update cascade on delete cascade,
	BranchId int not null constraint fk_BranchIdLoans foreign key references LIBRARY_BRANCH(BranchId) on update cascade on delete cascade,
	CardNo int not null constraint fk_CardNo foreign key references BORROWER(CardNo) on update cascade on delete cascade,
	DateOut date not null,
	DueDate date not null
);

create table BOOK_COPIES (
	BookId int not null constraint fk_BookIdCopies foreign key references BOOK(BookId) on update cascade on delete cascade,
	BranchId int not null constraint fk_BranchIdCopies foreign key references LIBRARY_BRANCH(BranchId) on update cascade on delete cascade,
	No_Of_Copies int,
);

/*====================
	insert data
====================*/

insert into LIBRARY_BRANCH
	(BranchName, Address)
	values
	('Sharpstown', '355 N 6th Ave'),
	('Central', '672 E 2 St'),
	('Downtown', '55 S 1 Ave'),
	('Uptown','250 N 28 Ave')
;

insert into PUBLISHER
	(Name, Address, Phone)
	values
	('W 26 St Press', '240 W 26 St', '270-668-8718'),
	('Macmillan', '76 N 12 Ave', '778-635-7712'),
	('Hachette', '23 Smith St', '555-127-6528'),
	('HarperCollins', '450 Canterbury Ave', '763-296-6310'),
	('Penguin Books','100 Penguin Pkwy','215-754-6397'),
	('Random House','56 Wager Rd','441-654-3219'),
	('Simon and Schuster','12 E Parker St','224-687-2394')
;

insert into BOOK
	(Title,PublisherName)
	values
	('The Lost Tribe','W 26 St Press'),
	('The Shining','Macmillan'),
	('Under the Dome','Simon and Schuster'),
	('Amnesia Moon','Penguin Books'),
	('Neuromancer','HarperCollins'),
	('The Peripheral','Random House'),
	('Superintelligence','Hachette'),
	('The Rise and Fall of the Third Reich','Macmillan'),
	('The Silmarillion','Penguin Books'),
	('The Hobbit','W 26 St Press'),
	('Astrophysics for People in a Hurry','Random House'),
	('The Great Gatsby','W 26 St Press'),
	('To Kill A Mockingbird','Hachette'),
	('Guns Germs and Steel','Simon and Schuster'),
	('The Sublime Object of Ideology','Penguin Books'),
	('The Marx Engels Reader','Macmillan'),
	('A Short History of Nearly Everything','Random House'),
	('How Not to Die','W 26 St Press'),
	('All American Murder','Simon and Schuster'),
	('Meditations','Random House')
;

insert into BOOK_AUTHORS
	(BookId,AuthorName)
	values
	(1,'Mark Lee'),
	(2,'Stephen King'),
	(3,'Stephen King'),
	(4,'Jonathan Lethem'),
	(5,'William Gibson'),
	(6,'William Gibson'),
	(7,'Nick Bostrom'),
	(8,'William Shirer'),
	(9,'JRR Tolkien'),
	(10,'JRR Tolkien'),
	(11,'Neil DeGrasse Tyson'),
	(12,'F Scott Fitzgerald'),
	(13,'Harper Lee'),
	(14,'Jared Diamond'),
	(15,'Slavoj Zizek'),
	(16,'Robert Tucker'),
	(17,'Bill Bryson'),
	(18,'Michael Greger'),
	(19,'James Patterson'),
	(20, 'Marcus Aurellius')
;

insert into BOOK_COPIES
	(BookId, BranchId, No_Of_Copies)
	values
	(1,1,3),
	(1,2,4),
	(1,3,2),
	(1,4,0),
	(2,1,3),
	(2,2,4),
	(2,3,4),
	(2,4,0),
	(3,1,3),
	(3,2,4),
	(3,3,0),
	(3,4,2),
	(4,1,0),
	(4,2,3),
	(4,3,0),
	(4,4,2),
	(5,1,4),
	(5,2,0),
	(5,3,2),
	(5,4,3),
	(6,1,4),
	(6,2,3),
	(6,3,4),
	(6,4,3),
	(7,1,2),
	(7,2,3),
	(7,3,2),
	(7,4,0),
	(8,1,0),
	(8,2,3),
	(8,3,2),
	(8,4,3),
	(9,1,2),
	(9,2,3),
	(9,3,4),
	(9,4,2),
	(10,1,2),
	(10,2,0),
	(10,3,3),
	(10,4,2),
	(11,1,2),
	(11,2,3),
	(11,3,4),
	(11,4,2),
	(12,1,3),
	(12,2,2),
	(12,3,0),
	(12,4,4),
	(13,1,2),
	(13,2,3),
	(13,3,2),
	(13,4,2),
	(14,1,3),
	(14,2,4),
	(14,3,2),
	(14,4,2),
	(15,1,3),
	(15,2,0),
	(15,3,3),
	(15,4,2),
	(16,1,2),
	(16,2,3),
	(16,3,4),
	(16,4,3),
	(17,1,2),
	(17,2,2),
	(17,3,3),
	(17,4,4),
	(18,1,0),
	(18,2,3),
	(18,3,4),
	(18,4,2),
	(19,1,3),
	(19,2,4),
	(19,3,3),
	(19,4,2),
	(20,1,3),
	(20,2,0),
	(20,3,4),
	(20,4,3)
;

insert into BORROWER
	(Name,Address,Phone)
	values
	('John Jonathan','45 W 8 St','232-985-6345'),
	('Jim Smith','85 N 2 Ave','546-987-2345'),
	('Hank Hill','235 E Center Ridge Rd','654-852-3674'),
	('Jane Doe','245 Valley Dr','235-858-3440'),
	('Ian Bavitz','523 Northwood Blvd','415-854-9652'),
	('Frankie Baffa','85 W 6 St','440-222-6666'),
	('Sam Fisher','150 Westwood Blvd','454-987-5236'),
	('Naudia Cruz','624 Lark Ave','216-445-9651'),
	('Angela Schuster','55 N 6 Ave','852-456-3288'),
	('Sami Sullivan','546 W 214 St','545-635-8342'),
	('Donna Oliver','5369 E 6 St','268-741-5684'),
	('Tom Jones','523 Madison Ave','523-096-4435')
;

insert into BOOK_LOANS
	(BookId,BranchId,CardNo,DateOut,DueDate)
	values
	(15,3,1005,'2018-01-18','2018-02-01'),
	(17,1,1001,'2018-01-18','2018-02-01'),
	(19,1,1002,'2018-01-18','2018-02-01'),
	(20,3,1007,'2018-01-18','2018-02-01'),
	(1,2,1006,'2018-01-19','2018-02-02'),
	(11,3,1005,'2018-01-19','2018-02-02'),
	(20,3,1008,'2018-01-19','2018-02-02'),
	(14,1,1010,'2018-01-20','2018-02-03'),
	(6,4,1002,'2018-01-20','2018-02-03'),
	(4,4,1004,'2018-01-20','2018-02-03'),
	(12,1,1005,'2018-01-20','2018-02-03'),
	(6,1,1002,'2018-01-21','2018-02-04'),
	(1,2,1010,'2018-01-21','2018-02-04'),
	(18,2,1011,'2018-01-22','2018-02-05'),
	(17,3,1003,'2018-01-22','2018-02-05'),
	(2,1,1005,'2018-01-22','2018-02-05'),
	(3,2,1009,'2018-01-23','2018-02-06'),
	(9,4,1008,'2018-01-23','2018-02-06'),
	(20,3,1004,'2018-01-23','2018-02-06'),
	(20,4,1002,'2018-01-23','2018-02-06'),
	(2,2,1008,'2018-01-23','2018-02-06'),
	(12,1,1005,'2018-01-23','2018-02-06'),
	(13,2,1005,'2018-01-24','2018-02-07'),
	(3,2,1003,'2018-01-24','2018-02-07'),
	(18,2,1009,'2018-01-25','2018-02-08'),
	(17,4,1010,'2018-01-25','2018-02-08'),
	(5,3,1006,'2018-01-26','2018-02-09'),
	(14,4,1009,'2018-01-26','2018-02-09'),
	(11,2,1011,'2018-01-26','2018-02-09'),
	(1,1,1003,'2018-01-26','2018-02-09'),
	(9,4,1004,'2018-01-26','2018-02-09'),
	(7,3,1002,'2018-01-26','2018-02-09'),
	(17,3,1006,'2018-01-27','2018-02-10'),
	(14,1,1003,'2018-01-28','2018-02-11'),
	(12,1,1005,'2018-01-28','2018-02-11'),
	(13,2,1006,'2018-01-28','2018-02-11'),
	(3,4,1007,'2018-01-29','2018-02-12'),
	(15,4,1005,'2018-01-30','2018-02-13'),
	(18,4,1010,'2018-01-30','2018-02-13'),
	(4,4,1003,'2018-01-30','2018-02-13'),
	(2,1,1011,'2018-01-30','2018-02-13'),
	(19,1,1006,'2018-01-30','2018-02-13'),
	(20,4,1011,'2018-01-31','2018-02-14'),
	(10,3,1009,'2018-01-31','2018-02-14'),
	(13,2,1002,'2018-01-31','2018-02-14'),
	(18,4,1006,'2018-02-01','2018-02-15'),
	(20,4,1010,'2018-02-01','2018-02-15'),
	(15,3,1008,'2018-02-01','2018-02-15'),
	(9,2,1002,'2018-02-01','2018-02-15'),
	(2,2,1009,'2018-02-01','2018-02-15')
;