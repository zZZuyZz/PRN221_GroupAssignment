CREATE DATABASE RealEstateManagement

USE RealEstateManagement

CREATE TABLE Roles (
    Id uniqueidentifier primary key,
	RoleName nvarchar(50)
);

CREATE TABLE Users (
    Id uniqueidentifier PRIMARY KEY,
    UserName nvarchar(50),
	Email nvarchar(50) ,
    Password nvarchar(255),
	Phone nvarchar(50),
    RoleId uniqueidentifier,
	isActive tinyint,
	create_at datetime,
    updated_at datetime,
	update_by datetime,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
CREATE TABLE Projects(
	Id uniqueidentifier PRIMARY KEY,
	InvestorId uniqueidentifier,
	ProjectStatus nvarchar(50),
	ProjectLocation nvarchar(50),
	ProjectGeoLocationUrl nvarchar(50),
	StartDate datetime,
	EndDate datetime,
	ProjectTitle nvarchar(255),
	ProjectContent nvarchar(255),
	create_at datetime,
	create_by datetime,
    updated_at datetime,
	update_by datetime
	FOREIGN KEY (InvestorId) REFERENCES Users(Id)
);
CREATE TABLE Products  (
    Id uniqueidentifier PRIMARY KEY,
    InvestorId uniqueidentifier,
	FinalCustomerId uniqueidentifier,
	ProjectId uniqueidentifier,
    Address nvarchar(255),
    Sescription TEXT,
    Price DECIMAL(15, 2),
    Status nvarchar(50),
    create_at datetime,
	create_by datetime,
    updated_at datetime,
	update_by datetime
    FOREIGN KEY (InvestorId) REFERENCES Users(Id),
	FOREIGN KEY (FinalCustomerId) REFERENCES Users(Id),
	FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
);

CREATE TABLE Bookings(
    Id uniqueidentifier PRIMARY KEY,
    RealEstateId uniqueidentifier,
    CustomerId uniqueidentifier,
    AgencyId uniqueidentifier,
    BookingDate datetime,
    Status nvarchar(50),
    create_at datetime,
	create_by datetime,
    updated_at datetime,
	update_by datetime
    FOREIGN KEY (RealEstateId) REFERENCES Products(Id),
    FOREIGN KEY (CustomerId) REFERENCES Users(Id),
    FOREIGN KEY (AgencyId) REFERENCES Users(Id)
);

CREATE TABLE Contracts (
    Id uniqueidentifier PRIMARY KEY,
    RealEstateId uniqueidentifier,
    CustomerId uniqueidentifier,
    AgencyId uniqueidentifier,
    DepositAmount DECIMAL(15, 2),
    ContractDate DATE,
    Status nvarchar(50),
    create_at datetime,
	create_by datetime,
    updated_at datetime,
	update_by datetime
    FOREIGN KEY (RealEstateId) REFERENCES Products(Id),
    FOREIGN KEY (CustomerId) REFERENCES Users(Id),
    FOREIGN KEY (AgencyId) REFERENCES Users(Id)
);

