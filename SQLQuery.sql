USE MotorServiceDB;

CREATE TABLE UserLogin(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FristName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	email nvarchar(50) NOT NULL UNIQUE,
	PhoneNumber varchar NOT NULL UNIQUE,
	city varchar NOT NULL,
	homeTown varchar NOT NULL,
	salt nvarchar(200),
	password nvarchar(200),
	registerDate Date DEFAULT GETDATE()
);