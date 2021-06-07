# simpleERP
Sebelum menggunakan aplikasi ini harap mengikuti intruksi dibawah ini :
1. Create database SQL dengan nama simpleERP
2. Create table dengan nama (poD, poH, tblCompanys, tblItems, tblUsers)
3. Jalankan script create table berikut


CREATE TABLE [dbo].[poD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[poId] [int] NOT NULL,
	[Itemno] [nvarchar](20) NULL,
	[price] [decimal](18, 0) NULL,
	[qty] [int] NULL,
	[tax] [decimal](18, 0) NULL,
	[disc] [decimal](18, 0) NULL,
	[total] [decimal](18, 0) NULL
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[poH](
	[poId] [int] IDENTITY(1,1) NOT NULL,
	[podate] [datetime] NULL,
	[companyId] [nchar](4) NULL,
	[note] [nvarchar](500) NULL,
	[totalTax] [decimal](18, 0) NULL,
	[totalDisc] [decimal](18, 0) NULL,
	[total] [decimal](18, 0) NULL,
 CONSTRAINT [PK_poH] PRIMARY KEY CLUSTERED 
(
	[poId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[tblCompanys](
	[companyId] [int] IDENTITY(1,1) NOT NULL,
	[companyName] [nvarchar](150) NOT NULL,
	[address] [nvarchar](150) NULL,
	[city] [nvarchar](100) NULL,
	[poscode] [nchar](5) NULL,
	[email] [nvarchar](100) NULL,
	[phone] [nvarchar](15) NULL,
 CONSTRAINT [PK_tblCompanys] PRIMARY KEY CLUSTERED 
(
	[companyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblItems](
	[itemno] [nvarchar](20) NOT NULL,
	[itemname] [nvarchar](100) NULL,
	[uom] [nvarchar](50) NULL,
	[minstock] [int] NULL,
 CONSTRAINT [PK_tblItems] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblItems] ADD  CONSTRAINT [DF_tblItems_minstock]  DEFAULT ((0)) FOR [minstock]
GO


CREATE TABLE [dbo].[tblUsers](
	[username] [nvarchar](20) NOT NULL,
	[password] [nvarchar](50) NULL,
	[fullname] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[phone] [nvarchar](15) NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

selamat mencoba
