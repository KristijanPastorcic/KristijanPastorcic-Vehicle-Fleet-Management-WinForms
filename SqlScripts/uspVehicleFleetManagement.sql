use master
go

use VehicleFleetManagement
go

create or alter proc uspFillDb
as
	insert into Drivers(Name, Surname, PhoneNumber, DriversLicenseNumber) values ('Marko', 'Markic', '+385982828754', 123456789)	 
	insert into Drivers(Name, Surname, PhoneNumber, DriversLicenseNumber) values ('Toni', 'Tomic', '+38591234560632', 098876655)	 
	insert into Drivers(Name, Surname, PhoneNumber, DriversLicenseNumber) values ('Marko', 'Markic', '+321321343523', 2348235683)	
	
	Insert into Vehicles(Type, Manufacturer, Year, Kilometers) values('Car', 'Opel', 2001, 142111)
	Insert into Vehicles(Type, Manufacturer, Year, Kilometers) values('Truck', 'Volvo', 2011, 91111)
	Insert into Vehicles(Type, Manufacturer, Year, Kilometers) values('Space ship', 'SpaceX', 2021, 0)

	Insert into Vehicles(Type, Manufacturer, Year, Kilometers) values('Car', 'Škoda', 2101, 1244)
	Insert into Vehicles(Type, Manufacturer, Year, Kilometers) values('Truck', 'Man', 123123, 13123441)
	Insert into Vehicles(Type, Manufacturer, Year, Kilometers) values('jef', 'Blue origin', 2021, 10)

	Insert into TravelWarrents(DateCreated, RouteDescription, FK_Drivers, FK_Vehicles, FK_TravelWarrantStates) values(GETDATE(),'idem do njemacke po pivo 4 dana 0o', 1,1,1)
	Insert into TravelWarrents(DateCreated, RouteDescription, FK_Drivers, FK_Vehicles, FK_TravelWarrantStates) values(GETDATE(), 'prevesti neke vrece za južu  kumarevo', 2,2,2)
	Insert into TravelWarrents(DateCreated, RouteDescription, FK_Drivers, FK_Vehicles, FK_TravelWarrantStates) values(GETDATE(), 'do marsa po kamenja na pluto i mjesec', 3,3,3)

	Insert into Routes(StartDate, EndDate, StartLocation, EndLocation, Distance, FuelSpent, FK_TravelWarrents) 
	values(GETDATE(), GETDATE(), 'ZZageb', 'Berlin', 0, 0.0, 1)
	Insert into Routes(StartDate, EndDate, StartLocation, EndLocation, Distance, FuelSpent, FK_TravelWarrents) 
	values(GETDATE(), GETDATE(), 'Berlin', 'Zagreb', 0, 0.0, 2)
	Insert into Routes(StartDate, EndDate, StartLocation, EndLocation, Distance, FuelSpent, FK_TravelWarrents) 
	values(GETDATE(), GETDATE(), 'Rijeka', 'Dubrovnik', 0, 0.0, 3)

		Insert into Routes(StartDate, EndDate, StartLocation, EndLocation, Distance, FuelSpent, FK_TravelWarrents) 
	values(GETDATE(), GETDATE(), 'Lhubljana', 'Marof', 0, 0.0, 1)

			Insert into Routes(StartDate, EndDate, StartLocation, EndLocation, Distance, FuelSpent, FK_TravelWarrents) 
	values(GETDATE(), GETDATE(), 'zagreb', 'Karlovac', 0, 0.0, 1)
go



create type VehicleModel as table(
	IDVehicle int,
	"Type" nvarchar(50) not null,
	Manufacturer nvarchar(50) not null,
	"Year" int not null,
	Kilometers int not null
)
go


create proc uspCreateVehicle
	@vehicle as VehicleModel readonly
as
	insert into Vehicles(Type, Manufacturer, Year, Kilometers)
	select Type, Manufacturer, Year, Kilometers from @vehicle
go

create proc uspUpdateVehicle
	@vehicle as VehicleModel readonly
as
	update Vehicles
	set 
		Type = (select Type from @vehicle),
		Manufacturer = (select Manufacturer from @vehicle),
		Year = (select Year from @vehicle),
		Kilometers = (select Kilometers from @vehicle)
	where IDVehicle = (select IDVehicle from @vehicle)
go

create proc uspDeleteVehicle
	@id int 
as
	delete from Vehicles
	where IDVehicle = @id
go

create proc uspGetVehicles
as
	select * from Vehicles
go


create proc uspGetTravelWarrents
as
	select * from TravelWarrents
go

