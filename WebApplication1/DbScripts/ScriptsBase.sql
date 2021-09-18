create table users (
	Id int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255) NOT NULL,
    Email varchar(255),
    Phone varchar(255),
);
