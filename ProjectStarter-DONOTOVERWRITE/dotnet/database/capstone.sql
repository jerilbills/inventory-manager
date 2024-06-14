USE master
GO

--drop database if it exists
IF DB_ID('inventory_manager') IS NOT NULL
BEGIN
	ALTER DATABASE inventory_manager SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE inventory_manager;
END

CREATE DATABASE inventory_manager
GO

USE inventory_manager
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id),
	CONSTRAINT UQ_username UNIQUE (username)
)

CREATE TABLE items (
	item_id int IDENTITY(1,1) NOT NULL,
	item_name varchar(80) NOT NULL,
	quantity int NOT NULL,
	CONSTRAINT PK_items PRIMARY KEY (item_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO items (item_name, quantity) VALUES ('Quest Q64 10''x10'' Slant Leg Canopy', 5);
INSERT INTO items (item_name, quantity) VALUES ('Solo Stove Bonfire 2.0 Color + Stand Bundle', 5);
INSERT INTO items (item_name, quantity) VALUES ('Blackstone 22" On The Go Griddle with Hood', 5);
INSERT INTO items (item_name, quantity) VALUES ('Quest Canyon 100 Kayak', 5);
INSERT INTO items (item_name, quantity) VALUES ('Walter Hagen Men''s Performance 11 Novelty Print Golf Polo', 5);

GO