create type TravelWarrentModel as table(
	IDTravelWarrent int,
	RouteDescription nvarchar(50),
	DateCreated datetime not null,
	FK_Drivers int not null,
	FK_Vehicles int not null,
	FK_TravelWarrantStates int not null
)
go


create or alter proc uspUpdateTravelWarrent
	@travelWarrent as TravelWarrentModel readonly
as
	update TravelWarrents
	set
	RouteDescription = (select RouteDescription from @travelWarrent),
	DateCreated = (select DateCreated from @travelWarrent),
	FK_Drivers = (select FK_Drivers from @travelWarrent),
	FK_Vehicles = (select FK_Vehicles from @travelWarrent),
	FK_TravelWarrantStates = (select FK_TravelWarrantStates from @travelWarrent)
	where IDTravelWarrent = (select IDTravelWarrent from @travelWarrent)
go

create or alter proc uspCreateTravelWarrent
	@travelWarrent as TravelWarrentModel readonly
as
	insert into TravelWarrents(RouteDescription, DateCreated, FK_Drivers, FK_Vehicles, FK_TravelWarrantStates)
	select RouteDescription, DateCreated, FK_Drivers, FK_Vehicles, FK_TravelWarrantStates from @travelWarrent
go

create or alter proc uspDeleteTravelWarrent
	@id int
as
	delete from TravelExpences
	where FK_TravelWarrents = @id

		delete from Routes
	where FK_TravelWarrents = @id

	delete from TravelWarrents
	where IDTravelWarrent = @id
go

create or alter proc uspGetRoutes
	@id int
as
select 
	IDRoute, StartDate, EndDate, StartLocation, EndLocation, Distance, FuelSpent, FK_TravelWarrents
from Routes
	where FK_TravelWarrents = @id
go

create or alter proc uspDeleteRoute
	@id int
as
	delete from Routes
	where IDRoute = @id
go

create type RoutesModel as table(
	IDRoute int,
	StartDate datetime,
	EndDate datetime,
	StartLocation nvarchar(100),
	EndLocation nvarchar(100),
	Distance int,
	FuelSpent float,
	FK_TravelWarrents int not null
)
go

create proc uspUpdateRoute
	@route RoutesModel readonly
as
	update Routes
	set
	StartDate = (select StartDate from @route),
	EndDate = (select EndDate from @route),
	StartLocation = (select StartLocation from @route),
	EndLocation = (select EndLocation from @route),
	Distance = (select Distance from @route),
	FuelSpent = (select FuelSpent from @route),
	FK_TravelWarrents = (select FK_TravelWarrents from @route)
	where IDRoute = (select IDRoute from @route) 
go

create proc uspCreateRoutes
	@route RoutesModel readonly
as
insert into Routes(StartDate, EndDate, StartLocation, EndLocation, Distance, FuelSpent, FK_TravelWarrents)
select StartDate, EndDate, StartLocation, EndLocation, Distance, FuelSpent, FK_TravelWarrents from @route
go

create proc GetDataBase
as
select * from Drivers
select * from Vehicles
select * from Routes
select * from TravelWarrents
select * from TravelWarrantStates
select * from Items
select * from TravelExpences
select * from VehicleServices
go

create proc uspCleanDb
as
	delete VehicleServices
	delete Routes
	delete TravelExpences
	delete Items
	delete TravelWarrents
	delete TravelWarrantStates
	delete Drivers
	delete Vehicles
go


create   proc [dbo].[uspImportRoutes]
	@route RoutesModel readonly
as

set identity_insert Routes on;
insert into Routes(IDRoute ,StartDate, EndDate, StartLocation, EndLocation, Distance, FuelSpent, FK_TravelWarrents)
select IDRoute ,StartDate, EndDate, StartLocation, EndLocation, Distance, FuelSpent, FK_TravelWarrents from @route

set identity_insert Routes off;
go



create proc [dbo].[uspImportVehicles]
	@vehicle as VehicleModel readonly
as
	insert into Vehicles(IDVehicle ,Type, Manufacturer, Year, Kilometers)
	select IDVehicle ,Type, Manufacturer, Year, Kilometers from @vehicle
go

create   proc [dbo].[uspImportWarrents]
	@travelWarrent as TravelWarrentModel readonly
as
set identity_insert TravelWarrents on;

	insert into TravelWarrents(IDTravelWarrent ,RouteDescription, DateCreated, FK_Drivers, FK_Vehicles, FK_TravelWarrantStates)
	select IDTravelWarrent ,RouteDescription, DateCreated, FK_Drivers, FK_Vehicles, FK_TravelWarrantStates from @travelWarrent

	set identity_insert TravelWarrents off;
go



exec uspFillDb



