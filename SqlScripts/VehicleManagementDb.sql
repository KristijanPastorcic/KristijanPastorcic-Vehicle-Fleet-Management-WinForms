USE master
go

declare @dbname nvarchar(128)
set @dbname = N'VehicleFleetManagement'
if(exists(select name from sys.databases where name = @dbname))
	begin
	PRINT 'db exists, deleting ...'
	drop database VehicleFleetManagement
end
go

create database VehicleFleetManagement
print 'db VehicleFleetManagement created'
go


use VehicleFleetManagement
go

create table Drivers(
	IDDriver int primary key identity(1,1),
	"Name" nvarchar(50) not null,
	Surname nvarchar(50) not null,
	PhoneNumber nvarchar(50) not null,
	DriversLicenseNumber nvarchar(50) unique not null,
	Deleted bit default(0)
)
go

create table Vehicles(
	IDVehicle int primary key identity(1,1),
	"Type" nvarchar(50) not null,
	Manufacturer nvarchar(50) not null,
	"Year" int not null,
	Kilometers int not null
)
go

create table TravelWarrantStates(
	IDTravelWarrantState tinyint primary key identity(1,1),
	"State" nvarchar(50) not null
)
go

insert into TravelWarrantStates(State) values ('Open'), ('Closed'), ('Future')
go





create table VehicleServices(
	IDVehicleService int primary key identity(1, 1),
	"Description" nvarchar(250) not null,
	"Date" datetime not null,
	Price  money not null,
	FK_Vehicles int foreign key references Vehicles(IDVehicle) not null
)
go

create table TravelWarrents(
	IDTravelWarrent int primary key identity(1, 1),
	RouteDescription nvarchar(50),
	DateCreated datetime not null,
	FK_Drivers int foreign key references Drivers(IDDriver) not null,
	FK_Vehicles int foreign key references Vehicles(IDVehicle) not null,
	FK_TravelWarrantStates tinyint foreign key references TravelWarrantStates(IDTravelWarrantState) not null,
)
go

create table "Routes"(
	IDRoute int primary key identity(1, 1),
	StartDate datetime,
	EndDate datetime,
	StartLocation nvarchar(100),
	EndLocation nvarchar(100),
	Distance int,
	FuelSpent float,
	FK_TravelWarrents int foreign key references TravelWarrents(IDTravelWarrent) not null
)
go

create table Items(
	IDItem int primary key identity(1, 1),
	ProductName nvarchar(50) not null,
	Amont int not null,
	ItemPrice money not null
)
go

create table TravelExpences(
	IDTravelExpence int primary key identity(1, 1),
	PurchaseDate datetime not null,
	FK_TravelWarrents int foreign key references TravelWarrents(IDTravelWarrent) not null,
	FK_Items int foreign key references Items(IDItem) not null
)
go

