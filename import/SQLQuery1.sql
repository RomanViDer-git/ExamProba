/*create table [Role](
Id int identity primary key,
Role_Name nvarchar(100) not null
);

create table Users(
Id int identity primary key,
Role_id int references Role(Id),
[User_Name] nvarchar(500) not null,
[Login] nvarchar(500) not null,
[Password] nvarchar(500) not null
);

Create table Pu_Point(
Id int identity primary key,
[Address] nvarchar(500)not null
); 

create table StatusOrder(
Id int identity primary key,
[Status] nvarchar(100) not null,
);

create table [Order](
Id int identity primary key,
Article nvarchar(250) not null,
Order_Date date not null,
Adress_id int references Pu_Point(Id),
Status_id int references StatusOrder(Id)
);

create table Category(
Id int identity primary key,
Category_Name nvarchar(100) not null
);

create table Manufactures(
Id int identity primary key,
Manufacturer_Name nvarchar(250) not null
);

create table Suppliers(
Id int identity primary key,
Supplier_Name nvarchar(250),
);

Create table Products(
Id int identity primary key,
Product_Name nvarchar(200) not null,
Unit nvarchar(10) not null,
Price money not null,
Sopplier_id int references Suppliers(Id),
Manufacturer int references Manufactures(Id),
Category_id int references Category(Id),
Discount int not null,
Quantity int not null,
Discription nvarchar(500) not null,
Photo nvarchar(250) not null
);
 
 use Obuv_Prob

insert into [Role] values
('Администратор'), ('Менеджер'),('Авторизированный клиент')

insert into Manufactures values
('Kari'),('Marco Tozzi'),('Рос'),('Rieker'),('Alessio Nesca'),('CROSBY')

insert into Suppliers values
('Kari'),('Обувь для вас')

insert into StatusOrder values 
('Завершен'),('Новый')

insert into Category values 
('Женская обувь'),('Женская обувь')		  */
ALTER TABLE [Order]
ALTER COLUMN Article NVARCHAR(300) NOT NULL;