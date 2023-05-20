USE [SMARTLY]
GO
/****** Object:  Table [dbo].[_User]    Script Date: 17/05/2023 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[_User](
	[username] [varchar](10) NOT NULL,
	[userPassword] [varchar](15) NOT NULL,
	[UserType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Adress]    Script Date: 17/05/2023 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adress](
	[username] [varchar](10) NOT NULL,
	[zipcode] [varchar](5) NOT NULL,
	[governorate] [varchar](20) NOT NULL,
	[city] [varchar](20) NOT NULL,
	[street] [varchar](20) NOT NULL,
	[BuildigNum] [int] NOT NULL,
	[Floornum] [int] NOT NULL,
	[FlatNum] [int] NOT NULL,
	[AdditionalNotes] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC,
	[street] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agency]    Script Date: 17/05/2023 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agency](
	[username] [varchar](10) NULL,
	[email] [varchar](30) NOT NULL,
	[Agencyname] [varchar](20) NOT NULL,
	[Location] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnOrder]    Script Date: 17/05/2023 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnOrder](
	[Username] [varchar](10) NULL,
	[OrderCode] [int] NOT NULL,
	[AmountToPay] [float] NOT NULL,
	[OrderDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bundle]    Script Date: 17/05/2023 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bundle](
	[BundleId] [varchar](15) NOT NULL,
	[price] [float] NOT NULL,
	[level] [int] NULL,
	[BundleDescription] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[BundleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 17/05/2023 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[username] [varchar](10) NULL,
	[email] [varchar](30) NOT NULL,
	[phonenumber] [char](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contain]    Script Date: 17/05/2023 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contain](
	[BundleId] [int] NOT NULL,
	[PId] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BundleId] ASC,
	[PId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedBack]    Script Date: 17/05/2023 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedBack](
	[Username] [varchar](10) NOT NULL,
	[PId] [varchar](15) NOT NULL,
	[Rate] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Username] ASC,
	[PId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderFor]    Script Date: 17/05/2023 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderFor](
	[OrderCode] [int] NOT NULL,
	[PId] [varchar](15) NOT NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderCode] ASC,
	[PId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 17/05/2023 13:22:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[PId] [varchar](15) NOT NULL,
	[PName] [varchar](25) NOT NULL,
	[price] [float] NOT NULL,
	[Quantity] [int] NULL,
	[color] [varchar](20) NULL,
	[salePercentage] [float] NULL,
	[category] [varchar](50) NULL,
	[AdditionalNotes] [text] NULL,
	[Pimage] [image] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'cc', N'fefer', 2)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'Futho', N'admin555', 2)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'hh', N'ss', 3)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'hhhshss', N'hh', 3)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'Nada', N'dd', 3)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'rghda', N'hh', 3)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'ryate', N'ewd', 2)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'smartly', N'admin555', 1)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'sphome', N'admin555', 2)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'ss', N'fefer', 2)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'Tasneem', N'tasneem', 3)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'techsm', N'admin555', 2)
INSERT [dbo].[_User] ([username], [userPassword], [UserType]) VALUES (N'tt', N'fefer', 2)
GO
INSERT [dbo].[Agency] ([username], [email], [Agencyname], [Location]) VALUES (N'Futho', N'kkkk@hotmail.com', N'Future Home', N'66-Wafaa st')
INSERT [dbo].[Agency] ([username], [email], [Agencyname], [Location]) VALUES (N'techsm', N'kooob55$$', N'Tech Smart', N'22-Ali RUHAYEM st')
INSERT [dbo].[Agency] ([username], [email], [Agencyname], [Location]) VALUES (N'sphome', N'lllll@hotmail.com', N'Super Home', N'31- westst')
INSERT [dbo].[Agency] ([username], [email], [Agencyname], [Location]) VALUES (N'cc', N'njb@xx', N'dd', N'dd')
INSERT [dbo].[Agency] ([username], [email], [Agencyname], [Location]) VALUES (N'ryate', N'twefwef@zewail', N'taru', N'ghwd')
INSERT [dbo].[Agency] ([username], [email], [Agencyname], [Location]) VALUES (N'ss', N'ww@ff', N'dd', N'dd')
INSERT [dbo].[Agency] ([username], [email], [Agencyname], [Location]) VALUES (N'tt', N'ww@xx', N'dd', N'dd')
GO
INSERT [dbo].[Client] ([username], [email], [phonenumber]) VALUES (N'hhhshss', N'gg@zewail', N'04540231583')
INSERT [dbo].[Client] ([username], [email], [phonenumber]) VALUES (N'hh', N'Zyad@attia', N'01158060254')
GO
ALTER TABLE [dbo].[Adress] ADD  DEFAULT ('none') FOR [AdditionalNotes]
GO
ALTER TABLE [dbo].[Agency] ADD  DEFAULT ('not Specified') FOR [Location]
GO
ALTER TABLE [dbo].[Bundle] ADD  DEFAULT ('no Description Found') FOR [BundleDescription]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ('Unknown') FOR [color]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [salePercentage]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ('Others') FOR [category]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ('no Description Found') FOR [AdditionalNotes]
GO
ALTER TABLE [dbo].[Adress]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[_User] ([username])
GO
ALTER TABLE [dbo].[Agency]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[_User] ([username])
GO
ALTER TABLE [dbo].[AnOrder]  WITH CHECK ADD FOREIGN KEY([Username])
REFERENCES [dbo].[_User] ([username])
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[_User] ([username])
GO
ALTER TABLE [dbo].[Contain]  WITH CHECK ADD FOREIGN KEY([PId])
REFERENCES [dbo].[Product] ([PId])
GO
ALTER TABLE [dbo].[FeedBack]  WITH CHECK ADD FOREIGN KEY([PId])
REFERENCES [dbo].[Product] ([PId])
GO
ALTER TABLE [dbo].[FeedBack]  WITH CHECK ADD FOREIGN KEY([Username])
REFERENCES [dbo].[_User] ([username])
GO
ALTER TABLE [dbo].[OrderFor]  WITH CHECK ADD FOREIGN KEY([OrderCode])
REFERENCES [dbo].[AnOrder] ([OrderCode])
GO
ALTER TABLE [dbo].[OrderFor]  WITH CHECK ADD FOREIGN KEY([PId])
REFERENCES [dbo].[Product] ([PId])
GO


Create Table Categories
(
id int primary key,
title varchar not null,
);



ALTER TABLE Product
DROP CONSTRAINT DF__Product__categor__45F365D3;

Alter table Product
alter column category int 

Alter table Product
add constraint fk
foreign key (category)
references  Categories

Alter table Bundle 
Add  _Name varchar(50) not null



insert into Bundle values (1,20000,1,'Experience the power of smart lighting with our cutting-edge home automation system. Take control of your lighting at your fingertips with our intuitive mobile app. Effortlessly adjust brightness, set customized lighting scenes, and schedule lighting automation to suit your lifestyle. Enjoy the convenience of voice control integration with popular virtual assistants. Enhance your ambiance and energy efficiency while unlocking a new level of comfort and convenience. Transform your space with smart lighting technology that brings simplicity, style, and savings into every room Transform your home into a connected haven of personalized lighting and climate control. Elevate your living experience with our intermediate bundle, combining convenience, comfort, and energy efficiency in one seamless solution.','Basic','assets\img\basic_white_fiexedsize (1).jpg');

insert into Bundle values (2,40000,2,'Discover the ultimate smart home experience with our intermediate bundle that seamlessly controls both lighting and temperature. Enjoy complete command over your  ambiance and comfort through a single intuitive platform.','Intermediate','assets\img\intermidate_white_fixed (1).jpg')

insert into Bundle values (3,70000,3,'Experience the pinnacle of smart home innovation with our premium bundle, empowering you to effortlessly control every aspect of your entire home. Seamlessly integrate and manage lighting, temperature, security, entertainment, and more, all from a single, powerful platform. Unlock the true potential of your home with our premium smart home bundle. Experience unparalleled control, convenience, and luxury as you transform your living environment into a sophisticated and fully connected oasis.','Premium','assets\img\adavnced_white_fixed (1).jpg');
 
Create table Bundle_Product
(
product_id varchar (15) not null,
Bundle_ID Varchar(15) not null,
primary key (Product_id, Bundle_Id),
foreign key (product_id ) references Product,
foreign key (Bundle_id ) references Bundle

);


Create Table Guest 
(
  id int primary key,
);

alter table Categories
alter column title varchar(20) not null

insert into Categories
values(1,'Alexa Hub');
insert into Categories
values(2,'Switches');
insert into Categories
values(3,'Lighting');
---->
--->
ALTER TABLE Product
DROP COLUMN Pimage; 

Alter table product 
add Pimage varchar(200) ;

ALTER TABLE Product
DROP COLUMN Pimage; 

Alter table product 
add Pimage varchar(200) ;


alter table Product
alter column PName varchar(150) not null

insert into Product
values(1,'Echo Dot 5th Gen',28000,260,'Deep Sea Blue',0,1,'Its for Alexa','assets\img\product1.jpeg');
insert into Product
values(2,'WiFi Mini DIY Smart Switch',15000,50,'Black',0,2,'Its for Switch','assets\img\product2.jpeg');
insert into Product
values(3,'Wifi Smart Door Lock Indoor',30000,100,'silver',0,2,'Its for Switches','assets\img\product3.jpeg');

insert into  Bundle_Product
values(1,1);
insert into  Bundle_Product
values(2,2);
insert into  Bundle_Product
values(3,3);
insert into  Bundle_Product
values(1,3);


insert into Product
values(4,'Wifi Smart Door Lock outdoor',30000,10,'Black',30,2,'Its for Door','assets\img\TTLock.jpg_Q90.jpg_.webp');

Create table Cart (
username varchar(10) foreign key references _user,
productid varchar(15) foreign key references product,
primary key (username,productid)
)

ALTER TABLE product
ADD price_aftersale AS (price - (SalePercentage / 100 * price)) PERSISTED;


ALTER TABLE Cart
ADD Quantity int default 1

update cart set Quantity =1





alter table Product
alter column PName varchar(150) not null


insert into Product
values(1,'Echo Dot 5th Gen',28000,260,'Deep Sea Blue',0,1,'Its for Alexa','assets\img\product1.jpg');
insert into Product
values(2,'WiFi Mini DIY Smart Switch',15000,50,'Black',0,2,'Its for Switch','assets\img\product2.jpg');
insert into Product
values(3,'Wifi Smart Door Lock Indoor',30000,100,'silver',0,2,'Its for Switches','assets\img\product3.jpg');

insert into  Bundle_Product
values(1,1);
insert into  Bundle_Product
values(2,2);
insert into  Bundle_Product
values(3,3);
insert into  Bundle_Product
values(1,3);
--->
insert into Product
values(4,'Wifi Smart Door Lock outdoor',30000,10,'Black',30,2,'Its for Door','assets\img\TTLock.jpg_Q90.jpg_.webp');

Create table Cart (
username varchar(10) foreign key references _user,
productid varchar(15) foreign key references product,
primary key (username,productid)
)

ALTER TABLE product
ADD price_aftersale AS (price - (SalePercentage / 100 * price)) PERSISTED;

--->Next Day
insert into FeedBack
values('cc',1,4);
insert into FeedBack
values('Nada',1,3);
insert into FeedBack
values('rghda',2,5);
insert into FeedBack
values('ss',1,1);
