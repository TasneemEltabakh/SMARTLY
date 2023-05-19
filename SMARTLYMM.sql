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

Alter table Bundle 
Add  img varchar not null

Alter table Bundle 
alter column  img varchar(200) not null


insert into Bundle values (1,20000,1,'Experience the power of smart lighting with our cutting-edge home automation system. Take control of your lighting at your fingertips with our intuitive mobile app. Effortlessly adjust brightness, set customized lighting scenes, and schedule lighting automation to suit your lifestyle. Enjoy the convenience of voice control integration with popular virtual assistants. Enhance your ambiance and energy efficiency while unlocking a new level of comfort and convenience. Transform your space with smart lighting technology that brings simplicity, style, and savings into every room Transform your home into a connected haven of personalized lighting and climate control. Elevate your living experience with our intermediate bundle, combining convenience, comfort, and energy efficiency in one seamless solution.','Basic','assets\img\basic_white_fiexedsize (1).jpg');


insert into Bundle values (2,40000,2,'Discover the ultimate smart home experience with our intermediate bundle that seamlessly controls both lighting and temperature. Enjoy complete command over your  ambiance and comfort through a single intuitive platform.','Intermediate','assets\img\intermidate_white_fixed (1).jpg')

insert into Bundle values (3,70000,3,'Experience the pinnacle of smart home innovation with our premium bundle, empowering you to effortlessly control every aspect of your entire home. Seamlessly integrate and manage lighting, temperature, security, entertainment, and more, all from a single, powerful platform. Unlock the true potential of your home with our premium smart home bundle. Experience unparalleled control, convenience, and luxury as you transform your living environment into a sophisticated and fully connected oasis.','Premium','assets\img\adavnced_white_fixed (1).jpg');



