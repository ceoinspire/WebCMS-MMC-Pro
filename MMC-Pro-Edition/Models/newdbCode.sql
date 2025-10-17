
/****** Object:  Schema [AST]    Script Date: 07/09/2025 3:48:03 pm ******/
CREATE SCHEMA [AST]
GO
/****** Object:  Schema [Business]    Script Date: 07/09/2025 3:48:03 pm ******/
CREATE SCHEMA [Business]
GO
/****** Object:  Schema [HRM]    Script Date: 07/09/2025 3:48:03 pm ******/
CREATE SCHEMA [HRM]
GO
/****** Object:  Schema [INV]    Script Date: 07/09/2025 3:48:03 pm ******/
CREATE SCHEMA [INV]
GO
/****** Object:  Schema [MEDIA]    Script Date: 07/09/2025 3:48:03 pm ******/
CREATE SCHEMA [MEDIA]
GO
/****** Object:  Schema [Setup]    Script Date: 07/09/2025 3:48:03 pm ******/
CREATE SCHEMA [Setup]
GO
/****** Object:  Schema [SYSTEM]    Script Date: 07/09/2025 3:48:03 pm ******/
CREATE SCHEMA [SYSTEM]
GO
/****** Object:  Schema [WEBCMS]    Script Date: 07/09/2025 3:48:03 pm ******/
CREATE SCHEMA [WEBCMS]
GO
/****** Object:  Table [AST].[Buildings]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AST].[Buildings](
	[BuildingId] [uniqueidentifier] NOT NULL,
	[BuildingName] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[IsDeleted] [bit] NULL,
	[BranchId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AST].[Floors]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AST].[Floors](
	[FloorId] [uniqueidentifier] NOT NULL,
	[FloorName] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[IsDeleted] [bit] NULL,
	[BuildingId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Floors] PRIMARY KEY CLUSTERED 
(
	[FloorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AST].[ServingTables]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AST].[ServingTables](
	[ServingTableId] [uniqueidentifier] NOT NULL,
	[TableName] [nvarchar](50) NULL,
	[TableNumber] [int] NULL,
	[SittingCapacity] [int] NULL,
	[FloorId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ServingTables] PRIMARY KEY CLUSTERED 
(
	[ServingTableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Business].[Branches]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Branches](
	[BranchId] [uniqueidentifier] NOT NULL,
	[BranchName] [nvarchar](500) NULL,
	[OrganizationId] [int] NULL,
	[BusinessCategoryId] [smallint] NULL,
	[BusinessStoreTypeId] [smallint] NULL,
	[BusinessEntityTypeId] [smallint] NULL,
	[BranchCode] [varchar](500) NULL,
	[IsMasterBranch] [bit] NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Business].[BusinessCategory]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[BusinessCategory](
	[BusinessCategoryId] [smallint] NOT NULL,
	[BusinessCategoryName] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[BusinessCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Business].[BusinessEntityType]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[BusinessEntityType](
	[BusinessEntityTypeId] [smallint] NOT NULL,
	[BusinessEntityTypeName] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BusinessEntityTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Business].[BusinessStoreType]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[BusinessStoreType](
	[BusinessStoreTypeId] [smallint] NOT NULL,
	[BusinessStoreTypeName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK__Business__673FC7EDA67B78A0] PRIMARY KEY CLUSTERED 
(
	[BusinessStoreTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Business].[Organizations]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Business].[Organizations](
	[OrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationName] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK__Business__A1682FC590D5A421] PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[Cities]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[Cities](
	[CityId] [int] NOT NULL,
	[CityName] [nvarchar](1000) NULL,
	[StateProvinceId] [int] NULL,
	[CountryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[Countries]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[Countries](
	[CountryId] [int] NOT NULL,
	[CountryName] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[Customers]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[Customers](
	[CustomerId] [uniqueidentifier] NOT NULL,
	[CustomerCode] [nvarchar](50) NULL,
	[PersonId] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[BranchId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[Employee]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[Employee](
	[EmployeeId] [int] NOT NULL,
	[EmployeeCode] [nvarchar](50) NULL,
	[DepartmentId] [int] NULL,
	[DesignationId] [int] NULL,
	[CreatedOn] [date] NULL,
	[IsActive] [bit] NULL,
	[PersonId] [int] NULL,
	[IsSalePerson] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[EmployeeDepartments]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[EmployeeDepartments](
	[EmployeeDepartmentId] [int] NOT NULL,
	[Title] [nvarchar](500) NULL,
 CONSTRAINT [PK_EmployeeDepartments] PRIMARY KEY CLUSTERED 
(
	[EmployeeDepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[EmployeeDesignation]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[EmployeeDesignation](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[LaneAddresses]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[LaneAddresses](
	[AddressId] [int] NOT NULL,
	[LaneAddressOne] [nvarchar](2000) NULL,
	[LaneAddressTwo] [nvarchar](2000) NULL,
	[Area] [nvarchar](2000) NULL,
	[FamousPlace] [nvarchar](2000) NULL,
	[PersonId] [int] NULL,
	[CityId] [int] NULL,
	[AddressType] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[LoginHistory]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[LoginHistory](
	[Id] [int] NOT NULL,
	[LastLogin] [datetime] NULL,
	[LoginUserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[LoginUserDeviceDetail]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[LoginUserDeviceDetail](
	[Id] [int] NOT NULL,
	[DeviceName] [nvarchar](100) NULL,
	[DeviceIP] [nvarchar](100) NULL,
	[LoginUserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[LoginUsers]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[LoginUsers](
	[Id] [int] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](1000) NULL,
	[PersonId] [int] NULL,
	[SettingsId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[Persons]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[Persons](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[CNIC] [nvarchar](50) NULL,
	[SocialSecurity] [nvarchar](10) NULL,
	[Email] [nvarchar](50) NULL,
	[ImageURL] [nvarchar](max) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[BranchId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [HRM].[StateProvince]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[StateProvince](
	[StateProvinceId] [int] NOT NULL,
	[StateProvinceName] [nvarchar](1000) NULL,
	[CountryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StateProvinceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[Supplier]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[Supplier](
	[SupplierId] [int] NOT NULL,
	[SupplierBusinessName] [nvarchar](500) NULL,
	[SupplierCode] [nvarchar](500) NULL,
	[CreatedOn] [date] NULL,
	[NTN] [nvarchar](100) NULL,
	[CompanyLogo] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__Supplier__4BE666B48F48E7DA] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[SupplierContact]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[SupplierContact](
	[SpplierContactId] [int] NOT NULL,
	[PersonId] [int] NULL,
	[SupplierId] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_SupplierContact] PRIMARY KEY CLUSTERED 
(
	[SpplierContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HRM].[UserAssignedBranches]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HRM].[UserAssignedBranches](
	[UserAssignedBranches] [int] IDENTITY(1,1) NOT NULL,
	[LoginUserId] [int] NULL,
	[BranchId] [uniqueidentifier] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[Createdby] [int] NULL,
 CONSTRAINT [PK_UserAssignedBranches] PRIMARY KEY CLUSTERED 
(
	[UserAssignedBranches] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[BranchStock]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[BranchStock](
	[BranchStockId] [uniqueidentifier] NOT NULL,
	[ProductVariantId] [uniqueidentifier] NULL,
	[BranchId] [uniqueidentifier] NULL,
	[SalePrice] [decimal](18, 2) NULL,
	[RetailPrice] [decimal](18, 2) NULL,
	[PromotionPrice] [decimal](18, 2) NULL,
	[StaffPrice] [decimal](18, 2) NULL,
	[Cost] [decimal](18, 2) NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[LastSold] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[BranchStockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[Brands]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[Brands](
	[BrandId] [uniqueidentifier] NOT NULL,
	[BrandName] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsDefault] [bit] NULL,
	[BrandSlug] [nvarchar](500) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[CartDetail]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[CartDetail](
	[CartDetailId] [uniqueidentifier] NOT NULL,
	[CartId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[VariantId] [uniqueidentifier] NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[Tax] [decimal](18, 2) NULL,
	[TotalAmount]  AS (([Quantity]*[UnitPrice]-[Discount])+[Tax]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[CartDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[CartMaster]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[CartMaster](
	[CartId] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NULL,
	[SessionId] [varchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsCheckedOut] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[Categories]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[Categories](
	[CategoryId] [uniqueidentifier] NOT NULL,
	[CategoryName] [nvarchar](1000) NULL,
	[DepartmentId] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CategorySlug] [nvarchar](500) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[CollectionDetail]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[CollectionDetail](
	[CollectionDetailId] [uniqueidentifier] NOT NULL,
	[CollectionId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NULL,
	[VariantId] [uniqueidentifier] NULL,
	[SortOrder] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CollectionDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[CollectionMaster]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[CollectionMaster](
	[CollectionId] [uniqueidentifier] NOT NULL,
	[CollectionName] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CollectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [INV].[Colors]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[Colors](
	[ColorId] [uniqueidentifier] NOT NULL,
	[ColorName] [nvarchar](500) NULL,
	[BusinessStoreId] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ColorSlug] [nvarchar](500) NULL,
	[BranchId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[Departments]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[Departments](
	[DepartmentId] [uniqueidentifier] NOT NULL,
	[DepartmentName] [nvarchar](1000) NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[DepartmentSlug] [nvarchar](500) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[InvoiceDetail]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[InvoiceDetail](
	[InvoiceDetailId] [uniqueidentifier] NOT NULL,
	[InvoiceMasterId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[VariantId] [uniqueidentifier] NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[Tax] [decimal](18, 2) NULL,
	[TotalAmount]  AS (([Quantity]*[UnitPrice]-[Discount])+[Tax]) PERSISTED,
	[Remarks] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[InvoiceMaster]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[InvoiceMaster](
	[InvoiceMasterId] [uniqueidentifier] NOT NULL,
	[InvoiceNo] [varchar](50) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[CustomerId] [uniqueidentifier] NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[TaxAmount] [decimal](18, 2) NULL,
	[NetAmount]  AS (([TotalAmount]-[DiscountAmount])+[TaxAmount]) PERSISTED,
	[PaymentMethodId] [int] NULL,
	[PaymentStatus] [varchar](50) NULL,
	[Remarks] [nvarchar](500) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[ServingTableId] [uniqueidentifier] NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK__InvoiceM__FD3450D12EF631B1] PRIMARY KEY CLUSTERED 
(
	[InvoiceMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[Material]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[Material](
	[MaterialId] [uniqueidentifier] NOT NULL,
	[MaterialName] [nvarchar](500) NULL,
	[BranchId] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[MaterialSlug] [nvarchar](500) NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[MaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[ProductBranches]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[ProductBranches](
	[ProductBranchesId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NULL,
	[BranchId] [uniqueidentifier] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_ProductBranches] PRIMARY KEY CLUSTERED 
(
	[ProductBranchesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[ProductImages]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[ProductImages](
	[ProductImageId] [uniqueidentifier] NOT NULL,
	[ImageUrl] [nvarchar](1000) NULL,
	[Caption] [nvarchar](50) NULL,
	[Priority] [smallint] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsDefault] [bit] NULL,
	[OrganizationId] [int] NULL,
	[BranchId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[ProductImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[Products]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[Products](
	[ProductId] [uniqueidentifier] NOT NULL,
	[ProductName] [nvarchar](1000) NULL,
	[ProductDescription] [nvarchar](1000) NULL,
	[QOH] [decimal](18, 2) NULL,
	[BrandId] [uniqueidentifier] NULL,
	[SubCategoryId] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[SupplierId] [int] NULL,
	[ProductSlug] [nvarchar](500) NULL,
	[UOMId] [uniqueidentifier] NULL,
	[OrganizationId] [int] NULL,
	[BranchId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[ProductVariants]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[ProductVariants](
	[VariantId] [uniqueidentifier] NOT NULL,
	[MaterialId] [uniqueidentifier] NULL,
	[ColorId] [uniqueidentifier] NULL,
	[SizeId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[BarCode] [nvarchar](500) NULL,
	[LastPurchase] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[VariantImageId] [uniqueidentifier] NULL,
	[SubUOMId] [uniqueidentifier] NULL,
	[QuantityPerUnit] [decimal](18, 0) NULL,
	[IsSerial] [bit] NULL,
	[MinQty] [int] NULL,
	[MaxQty] [int] NULL,
	[PriceFormat] [int] NULL,
	[BranchId] [uniqueidentifier] NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK_ProductVariants] PRIMARY KEY CLUSTERED 
(
	[VariantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[PurchaseDetail]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[PurchaseDetail](
	[PurchaseDetailId] [uniqueidentifier] NOT NULL,
	[PurchaseMasterId] [uniqueidentifier] NOT NULL,
	[VariantId] [uniqueidentifier] NULL,
	[Qty] [decimal](18, 2) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[TotalPrice]  AS ([Qty]*[UnitPrice]) PERSISTED,
	[DiscountAmount] [decimal](18, 2) NULL,
	[LineTotal]  AS ([Qty]*[UnitPrice]-[DiscountAmount]) PERSISTED,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_PurchaseDetail] PRIMARY KEY CLUSTERED 
(
	[PurchaseDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[PurchaseMaster]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[PurchaseMaster](
	[PurchaseMasterId] [uniqueidentifier] NOT NULL,
	[PurchaseNumber] [nvarchar](50) NULL,
	[PurchaseType] [int] NULL,
	[SupplierId] [int] NULL,
	[PurchaseDate] [datetime] NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[Status] [int] NULL,
	[Remarks] [nvarchar](500) NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[BranchId] [uniqueidentifier] NULL,
	[OrganizationId] [int] NULL,
	[ParentId] [uniqueidentifier] NULL,
 CONSTRAINT [PK__Purchase__5450C11901866B34] PRIMARY KEY CLUSTERED 
(
	[PurchaseMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Purchase__373B5B6EE9029448] UNIQUE NONCLUSTERED 
(
	[PurchaseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[Sizes]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[Sizes](
	[SizeId] [uniqueidentifier] NOT NULL,
	[SizeName] [nvarchar](1000) NULL,
	[BranchId] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[SizeSlug] [nvarchar](100) NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[SizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[SubCategory]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[SubCategory](
	[SubCategoryId] [uniqueidentifier] NOT NULL,
	[SubCategoryName] [nvarchar](1000) NULL,
	[CategoryId] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[SubCategorySlug] [nvarchar](500) NULL,
 CONSTRAINT [PK_SubCategoryId] PRIMARY KEY CLUSTERED 
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[UOM]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[UOM](
	[UOMId] [uniqueidentifier] NOT NULL,
	[UOMName] [nvarchar](50) NULL,
	[UOMType] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_UOM] PRIMARY KEY CLUSTERED 
(
	[UOMId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [INV].[UOMSub]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [INV].[UOMSub](
	[SubUOMId] [uniqueidentifier] NOT NULL,
	[UOMId] [uniqueidentifier] NULL,
	[SubUOMName] [nvarchar](500) NULL,
	[ConversionFactor] [decimal](4, 2) NULL,
	[CreatedOn] [datetime] NULL,
	[Createdby] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_UOMSub] PRIMARY KEY CLUSTERED 
(
	[SubUOMId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [MEDIA].[FileManager]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDIA].[FileManager](
	[Id] [int] NOT NULL,
	[URL] [nvarchar](1000) NULL,
	[Caption] [nvarchar](1000) NULL,
	[Priority] [int] NULL,
	[ContentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Setup].[AccountingPreferences]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setup].[AccountingPreferences](
	[FiscalYearStartMonth] [nvarchar](20) NULL,
	[FiscalYearEndMonth] [nvarchar](20) NULL,
	[FiscalYearStartDate] [date] NULL,
	[FiscalYearEndDate] [date] NULL,
	[EnableMultiCurrency] [bit] NOT NULL,
	[BaseCurrencyCode] [nvarchar](10) NULL,
	[DefaultExchangeRateSource] [nvarchar](50) NULL,
	[EnableAutomaticYearClosing] [bit] NOT NULL,
	[LockTransactionsAfterPeriodClose] [bit] NOT NULL,
	[DefaultSalesAccount] [nvarchar](100) NULL,
	[DefaultPurchaseAccount] [nvarchar](100) NULL,
	[DefaultTaxAccount] [nvarchar](100) NULL,
	[AllowBackDatedTransactions] [bit] NOT NULL,
	[AccountingPreferenceId] [uniqueidentifier] NOT NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AccountingPreferences_Id] PRIMARY KEY CLUSTERED 
(
	[AccountingPreferenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Setup].[PaymentMethods]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setup].[PaymentMethods](
	[PaymentMethodId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [date] NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Setup].[SystemPreferences]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setup].[SystemPreferences](
	[CompanyName] [nvarchar](200) NULL,
	[IsRestaurantApplication] [bit] NOT NULL,
	[CompanyLogoUrl] [nvarchar](500) NULL,
	[DefaultLanguage] [nvarchar](50) NULL,
	[TimeZone] [nvarchar](100) NULL,
	[DateFormat] [nvarchar](20) NULL,
	[CurrencyCode] [nvarchar](10) NULL,
	[CurrencySymbol] [nvarchar](10) NULL,
	[DecimalPlaces] [int] NOT NULL,
	[IsAffilatedInvoice] [bit] NOT NULL,
	[EnableTax] [bit] NOT NULL,
	[DefaultTaxRate] [decimal](10, 2) NULL,
	[TaxRegistrationNumber] [nvarchar](100) NULL,
	[PricesIncludeTax] [bit] NOT NULL,
	[EnableInventoryTracking] [bit] NOT NULL,
	[DefaultWarehouse] [nvarchar](100) NULL,
	[LowStockThreshold] [int] NULL,
	[AllowNegativeStock] [bit] NOT NULL,
	[InvoicePrefix] [nvarchar](20) NULL,
	[InvoiceStartNumber] [int] NULL,
	[QuotationPrefix] [nvarchar](20) NULL,
	[ReceiptPrefix] [nvarchar](20) NULL,
	[ShowLogoOnInvoices] [bit] NOT NULL,
	[ShowTaxBreakdown] [bit] NOT NULL,
	[EnableTwoFactorAuth] [bit] NOT NULL,
	[SessionTimeoutMinutes] [int] NULL,
	[AllowMultipleLogins] [bit] NOT NULL,
	[SmtpServer] [nvarchar](200) NULL,
	[SmtpPort] [int] NULL,
	[SmtpUserName] [nvarchar](200) NULL,
	[SmtpPassword] [nvarchar](200) NULL,
	[EnableSsl] [bit] NOT NULL,
	[DefaultFromEmail] [nvarchar](200) NULL,
	[EnableAutoBackup] [bit] NOT NULL,
	[AutoBackupIntervalDays] [int] NULL,
	[BackupLocation] [nvarchar](500) NULL,
	[SystemPreferenceId] [uniqueidentifier] NOT NULL,
	[BranchId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SystemPreferences_Id] PRIMARY KEY CLUSTERED 
(
	[SystemPreferenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SYSTEM].[AssignedRoles]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[AssignedRoles](
	[Id] [int] NOT NULL,
	[RoleId] [int] NULL,
	[LoginId] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[Createdby] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SYSTEM].[ErpPermissions]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[ErpPermissions](
	[PermissionId] [int] NOT NULL,
	[UserId] [int] NULL,
	[CanView] [bit] NULL,
	[CanEdit] [bit] NULL,
	[CanDelete] [bit] NULL,
	[CanCreate] [bit] NULL,
	[UrlMenuId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SYSTEM].[Notifications]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Params] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NULL,
	[GroupName] [nvarchar](255) NULL,
	[IsRead] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[NotificationTypeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [SYSTEM].[NotificationTypes]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[NotificationTypes](
	[NotificationTypeId] [int] NOT NULL,
	[NotificationTypeName] [nvarchar](500) NULL,
 CONSTRAINT [PK_NotificationTypes] PRIMARY KEY CLUSTERED 
(
	[NotificationTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SYSTEM].[Roles]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[Roles](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SYSTEM].[Settings]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[Settings](
	[SettingsId] [int] NOT NULL,
	[ApplicationId] [int] NULL,
	[ApplicationURL] [nvarchar](1000) NULL,
	[IsActive] [bit] NULL,
	[BranchId] [uniqueidentifier] NULL,
	[ApplicationName] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[SettingsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SYSTEM].[UrlMenu]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[UrlMenu](
	[UrlMenuId] [int] NOT NULL,
	[UrlMenuLink] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UrlMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SYSTEM].[Website]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[Website](
	[WebsiteId] [int] NOT NULL,
	[WebsiteName] [nvarchar](500) NULL,
	[WebsiteLogo] [nvarchar](max) NULL,
	[WebsiteLogoTwo] [nvarchar](max) NULL,
	[FavIcon] [nvarchar](max) NULL,
	[WebsiteDescription] [nvarchar](max) NULL,
	[WebsiteTitle] [nvarchar](max) NULL,
	[SupportEmail] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[WebsiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [SYSTEM].[WebsiteData]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SYSTEM].[WebsiteData](
	[WebsiteDataId] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[value] [nvarchar](50) NULL,
	[WebsiteId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[WebsiteDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [WEBCMS].[CmsContentSharedCategory]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [WEBCMS].[CmsContentSharedCategory](
	[Id] [int] NOT NULL,
	[ContentId] [int] NULL,
	[CategoryId] [int] NULL,
	[CreatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [WEBCMS].[CmsEmail]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [WEBCMS].[CmsEmail](
	[EmailId] [int] NOT NULL,
	[WebsiteId] [int] NULL,
	[EmailSubject] [nvarchar](500) NULL,
	[EmailSender] [nvarchar](500) NULL,
	[EmailBody] [nvarchar](max) NULL,
	[DateCreated] [date] NULL,
	[FirstName] [nvarchar](500) NULL,
	[LastName] [nvarchar](500) NULL,
	[FullName] [nvarchar](500) NULL,
	[Mobile] [nvarchar](500) NULL,
	[LandLine] [nvarchar](500) NULL,
	[IsSend] [bit] NULL,
	[StatusMessage] [nvarchar](500) NULL,
	[IsRead] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [WEBCMS].[CMSEmailSent]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [WEBCMS].[CMSEmailSent](
	[EmailSentId] [int] NOT NULL,
	[ToEmailAddress] [nvarchar](255) NOT NULL,
	[FromEmailAddress] [nvarchar](255) NOT NULL,
	[Subject] [nvarchar](500) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[SentDateTime] [datetime] NOT NULL,
	[IsSent] [bit] NOT NULL,
	[IsRead] [bit] NOT NULL,
	[UserId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[EmailId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmailSentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [WEBCMS].[Comments]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [WEBCMS].[Comments](
	[CommentId] [int] NOT NULL,
	[Comment] [nvarchar](1000) NULL,
	[CreatedOn] [datetime] NULL,
	[LoginUser] [int] NULL,
	[IsPublished] [bit] NULL,
	[ApprovedBy] [int] NULL,
	[UserIP] [nvarchar](50) NULL,
	[UserBrowser] [nvarchar](50) NULL,
	[ReviewId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [WEBCMS].[Content]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [WEBCMS].[Content](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](1000) NULL,
	[Tagline] [nvarchar](1000) NULL,
	[OverView] [nvarchar](max) NULL,
	[VideoLink] [nvarchar](500) NULL,
	[Note] [nvarchar](1000) NULL,
	[Description] [nvarchar](max) NULL,
	[ImageSource] [nvarchar](500) NULL,
	[Thumbnail] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[WebSiteId] [int] NULL,
	[ContentTypeId] [int] NULL,
	[OtherTitle] [nvarchar](1500) NULL,
	[MetaDescription] [nvarchar](1500) NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[OtherShortDescription] [nvarchar](max) NULL,
	[OtherDescription] [nvarchar](max) NULL,
	[Priority] [int] NULL,
	[Icon] [nvarchar](50) NULL,
	[MetaTitle] [nvarchar](1500) NULL,
	[HeaderPhoto] [nvarchar](500) NULL,
	[ContentSlug] [nvarchar](1000) NULL,
	[FwdUrl] [nvarchar](800) NULL,
	[MetaKeyword] [nvarchar](1500) NULL,
	[ParentId] [int] NULL,
	[Date] [date] NULL,
	[LoginUserId] [int] NULL,
	[Ipaddress] [nvarchar](500) NULL,
	[IsPublished] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [WEBCMS].[ContentCategory]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [WEBCMS].[ContentCategory](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](501) NULL,
	[TypeId] [int] NOT NULL,
	[CreatedOn] [nvarchar](50) NULL,
	[Slug] [nvarchar](501) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [WEBCMS].[ContentType]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [WEBCMS].[ContentType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[TypeSlug] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [WEBCMS].[LinkedContentItems]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [WEBCMS].[LinkedContentItems](
	[LinkedItemId] [int] NOT NULL,
	[LinkedContentId] [int] NULL,
	[ContentId] [int] NULL,
	[Priority] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LinkedItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [WEBCMS].[Reviews]    Script Date: 07/09/2025 3:48:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [WEBCMS].[Reviews](
	[ReviewId] [int] NOT NULL,
	[ReviewComment] [nvarchar](1000) NULL,
	[Rating] [smallint] NULL,
	[CreatedOn] [datetime] NULL,
	[LoginUserId] [int] NULL,
	[IsPublished] [bit] NULL,
	[ApprovedBy] [int] NULL,
	[UserIP] [nvarchar](50) NULL,
	[UserBrowser] [nvarchar](50) NULL,
	[ContentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Business].[Branches] ADD  CONSTRAINT [DF_Branches_IsMasterBranch]  DEFAULT ((0)) FOR [IsMasterBranch]
GO
ALTER TABLE [INV].[BranchStock] ADD  DEFAULT ((0)) FOR [Qty]
GO
ALTER TABLE [INV].[BranchStock] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [INV].[BranchStock] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [INV].[BranchStock] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [INV].[CartDetail] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [INV].[CartDetail] ADD  DEFAULT ((0)) FOR [Tax]
GO
ALTER TABLE [INV].[CartMaster] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [INV].[CartMaster] ADD  DEFAULT ((0)) FOR [IsCheckedOut]
GO
ALTER TABLE [INV].[CollectionDetail] ADD  DEFAULT (newid()) FOR [CollectionDetailId]
GO
ALTER TABLE [INV].[CollectionMaster] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [INV].[CollectionMaster] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [INV].[InvoiceDetail] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [INV].[InvoiceDetail] ADD  DEFAULT ((0)) FOR [Tax]
GO
ALTER TABLE [INV].[InvoiceMaster] ADD  CONSTRAINT [DF__InvoiceMa__Disco__5F492382]  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [INV].[InvoiceMaster] ADD  CONSTRAINT [DF__InvoiceMa__TaxAm__603D47BB]  DEFAULT ((0)) FOR [TaxAmount]
GO
ALTER TABLE [INV].[InvoiceMaster] ADD  CONSTRAINT [DF__InvoiceMa__Creat__61316BF4]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [INV].[PurchaseDetail] ADD  CONSTRAINT [DF__PurchaseD__Disco__17C286CF]  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Purch__0880433F]  DEFAULT ((1)) FOR [PurchaseType]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Purch__09746778]  DEFAULT (getdate()) FOR [PurchaseDate]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Disco__0A688BB1]  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Total__0B5CAFEA]  DEFAULT ((0)) FOR [TotalAmount]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Grand__0C50D423]  DEFAULT ((0)) FOR [GrandTotal]
GO
ALTER TABLE [INV].[PurchaseMaster] ADD  CONSTRAINT [DF__PurchaseM__Statu__0D44F85C]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [Setup].[AccountingPreferences] ADD  DEFAULT ((0)) FOR [EnableMultiCurrency]
GO
ALTER TABLE [Setup].[AccountingPreferences] ADD  DEFAULT ((0)) FOR [EnableAutomaticYearClosing]
GO
ALTER TABLE [Setup].[AccountingPreferences] ADD  DEFAULT ((0)) FOR [LockTransactionsAfterPeriodClose]
GO
ALTER TABLE [Setup].[AccountingPreferences] ADD  DEFAULT ((0)) FOR [AllowBackDatedTransactions]
GO
ALTER TABLE [Setup].[AccountingPreferences] ADD  CONSTRAINT [DF_AccountingPreferences_Id]  DEFAULT (newid()) FOR [AccountingPreferenceId]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [IsRestaurantApplication]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((2)) FOR [DecimalPlaces]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [IsAffilatedInvoice]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [EnableTax]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [PricesIncludeTax]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [EnableInventoryTracking]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [AllowNegativeStock]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [ShowLogoOnInvoices]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [ShowTaxBreakdown]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [EnableTwoFactorAuth]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [AllowMultipleLogins]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [EnableSsl]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  DEFAULT ((0)) FOR [EnableAutoBackup]
GO
ALTER TABLE [Setup].[SystemPreferences] ADD  CONSTRAINT [DF_SystemPreferences_Id]  DEFAULT (newid()) FOR [SystemPreferenceId]
GO
ALTER TABLE [SYSTEM].[Notifications] ADD  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [SYSTEM].[Notifications] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [AST].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Branches] FOREIGN KEY([BranchId])
REFERENCES [Business].[Branches] ([BranchId])
GO
ALTER TABLE [AST].[Buildings] CHECK CONSTRAINT [FK_Buildings_Branches]
GO
ALTER TABLE [AST].[Floors]  WITH CHECK ADD  CONSTRAINT [FK_Floors_Buildings] FOREIGN KEY([BuildingId])
REFERENCES [AST].[Buildings] ([BuildingId])
GO
ALTER TABLE [AST].[Floors] CHECK CONSTRAINT [FK_Floors_Buildings]
GO
ALTER TABLE [AST].[ServingTables]  WITH CHECK ADD  CONSTRAINT [FK_ServingTables_Floors] FOREIGN KEY([FloorId])
REFERENCES [AST].[Floors] ([FloorId])
GO
ALTER TABLE [AST].[ServingTables] CHECK CONSTRAINT [FK_ServingTables_Floors]
GO
ALTER TABLE [Business].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Branches_BusinessCategory] FOREIGN KEY([BusinessCategoryId])
REFERENCES [Business].[BusinessCategory] ([BusinessCategoryId])
GO
ALTER TABLE [Business].[Branches] CHECK CONSTRAINT [FK_Branches_BusinessCategory]
GO
ALTER TABLE [Business].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Branches_BusinessEntityType] FOREIGN KEY([BusinessEntityTypeId])
REFERENCES [Business].[BusinessEntityType] ([BusinessEntityTypeId])
GO
ALTER TABLE [Business].[Branches] CHECK CONSTRAINT [FK_Branches_BusinessEntityType]
GO
ALTER TABLE [Business].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Branches_BusinessStoreType] FOREIGN KEY([BusinessStoreTypeId])
REFERENCES [Business].[BusinessStoreType] ([BusinessStoreTypeId])
GO
ALTER TABLE [Business].[Branches] CHECK CONSTRAINT [FK_Branches_BusinessStoreType]
GO
ALTER TABLE [Business].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Organizations] FOREIGN KEY([OrganizationId])
REFERENCES [Business].[Organizations] ([OrganizationId])
GO
ALTER TABLE [Business].[Branches] CHECK CONSTRAINT [FK_Branches_Organizations]
GO
ALTER TABLE [HRM].[Cities]  WITH NOCHECK ADD  CONSTRAINT [FK_Cities_StateProvince] FOREIGN KEY([StateProvinceId])
REFERENCES [HRM].[StateProvince] ([StateProvinceId])
GO
ALTER TABLE [HRM].[Cities] CHECK CONSTRAINT [FK_Cities_StateProvince]
GO
ALTER TABLE [HRM].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Persons] FOREIGN KEY([PersonId])
REFERENCES [HRM].[Persons] ([Id])
GO
ALTER TABLE [HRM].[Customers] CHECK CONSTRAINT [FK_Customers_Persons]
GO
ALTER TABLE [HRM].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_EmployeeDepartments] FOREIGN KEY([DepartmentId])
REFERENCES [HRM].[EmployeeDepartments] ([EmployeeDepartmentId])
GO
ALTER TABLE [HRM].[Employee] CHECK CONSTRAINT [FK_Employee_EmployeeDepartments]
GO
ALTER TABLE [HRM].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_EmployeeDesignation] FOREIGN KEY([DesignationId])
REFERENCES [HRM].[EmployeeDesignation] ([Id])
GO
ALTER TABLE [HRM].[Employee] CHECK CONSTRAINT [FK_Employee_EmployeeDesignation]
GO
ALTER TABLE [HRM].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Persons] FOREIGN KEY([PersonId])
REFERENCES [HRM].[Persons] ([Id])
GO
ALTER TABLE [HRM].[Employee] CHECK CONSTRAINT [FK_Employee_Persons]
GO
ALTER TABLE [HRM].[LaneAddresses]  WITH CHECK ADD  CONSTRAINT [FK_LaneAddresses_Cities1] FOREIGN KEY([CityId])
REFERENCES [HRM].[Cities] ([CityId])
GO
ALTER TABLE [HRM].[LaneAddresses] CHECK CONSTRAINT [FK_LaneAddresses_Cities1]
GO
ALTER TABLE [HRM].[LaneAddresses]  WITH CHECK ADD  CONSTRAINT [FK_LaneAddresses_Persons] FOREIGN KEY([PersonId])
REFERENCES [HRM].[Persons] ([Id])
GO
ALTER TABLE [HRM].[LaneAddresses] CHECK CONSTRAINT [FK_LaneAddresses_Persons]
GO
ALTER TABLE [HRM].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginHistory_LoginUsers] FOREIGN KEY([LoginUserId])
REFERENCES [HRM].[LoginUsers] ([Id])
GO
ALTER TABLE [HRM].[LoginHistory] CHECK CONSTRAINT [FK_LoginHistory_LoginUsers]
GO
ALTER TABLE [HRM].[LoginUserDeviceDetail]  WITH CHECK ADD  CONSTRAINT [FK_LoginUserDeviceDetail_LoginUsers] FOREIGN KEY([LoginUserId])
REFERENCES [HRM].[LoginUsers] ([Id])
GO
ALTER TABLE [HRM].[LoginUserDeviceDetail] CHECK CONSTRAINT [FK_LoginUserDeviceDetail_LoginUsers]
GO
ALTER TABLE [HRM].[LoginUsers]  WITH CHECK ADD  CONSTRAINT [FK_LoginUsers_Persons] FOREIGN KEY([PersonId])
REFERENCES [HRM].[Persons] ([Id])
GO
ALTER TABLE [HRM].[LoginUsers] CHECK CONSTRAINT [FK_LoginUsers_Persons]
GO
ALTER TABLE [HRM].[LoginUsers]  WITH CHECK ADD  CONSTRAINT [FK_LoginUsers_Settings] FOREIGN KEY([SettingsId])
REFERENCES [SYSTEM].[Settings] ([SettingsId])
GO
ALTER TABLE [HRM].[LoginUsers] CHECK CONSTRAINT [FK_LoginUsers_Settings]
GO
ALTER TABLE [HRM].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Branches] FOREIGN KEY([BranchId])
REFERENCES [Business].[Branches] ([BranchId])
GO
ALTER TABLE [HRM].[Persons] CHECK CONSTRAINT [FK_Persons_Branches]
GO
ALTER TABLE [HRM].[StateProvince]  WITH CHECK ADD  CONSTRAINT [FK_StateProvince_Countries] FOREIGN KEY([CountryId])
REFERENCES [HRM].[Countries] ([CountryId])
GO
ALTER TABLE [HRM].[StateProvince] CHECK CONSTRAINT [FK_StateProvince_Countries]
GO
ALTER TABLE [HRM].[SupplierContact]  WITH CHECK ADD  CONSTRAINT [FK_SupplierContact_Persons] FOREIGN KEY([PersonId])
REFERENCES [HRM].[Persons] ([Id])
GO
ALTER TABLE [HRM].[SupplierContact] CHECK CONSTRAINT [FK_SupplierContact_Persons]
GO
ALTER TABLE [HRM].[SupplierContact]  WITH CHECK ADD  CONSTRAINT [FK_SupplierContact_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [HRM].[Supplier] ([SupplierId])
GO
ALTER TABLE [HRM].[SupplierContact] CHECK CONSTRAINT [FK_SupplierContact_Supplier]
GO
ALTER TABLE [HRM].[UserAssignedBranches]  WITH CHECK ADD  CONSTRAINT [FK_UserAssignedBranches_Branches] FOREIGN KEY([BranchId])
REFERENCES [Business].[Branches] ([BranchId])
GO
ALTER TABLE [HRM].[UserAssignedBranches] CHECK CONSTRAINT [FK_UserAssignedBranches_Branches]
GO
ALTER TABLE [HRM].[UserAssignedBranches]  WITH CHECK ADD  CONSTRAINT [FK_UserAssignedBranches_LoginUsers] FOREIGN KEY([LoginUserId])
REFERENCES [HRM].[LoginUsers] ([Id])
GO
ALTER TABLE [HRM].[UserAssignedBranches] CHECK CONSTRAINT [FK_UserAssignedBranches_LoginUsers]
GO
ALTER TABLE [INV].[BranchStock]  WITH CHECK ADD  CONSTRAINT [FK_BranchStock_Branch] FOREIGN KEY([BranchId])
REFERENCES [Business].[Branches] ([BranchId])
GO
ALTER TABLE [INV].[BranchStock] CHECK CONSTRAINT [FK_BranchStock_Branch]
GO
ALTER TABLE [INV].[BranchStock]  WITH CHECK ADD  CONSTRAINT [FK_BranchStock_ProductVariant] FOREIGN KEY([ProductVariantId])
REFERENCES [INV].[ProductVariants] ([VariantId])
GO
ALTER TABLE [INV].[BranchStock] CHECK CONSTRAINT [FK_BranchStock_ProductVariant]
GO
ALTER TABLE [INV].[CartDetail]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [INV].[CartMaster] ([CartId])
GO
ALTER TABLE [INV].[CartDetail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [INV].[Products] ([ProductId])
GO
ALTER TABLE [INV].[CartDetail]  WITH CHECK ADD FOREIGN KEY([VariantId])
REFERENCES [INV].[ProductVariants] ([VariantId])
GO
ALTER TABLE [INV].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [INV].[Departments] ([DepartmentId])
GO
ALTER TABLE [INV].[Categories] CHECK CONSTRAINT [FK_Categories_Departments]
GO
ALTER TABLE [INV].[CollectionDetail]  WITH CHECK ADD  CONSTRAINT [FK_CollectionDetail_CollectionMaster1] FOREIGN KEY([CollectionId])
REFERENCES [INV].[CollectionMaster] ([CollectionId])
GO
ALTER TABLE [INV].[CollectionDetail] CHECK CONSTRAINT [FK_CollectionDetail_CollectionMaster1]
GO
ALTER TABLE [INV].[CollectionDetail]  WITH CHECK ADD  CONSTRAINT [FK_CollectionDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [INV].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [INV].[CollectionDetail] CHECK CONSTRAINT [FK_CollectionDetail_Product]
GO
ALTER TABLE [INV].[CollectionDetail]  WITH CHECK ADD  CONSTRAINT [FK_CollectionDetail_Variant] FOREIGN KEY([VariantId])
REFERENCES [INV].[ProductVariants] ([VariantId])
ON DELETE CASCADE
GO
ALTER TABLE [INV].[CollectionDetail] CHECK CONSTRAINT [FK_CollectionDetail_Variant]
GO
ALTER TABLE [INV].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK__InvoiceDe__Invoi__725BF7F6] FOREIGN KEY([InvoiceMasterId])
REFERENCES [INV].[InvoiceMaster] ([InvoiceMasterId])
GO
ALTER TABLE [INV].[InvoiceDetail] CHECK CONSTRAINT [FK__InvoiceDe__Invoi__725BF7F6]
GO
ALTER TABLE [INV].[InvoiceDetail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [INV].[Products] ([ProductId])
GO
ALTER TABLE [INV].[InvoiceDetail]  WITH CHECK ADD FOREIGN KEY([VariantId])
REFERENCES [INV].[ProductVariants] ([VariantId])
GO
ALTER TABLE [INV].[InvoiceMaster]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceMaster_PaymentMethods] FOREIGN KEY([PaymentMethodId])
REFERENCES [Setup].[PaymentMethods] ([PaymentMethodId])
GO
ALTER TABLE [INV].[InvoiceMaster] CHECK CONSTRAINT [FK_InvoiceMaster_PaymentMethods]
GO
ALTER TABLE [INV].[ProductBranches]  WITH CHECK ADD  CONSTRAINT [FK_ProductBranches_Branches] FOREIGN KEY([BranchId])
REFERENCES [Business].[Branches] ([BranchId])
GO
ALTER TABLE [INV].[ProductBranches] CHECK CONSTRAINT [FK_ProductBranches_Branches]
GO
ALTER TABLE [INV].[ProductBranches]  WITH CHECK ADD  CONSTRAINT [FK_ProductBranches_Products] FOREIGN KEY([ProductId])
REFERENCES [INV].[Products] ([ProductId])
GO
ALTER TABLE [INV].[ProductBranches] CHECK CONSTRAINT [FK_ProductBranches_Products]
GO
ALTER TABLE [INV].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_Products] FOREIGN KEY([ProductId])
REFERENCES [INV].[Products] ([ProductId])
GO
ALTER TABLE [INV].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_Products]
GO
ALTER TABLE [INV].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands] FOREIGN KEY([BrandId])
REFERENCES [INV].[Brands] ([BrandId])
GO
ALTER TABLE [INV].[Products] CHECK CONSTRAINT [FK_Products_Brands]
GO
ALTER TABLE [INV].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Organizations] FOREIGN KEY([OrganizationId])
REFERENCES [Business].[Organizations] ([OrganizationId])
GO
ALTER TABLE [INV].[Products] CHECK CONSTRAINT [FK_Products_Organizations]
GO
ALTER TABLE [INV].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_SubCategoryId] FOREIGN KEY([SubCategoryId])
REFERENCES [INV].[SubCategory] ([SubCategoryId])
GO
ALTER TABLE [INV].[Products] CHECK CONSTRAINT [FK_Products_SubCategoryId]
GO
ALTER TABLE [INV].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [HRM].[Supplier] ([SupplierId])
GO
ALTER TABLE [INV].[Products] CHECK CONSTRAINT [FK_Products_Supplier]
GO
ALTER TABLE [INV].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_UOM] FOREIGN KEY([UOMId])
REFERENCES [INV].[UOM] ([UOMId])
GO
ALTER TABLE [INV].[Products] CHECK CONSTRAINT [FK_Products_UOM]
GO
ALTER TABLE [INV].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_ProductVariants_Colors] FOREIGN KEY([ColorId])
REFERENCES [INV].[Colors] ([ColorId])
GO
ALTER TABLE [INV].[ProductVariants] CHECK CONSTRAINT [FK_ProductVariants_Colors]
GO
ALTER TABLE [INV].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_ProductVariants_Material] FOREIGN KEY([MaterialId])
REFERENCES [INV].[Material] ([MaterialId])
GO
ALTER TABLE [INV].[ProductVariants] CHECK CONSTRAINT [FK_ProductVariants_Material]
GO
ALTER TABLE [INV].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_ProductVariants_Products] FOREIGN KEY([ProductId])
REFERENCES [INV].[Products] ([ProductId])
GO
ALTER TABLE [INV].[ProductVariants] CHECK CONSTRAINT [FK_ProductVariants_Products]
GO
ALTER TABLE [INV].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_ProductVariants_Sizes] FOREIGN KEY([SizeId])
REFERENCES [INV].[Sizes] ([SizeId])
GO
ALTER TABLE [INV].[ProductVariants] CHECK CONSTRAINT [FK_ProductVariants_Sizes]
GO
ALTER TABLE [INV].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_ProductVariants_UOMSub1] FOREIGN KEY([SubUOMId])
REFERENCES [INV].[UOMSub] ([SubUOMId])
GO
ALTER TABLE [INV].[ProductVariants] CHECK CONSTRAINT [FK_ProductVariants_UOMSub1]
GO
ALTER TABLE [INV].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK__PurchaseD__Purch__15DA3E5D] FOREIGN KEY([PurchaseMasterId])
REFERENCES [INV].[PurchaseMaster] ([PurchaseMasterId])
GO
ALTER TABLE [INV].[PurchaseDetail] CHECK CONSTRAINT [FK__PurchaseD__Purch__15DA3E5D]
GO
ALTER TABLE [INV].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK__PurchaseD__Varia__16CE6296] FOREIGN KEY([VariantId])
REFERENCES [INV].[ProductVariants] ([VariantId])
GO
ALTER TABLE [INV].[PurchaseDetail] CHECK CONSTRAINT [FK__PurchaseD__Varia__16CE6296]
GO
ALTER TABLE [INV].[PurchaseMaster]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseMaster_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [HRM].[Supplier] ([SupplierId])
GO
ALTER TABLE [INV].[PurchaseMaster] CHECK CONSTRAINT [FK_PurchaseMaster_Supplier]
GO
ALTER TABLE [INV].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategoryId_Categories] FOREIGN KEY([CategoryId])
REFERENCES [INV].[Categories] ([CategoryId])
GO
ALTER TABLE [INV].[SubCategory] CHECK CONSTRAINT [FK_SubCategoryId_Categories]
GO
ALTER TABLE [INV].[UOMSub]  WITH CHECK ADD  CONSTRAINT [FK_UOMSub_UOM] FOREIGN KEY([UOMId])
REFERENCES [INV].[UOM] ([UOMId])
GO
ALTER TABLE [INV].[UOMSub] CHECK CONSTRAINT [FK_UOMSub_UOM]
GO
ALTER TABLE [MEDIA].[FileManager]  WITH CHECK ADD  CONSTRAINT [FK_FileManager_Content] FOREIGN KEY([ContentId])
REFERENCES [WEBCMS].[Content] ([Id])
GO
ALTER TABLE [MEDIA].[FileManager] CHECK CONSTRAINT [FK_FileManager_Content]
GO
ALTER TABLE [Setup].[AccountingPreferences]  WITH CHECK ADD  CONSTRAINT [FK_AccountingPreferences_Branch] FOREIGN KEY([BranchId])
REFERENCES [Business].[Branches] ([BranchId])
GO
ALTER TABLE [Setup].[AccountingPreferences] CHECK CONSTRAINT [FK_AccountingPreferences_Branch]
GO
ALTER TABLE [Setup].[SystemPreferences]  WITH CHECK ADD  CONSTRAINT [FK_SystemPreferences_Branch] FOREIGN KEY([BranchId])
REFERENCES [Business].[Branches] ([BranchId])
GO
ALTER TABLE [Setup].[SystemPreferences] CHECK CONSTRAINT [FK_SystemPreferences_Branch]
GO
ALTER TABLE [SYSTEM].[AssignedRoles]  WITH CHECK ADD FOREIGN KEY([LoginId])
REFERENCES [HRM].[LoginUsers] ([Id])
GO
ALTER TABLE [SYSTEM].[AssignedRoles]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [SYSTEM].[Roles] ([Id])
GO
ALTER TABLE [SYSTEM].[ErpPermissions]  WITH CHECK ADD FOREIGN KEY([UrlMenuId])
REFERENCES [SYSTEM].[UrlMenu] ([UrlMenuId])
GO
ALTER TABLE [SYSTEM].[ErpPermissions]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [HRM].[LoginUsers] ([Id])
GO
ALTER TABLE [SYSTEM].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_NotificationTypes] FOREIGN KEY([NotificationTypeId])
REFERENCES [SYSTEM].[NotificationTypes] ([NotificationTypeId])
GO
ALTER TABLE [SYSTEM].[Notifications] CHECK CONSTRAINT [FK_Notifications_NotificationTypes]
GO
ALTER TABLE [SYSTEM].[WebsiteData]  WITH CHECK ADD FOREIGN KEY([WebsiteId])
REFERENCES [SYSTEM].[Website] ([WebsiteId])
GO
ALTER TABLE [WEBCMS].[CmsContentSharedCategory]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [WEBCMS].[ContentCategory] ([Id])
GO
ALTER TABLE [WEBCMS].[CmsContentSharedCategory]  WITH CHECK ADD FOREIGN KEY([ContentId])
REFERENCES [WEBCMS].[Content] ([Id])
GO
ALTER TABLE [WEBCMS].[CmsEmail]  WITH CHECK ADD FOREIGN KEY([WebsiteId])
REFERENCES [SYSTEM].[Website] ([WebsiteId])
GO
ALTER TABLE [WEBCMS].[CMSEmailSent]  WITH CHECK ADD FOREIGN KEY([EmailId])
REFERENCES [WEBCMS].[CmsEmail] ([EmailId])
GO
ALTER TABLE [WEBCMS].[CMSEmailSent]  WITH CHECK ADD FOREIGN KEY([EmailId])
REFERENCES [HRM].[LoginUsers] ([Id])
GO
ALTER TABLE [WEBCMS].[Comments]  WITH CHECK ADD FOREIGN KEY([ReviewId])
REFERENCES [WEBCMS].[Reviews] ([ReviewId])
GO
ALTER TABLE [WEBCMS].[Content]  WITH CHECK ADD FOREIGN KEY([ContentTypeId])
REFERENCES [WEBCMS].[ContentType] ([Id])
GO
ALTER TABLE [WEBCMS].[Content]  WITH CHECK ADD FOREIGN KEY([LoginUserId])
REFERENCES [HRM].[LoginUsers] ([Id])
GO
ALTER TABLE [WEBCMS].[Content]  WITH CHECK ADD FOREIGN KEY([WebSiteId])
REFERENCES [SYSTEM].[Website] ([WebsiteId])
GO
ALTER TABLE [WEBCMS].[ContentCategory]  WITH CHECK ADD  CONSTRAINT [FK_ContentCategory_ContentType] FOREIGN KEY([TypeId])
REFERENCES [WEBCMS].[ContentType] ([Id])
GO
ALTER TABLE [WEBCMS].[ContentCategory] CHECK CONSTRAINT [FK_ContentCategory_ContentType]
GO
ALTER TABLE [WEBCMS].[LinkedContentItems]  WITH CHECK ADD FOREIGN KEY([ContentId])
REFERENCES [WEBCMS].[Content] ([Id])
GO
ALTER TABLE [WEBCMS].[LinkedContentItems]  WITH CHECK ADD FOREIGN KEY([LinkedContentId])
REFERENCES [WEBCMS].[Content] ([Id])
GO
ALTER TABLE [WEBCMS].[Reviews]  WITH CHECK ADD FOREIGN KEY([ContentId])
REFERENCES [WEBCMS].[Content] ([Id])
GO
ALTER TABLE [WEBCMS].[Reviews]  WITH CHECK ADD FOREIGN KEY([LoginUserId])
REFERENCES [HRM].[LoginUsers] ([Id])
GO
