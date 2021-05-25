USE master
GO

DROP DATABASE IF EXISTS Nokiu
GO
CREATE DATABASE Nokiu
GO 

USE Nokiu
GO

	CREATE TABLE "Person" (
		Id                   int                 identity,
		FirstName            nvarchar(80)        not null,
		LastName             nvarchar(250)       not null,
		UserName			 nvarchar(150)		 not null,
		Password			 nvarchar(40)		 not null, 
		Email				 nvarchar(150)		 not null, 
		Phone				 nvarchar(50)		 not null, 
		DocNumber			 nvarchar(30)        unique,
		DateLogin			 datetime			 default getdate(),
		Photo				 nvarchar(250)		 , 
		AddressId			 int                 ,
		DocTypeId			 int                 ,
		RoleId				 int				 
   
	   CONSTRAINT PK_PERSON PRIMARY KEY (Id)
	)
	GO

	CREATE INDEX IndexPersonName on Person (
		LastName ASC,
		FirstName ASC
	)
	GO

	CREATE TABLE "Owner" (
	   Id		int identity,
	   PersonId int not null
  
	  CONSTRAINT PK_OWNER PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Employee" (
	   Id		 int identity,
	   PersonId  int not null,
	   CompanyId int not null
  
	  CONSTRAINT PK_EMPLOYEE PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Customer" (
	   Id		int identity,
	   PersonId int not null
  
	  CONSTRAINT PK_CUSTOMER PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "DocType" (
	   Id	int			 identity,
	   Name nvarchar(80) not null					
   
	   CONSTRAINT PK_DOC_TYPE	PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Address" (
	   Id			int				identity,
	   StreetNumber	nvarchar(50)	not null,
	   StreetName	nvarchar(50)	not null,
	   Locality		nvarchar(50)	not null,
	   Town			nvarchar(50)	not null,
	   Country		nvarchar(50)	not null,
	   PostCode		nvarchar(50)	,
	   Latitude		nvarchar(50)	,
	   Longitude	nvarchar(50)	
  
	  CONSTRAINT PK_ADDRESS PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Company" (
	   Id		 int		  identity,
	   Name		 nvarchar(50) not null,
	   DocNumber nvarchar(50) not null,
	   DocTypeId int		  not null,
	   AddressId  int		  not null,
	   PersonId  int		  not null
  
	  CONSTRAINT PK_COMPANY PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Order" (
	   Id		   int			identity,
	   DateIssued  datetime	    default getdate(),
	   Total	   float		not null,
	   Description nvarchar(250)

	  CONSTRAINT PK_ORDER				PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Appointment" (
	   Id			int		 identity,
	   Date			datetime not null,
	   CustomerId	int		 not null,
	   ServiceId	int		 not null,
	   OrderId		int		 not null
  
	  CONSTRAINT PK_APPOINTMENT PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Business" (
	   Id			int			 identity,
	   DateReserva	nvarchar(50) not null,
	   RazonSocial	nvarchar(50) not null,
	   Cuit			nvarchar(50) not null,
	   CompanyId	int			 not null,
	   AddressId		int			 not null
	  
	  CONSTRAINT PK_BUSINESS PRIMARY KEY (Id)
	)
	GO
	
	CREATE TABLE "Contact" (
	   Id			int			 identity,
	   Email		nvarchar(80) not null,
	   Phone		nvarchar(50) not null,
	   BusinessId	int			 not null
  
	  CONSTRAINT PK_CONTACT PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Service" (
	   Id			int			 identity,
	   Name			nvarchar(50) not null,
	   Description	nvarchar(250) not null,
	   BusinessId	int			 not null
  
	  CONSTRAINT PK_SERVICE PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Product" (
	   Id			int			  identity,
	   Name			nvarchar(50)  not null,
	   Description	nvarchar(250) not null,
	   Price		float		  not null,
	   ServiceId	int			  not null
  
	  CONSTRAINT PK_PRODUCT PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Appointment_Product" (
	   AppointmentId int not null,
	   ProductId	 int not null
  
	  CONSTRAINT PK_APPOINTMENT_PRODUCT 
	  PRIMARY KEY (AppointmentId, ProductId)
	)
	GO

	CREATE TABLE "Service_Attribute" (
	   ServiceId	int not null,
	   AttributeId	int not null
  
	  CONSTRAINT PK_SERVICE_ATTRIBUTE 
	  PRIMARY KEY (ServiceId, AttributeId)
	)
	GO

	CREATE TABLE "Attribute" (
	   Id			int			  identity,
	   Description	nvarchar(250) not null,
	   CategoryId	int			  not null
  
	  CONSTRAINT PK_ATTRIBUTE PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Category" (
	   Id			int			  identity,
	   Description	nvarchar(250) not null,
	   ParentId		int			  
  
	  CONSTRAINT PK_CATEGORY PRIMARY KEY (Id)
	)
	GO
	
	CREATE TABLE "Role" (
	   Id   int			 identity,
	   Name nvarchar(30) not null
  
	  CONSTRAINT PK_ROLE PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Permission" (
	   Id			int			 identity,
	   Description	nvarchar(20) not null,
	   ModuleId		int not null

	   CONSTRAINT PK_PERMISSION	PRIMARY KEY (Id)
	)
	GO

	CREATE TABLE "Role_Permission" (
	   RoleId		int,                
	   PermissionId int

	   CONSTRAINT PK_ROLE_PERMISSION 
	   PRIMARY KEY (RoleId, PermissionId)
	)
	GO

	CREATE TABLE "Module" (
	   Id	int			 identity,
	   Name nvarchar(40) not null					
   
	   CONSTRAINT PK_MODULE	PRIMARY KEY (Id)
	)
	GO

	--ALTER TABLE "Person"
	--   ADD CONSTRAINT FK_PERSON_REFERENCE_ROLE 
	--	FOREIGN KEY (RoleId)
	--	REFERENCES Role (Id)
	--GO
	--ALTER TABLE "Person"
	--   ADD CONSTRAINT FK_PERSON_REFERENCE_DOC_TYPE 
	--	FOREIGN KEY (DocTypeId)
	--	REFERENCES DocType (Id)
	--GO
	--ALTER TABLE "Person"
	--   ADD CONSTRAINT FK_PERSON_REFERENCE_ADDRESS 
	--	FOREIGN KEY (AddressId)
	--	REFERENCES Address (Id)
	--GO

	ALTER TABLE "Owner"
	   ADD CONSTRAINT FK_OWNER_REFERENCE_PERSON 
		FOREIGN KEY (PersonId)
		REFERENCES "Person" (Id)
	GO

	ALTER TABLE "Employee"
	   ADD CONSTRAINT FK_EMPLOYEE_REFERENCE_PERSON 
		FOREIGN KEY (PersonId)
		REFERENCES Person (Id)
	GO

	ALTER TABLE "Customer"
	   ADD CONSTRAINT FK_CUSTOMER_REFERENCE_PERSON 
		FOREIGN KEY (PersonId)
		REFERENCES Person (Id)
	GO

	ALTER TABLE "Company"
	   ADD CONSTRAINT FK_COMPANY_REFERENCE_PERSON 
		FOREIGN KEY (PersonId)
		REFERENCES Person (Id)	
	GO
	ALTER TABLE "Company"
	   ADD CONSTRAINT FK_COMPANY_REFERENCE_DOC_TYPE 
		FOREIGN KEY (DocTypeId)
		REFERENCES DocType (Id)
	GO
	ALTER TABLE "Company"
	   ADD CONSTRAINT FK_COMPANY_REFERENCE_ADDRESS 
		FOREIGN KEY (AddressId)
		REFERENCES Address (Id)
	GO

	ALTER TABLE "Business"
	   ADD CONSTRAINT FK_BUSINES_REFERENCE_COMPANY 
		FOREIGN KEY (CompanyId)
		REFERENCES Company (Id)
	GO
	ALTER TABLE "Business"
	   ADD CONSTRAINT FK_BUSINESS_REFERENCE_ADDRESS 
		FOREIGN KEY (AddressId)
		REFERENCES Address (Id)
	GO

	ALTER TABLE "Service"
	   ADD CONSTRAINT FK_SERVICE_REFERENCE_BUSINESS 
		FOREIGN KEY (BusinessId)
		REFERENCES Business (Id)
	GO

	ALTER TABLE "Product"
	   ADD CONSTRAINT FK_PRODUCT_REFERENCE_SERVICE 
		FOREIGN KEY (ServiceId)
		REFERENCES Service (Id)
	GO

	ALTER TABLE "Attribute"
	   ADD CONSTRAINT FK_ATTRIBUTE_REFERENCE_CATEGORY 
		FOREIGN KEY (CategoryId)
		REFERENCES Category (Id)
	GO

	ALTER TABLE "Category"
	   ADD CONSTRAINT FK_CATEGORY_REFERENCE_CATEGORY
		FOREIGN KEY (ParentId)
		REFERENCES Category (Id)
	GO

	ALTER TABLE "Appointment_Product"
	   ADD CONSTRAINT FK_APPOINTMENT_PRODUCT_REFERENCE_PRODUCT 
		FOREIGN KEY (AppointmentId)
		REFERENCES Appointment (Id)
	GO
	ALTER TABLE "Appointment_Product"
	   ADD CONSTRAINT FK_APPOINTMENT_PRODUCT_REFERENCE_APPOINTMENT 
		FOREIGN KEY (ProductId)
		REFERENCES Product (Id)	
	GO

	ALTER TABLE "Service_Attribute"
	   ADD CONSTRAINT FK_SERVICE_ATTRIBUTE_REFERENCE_SERVICE 
		FOREIGN KEY (ServiceId)
		REFERENCES Service (Id)
	GO

	ALTER TABLE "Service_Attribute"
	   ADD CONSTRAINT FK_SERVICE_ATTRIBUTE_REFERENCE_ATTRIBUTE 
		FOREIGN KEY (AttributeId)
		REFERENCES Attribute (Id)	
	GO

	ALTER TABLE "Role_Permission"
	   ADD CONSTRAINT FK_ROLE_PERMISSION_REFERENCES_ROLE 
		FOREIGN KEY (RoleId)
		REFERENCES Role (Id)	
	GO

	ALTER TABLE "Role_Permission"
	   ADD CONSTRAINT FK_ROLE_PERMISSION_REFERENCES_PERMISSION 
		FOREIGN KEY (PermissionId)
		REFERENCES Permission (Id)	
	GO

	use Nokiu
	go
	
	--SET IDENTITY_INSERT Person ON
	INSERT INTO [Person] ([FirstName],[LastName],[UserName],[Password],[Email],[Phone],[DocNumber],[AddressId], [DocTypeId], [RoleId])
	VALUES('Maria','Anders','User01','123456','email1@email.com','555444', 65625625, 1, 1, 1)

		INSERT INTO [Person] ([FirstName],[LastName],[UserName],[Password],[Email],[Phone],[DocNumber],[AddressId], [DocTypeId], [RoleId])
	VALUES('Jose','Perrez','User02','123456','email2@email.com','555444223', 6546431, 2, 2, 2)

	INSERT INTO [Person] ([FirstName],[LastName],[UserName],[Password],[Email],[Phone],[DocNumber],[AddressId], [DocTypeId], [RoleId])
	VALUES('Oscar','Ruggiero','User03','123456','email3@email.com','555444', 65625625, 3, 3, 3 )
	INSERT INTO [Person] ([FirstName],[LastName],[UserName],[Password],[Email],[Phone],[DocNumber],[AddressId], [DocTypeId], [RoleId])
	VALUES('Johana','Bulling','User04','123456','email4@email.com','555444', 65625625, 4, 4, 4)

	INSERT INTO [Person] ([FirstName],[LastName],[UserName],[Password],[Email],[Phone],[DocNumber],[AddressId], [DocTypeId], [RoleId])
	VALUES('Mara','Rodrigues','User05','123456','email5@email.com','555444', 65625625, 5, 5, 5)
		INSERT INTO [Person] ([FirstName],[LastName],[UserName],[Password],[Email],[Phone],[DocNumber],[AddressId], [DocTypeId], [RoleId])
	VALUES('Quique','Hrabina','User06','123456','email6@email.com','555444223', 6546431, 6, 6, 6)

	INSERT INTO [Person] ([FirstName],[LastName],[UserName],[Password],[Email],[Phone],[DocNumber],[AddressId], [DocTypeId], [RoleId])
	VALUES('Roberto','Pasucci','User07','123456','email7@email.com','555444', 65625625, 7, 7, 7)

	INSERT INTO [Person] ([FirstName],[LastName],[UserName],[Password],[Email],[Phone],[DocNumber],[AddressId], [DocTypeId], [RoleId])
	VALUES('Nicolas','Hoarland','User08','123456','email8@email.com','555444', 65625625, 8, 8, 8)
		INSERT INTO [Person] ([FirstName],[LastName],[UserName],[Password],[Email],[Phone],[DocNumber],[AddressId], [DocTypeId], [RoleId])
	VALUES('Maria','Anders','User09','123456','email9@email.com','555444', 65625625, 9, 9, 9)
		INSERT INTO [Person] ([FirstName],[LastName],[UserName],[Password],[Email],[Phone],[DocNumber],[AddressId], [DocTypeId], [RoleId])
		VALUES('Jose','Perrez','User10','123456','email10@email.com','555444223', 6546431, 10, 10, 10)

	

	



