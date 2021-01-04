USE [MyFood];
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Food' and xtype='U')
  BEGIN
	CREATE TABLE dbo.Food
	(
	  Id uniqueidentifier ROWGUIDCOL NOT NULL CONSTRAINT [ncu_FoodById]DEFAULT newsequentialid(),
	  Created datetime2(3) NOT NULL DEFAULT (sysutcdatetime()),
	  CreatedBy varchar(312) NOT NULL DEFAULT SYSTEM_USER,
	  Modified datetime2(3) NOT NULL DEFAULT (sysutcdatetime()),
	  ModifiedBy varchar(312) NOT NULL DEFAULT SYSTEM_USER,
	  Name nvarchar(128) NOT NULL,
	  Carbohydrate decimal(2) NOT NULL DEFAULT 0,
	  Protein decimal(2) NOT NULL DEFAULT 0,
	  Fat decimal(2) NOT NULL DEFAULT 0, --TODO: Calculate this field from other fat columns?
	  Fiber decimal(2) NOT NULL DEFAULT 0,
	  Sodium decimal(2) NOT NULL DEFAULT 0,
	  Sugar decimal(2) NOT NULL DEFAULT 0,
	  Cholesterol decimal(2) NOT NULL DEFAULT 0,
	  SaturatedFat decimal(2) NOT NULL DEFAULT 0,
	  UnsaturatedFat decimal(2) NOT NULL DEFAULT 0,
	  TransFat decimal(2) NOT NULL DEFAULT 0,
	  ServingSizeUnit nvarchar(50) NOT NULL DEFAULT 0,
	  ServingSizeValue decimal(2) NOT NULL DEFAULT 0 
	  CONSTRAINT  [PKC_dbo_FoodBy_Id]
      PRIMARY KEY CLUSTERED
      (
        [Id]
      )
      WITH
      (
        IGNORE_DUP_KEY = OFF
      )
      ON [PRIMARY]
	)
  END
  GO