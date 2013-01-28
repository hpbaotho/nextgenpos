USE [nextgenPOS]
GO
/****** Object:  Table [dbo].[zipcode_city]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zipcode_city](
	[zipcode] [nvarchar](15) NOT NULL,
	[city] [nvarchar](150) NULL,
	[zipcode_city_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[zipcode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cashier]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cashier](
	[cashier_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[salery] [numeric](18, 0) NULL,
	[telephone] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[cashier_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cash_payment]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cash_payment](
	[cashPaymentID] [int] IDENTITY(1,1) NOT NULL,
	[amountTendered] [money] NOT NULL,
	[cashBack] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cashPaymentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[efternavne]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[efternavne](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[navn] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[drengenavne]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[drengenavne](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[navn] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pigenavne]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pigenavne](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[navn] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Description]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Description](
	[Product_Description_Id] [int] IDENTITY(1,1) NOT NULL,
	[Product_Description_Name] [nvarchar](255) NOT NULL,
	[Product_Description_Text] [text] NOT NULL,
	[Product_Description_Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [pk_Product_Description_Id] PRIMARY KEY CLUSTERED 
(
	[Product_Description_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Catalog]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Catalog](
	[Product_Catalog_Id] [int] NOT NULL,
	[Product_Catalog_Name] [nvarchar](100) NOT NULL,
	[fk_Product_Descrition_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Product_Catalog_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[random_drengenavn]    Script Date: 01/28/2013 11:45:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[random_drengenavn]() 
returns nvarchar(500)
as
begin
 declare @ifornavn int;
 declare @imellemnavn int;
 declare @iefternavn int;
 declare @name nvarchar(500);
 set @ifornavn    = 1 + cast((select randnumber from wrappedrandom) * (select count(*)-1 from drengenavne) as int);
 set @imellemnavn = 1 + cast((select randnumber from wrappedrandom) * (select count(*)-1 from drengenavne) as int);
 set @iefternavn  = 1 + cast((select randnumber from wrappedrandom) * (select count(*)-1 from efternavne)  as int);
 
 set @name =
  (select n1.navn + ' ' + n2.navn + ' ' + e.navn 
   from drengenavne n1,
        drengenavne n2,
        efternavne  e
  where n1.id = @ifornavn
    and n2.id = @imellemnavn
    and e.id  = @iefternavn);
  return @name;  
end;
GO
/****** Object:  Table [dbo].[customer]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[customerID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[addressLine] [nvarchar](60) NOT NULL,
	[fk_zipCode] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[get_random_zip_code]    Script Date: 01/28/2013 11:45:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[get_random_zip_code]()
returns int
as 
begin
 declare @zip_code int;
 set @zip_code = 5240;
  select @zip_code = zipcode 
 from zipcode_city zc 
 where zc.zipcode_city_id = (select cast(
                              (select COUNT(*) 
                               from zipcode_city) * 
								randnumber as int) 
                               from wrappedrandom); 
 return   @zip_code;                            
end;
GO
/****** Object:  UserDefinedFunction [dbo].[random_pigenavn]    Script Date: 01/28/2013 11:45:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[random_pigenavn]() 
returns nvarchar(500)
as
begin
 declare @ifornavn int;
 declare @imellemnavn int;
 declare @iefternavn int;
 declare @name nvarchar(500);
 set @ifornavn    = 1 + cast((select randnumber from wrappedrandom) * (select count(*)-1 from pigenavne) as int);
 set @imellemnavn = 1 + cast((select randnumber from wrappedrandom) * (select count(*)-1 from pigenavne) as int);
 set @iefternavn  = 1 + cast((select randnumber from wrappedrandom) * (select count(*)-1 from efternavne)  as int);
 
 set @name =
  (select n1.navn + ' ' + n2.navn + ' ' + e.navn 
   from pigenavne n1,
        pigenavne n2,
        efternavne  e
  where n1.id = @ifornavn
    and n2.id = @imellemnavn
    and e.id  = @iefternavn);
  return @name;  
end;
GO
/****** Object:  Table [dbo].[Store]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Store_Id] [int] IDENTITY(1,1) NOT NULL,
	[Store_Name] [nvarchar](80) NOT NULL,
	[Store_Address] [nvarchar](200) NOT NULL,
	[fk_Product_Catalog_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Store_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[random_navn]    Script Date: 01/28/2013 11:45:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[random_navn]() 
returns nvarchar(500)
as
begin
 declare @thename nvarchar(500);
 if (select randnumber from wrappedrandom) > 0.5 
   begin
     set @thename = dbo.random_drengenavn();
   end;
 else
   begin
    set @thename = dbo.random_pigenavn();
   end;
 return @thename;  
end;
GO
/****** Object:  Table [dbo].[Item]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemStoreQuantity] [int] NOT NULL,
	[fk_Product_Description_Id] [int] NULL,
	[fk_Store_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[register]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[register](
	[register_id] [int] IDENTITY(1,1) NOT NULL,
	[cashier_id] [int] NULL,
	[register_type] [varchar](200) NOT NULL,
	[fk_Store_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[register_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sale]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sale](
	[sale_id] [int] IDENTITY(1,1) NOT NULL,
	[sale_date] [datetime] NOT NULL,
	[total] [money] NOT NULL,
	[customer_id] [int] NOT NULL,
	[register_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sale_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sales_lineitem]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sales_lineitem](
	[sale_lineitem_id] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [int] NULL,
	[sale_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sale_lineitem_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ledger]    Script Date: 01/28/2013 11:44:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ledger](
	[LedgerId] [int] IDENTITY(1,1) NOT NULL,
	[fk_Sale_id] [int] NULL,
	[fk_Store_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LedgerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [zipCode_fk]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[customer]  WITH CHECK ADD  CONSTRAINT [zipCode_fk] FOREIGN KEY([fk_zipCode])
REFERENCES [dbo].[zipcode_city] ([zipcode])
GO
ALTER TABLE [dbo].[customer] CHECK CONSTRAINT [zipCode_fk]
GO
/****** Object:  ForeignKey [FK__Item__fk_Product__2A164134]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD FOREIGN KEY([fk_Product_Description_Id])
REFERENCES [dbo].[Product_Description] ([Product_Description_Id])
GO
/****** Object:  ForeignKey [FK__Item__fk_Store_I__2B0A656D]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD FOREIGN KEY([fk_Store_Id])
REFERENCES [dbo].[Store] ([Store_Id])
GO
/****** Object:  ForeignKey [FK__Ledger__fk_SaleI__25518C17]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[Ledger]  WITH CHECK ADD FOREIGN KEY([fk_Sale_id])
REFERENCES [dbo].[sale] ([sale_id])
GO
/****** Object:  ForeignKey [FK__Ledger__fk_Store__282DF8C2]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[Ledger]  WITH CHECK ADD FOREIGN KEY([fk_Store_Id])
REFERENCES [dbo].[Store] ([Store_Id])
GO
/****** Object:  ForeignKey [fk_Product_Description_Id]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[Product_Catalog]  WITH CHECK ADD  CONSTRAINT [fk_Product_Description_Id] FOREIGN KEY([fk_Product_Descrition_Id])
REFERENCES [dbo].[Product_Description] ([Product_Description_Id])
GO
ALTER TABLE [dbo].[Product_Catalog] CHECK CONSTRAINT [fk_Product_Description_Id]
GO
/****** Object:  ForeignKey [FK__Register__cashie__20C1E124]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[register]  WITH CHECK ADD FOREIGN KEY([cashier_id])
REFERENCES [dbo].[cashier] ([cashier_id])
GO
/****** Object:  ForeignKey [fk_Store_Id]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[register]  WITH CHECK ADD  CONSTRAINT [fk_Store_Id] FOREIGN KEY([fk_Store_Id])
REFERENCES [dbo].[Store] ([Store_Id])
GO
ALTER TABLE [dbo].[register] CHECK CONSTRAINT [fk_Store_Id]
GO
/****** Object:  ForeignKey [FK__sale__customer_i__59FA5E80]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[sale]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([customerID])
GO
/****** Object:  ForeignKey [FK__sale__register_i__03F0984C]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[sale]  WITH CHECK ADD FOREIGN KEY([register_id])
REFERENCES [dbo].[register] ([register_id])
GO
/****** Object:  ForeignKey [FK__sales_lin__sale___60A75C0F]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[sales_lineitem]  WITH CHECK ADD FOREIGN KEY([sale_id])
REFERENCES [dbo].[sale] ([sale_id])
GO
/****** Object:  ForeignKey [fk_Product_Catalog_Id]    Script Date: 01/28/2013 11:44:59 ******/
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [fk_Product_Catalog_Id] FOREIGN KEY([fk_Product_Catalog_Id])
REFERENCES [dbo].[Product_Catalog] ([Product_Catalog_Id])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [fk_Product_Catalog_Id]
GO
