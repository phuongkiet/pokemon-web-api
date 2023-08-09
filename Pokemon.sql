create database Pokemon
use Pokemon

create table Region
(
	Id int identity(1,1) primary key,
	Name nvarchar(MAX)
)

create table Owner
(
	Id int identity(1,1) primary key,
	Name nvarchar(MAX),
	Gym nvarchar(MAX),
	RegionId int foreign key references Region(Id)
)

create table Category
(
	Id int identity(1,1) primary key,
	Name nvarchar(MAX)
)

create table Pokemon
(
	Id int identity(1,1) primary key,
	Name nvarchar(MAX),
	BirthDate datetime,
	Sex nvarchar(MAX),
	IsShiny bit,
)

create table PokemonCategories
(
	PokemonId int,
	CategoryId int,
)

create table PokemonOwners
(
	PokemonId int,
	OwnerId int,
)

-- Insert sample data into Region table
INSERT INTO Region (Name)
VALUES ('Kanto'), ('Johto'), ('Hoenn');

-- Insert sample data into Owner table
INSERT INTO Owner (Name, Gym, RegionId)
VALUES ('Satoshi', 'Pallet Town Gym', 1),
       ('Kasumi', 'Hanada City Gym', 1),
       ('Takeshi', 'Nibi City Gym', 1);

-- Insert sample data into Category table
INSERT INTO Category (Name)
VALUES ('Honoo'), ('Mizu'), ('Kusa')

-- Insert sample data into Pokemon table
INSERT INTO Pokemon (Name, BirthDate, Sex, IsShiny)
VALUES ('Hitokage', '2000-05-15', 'Male', 0),
       ('Zenigame', '2001-08-23', 'Male', 0),
       ('Fushigidane', '2002-03-10', 'Female', 1);

-- Insert sample data into PokemonCategories table
INSERT INTO PokemonCategories (PokemonId, CategoryId)
VALUES (1, 1), (2, 2), (3, 3);

-- Insert sample data into PokemonOwners table
INSERT INTO PokemonOwners (PokemonId, OwnerId)
VALUES (1, 1), (2, 2), (3, 3);


