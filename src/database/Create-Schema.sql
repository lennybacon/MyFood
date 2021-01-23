USE [MyFood];
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Food' and xtype='U')
  BEGIN
	CREATE TABLE dbo.Food
	(
	  Id uniqueidentifier ROWGUIDCOL NOT NULL CONSTRAINT [ncu_FoodById] DEFAULT newsequentialid(),
	  Created datetime2(3) NOT NULL DEFAULT (sysutcdatetime),
	  CreatedBy varchar(312) NOT NULL DEFAULT SYSTEM_USER,
	  Modified datetime2(3) NOT NULL DEFAULT (sysutcdatetime()),
	  ModifiedBy varchar(312) NOT NULL DEFAULT SYSTEM_USER,
	  Name nvarchar(128) NOT NULL,
	  Carbohydrate decimal(7, 2) NULL,
	  Protein decimal(7, 2) NULL,
	  Fat decimal(7, 2) NULL,
	  Fiber decimal(7, 2) NULL,
	  Sodium decimal(7, 2) NULL,
	  Sugar decimal(7, 2) NULL,
	  Cholesterol decimal(7, 2) NULL,
	  SaturatedFat decimal(7, 2) NULL,
	  UnsaturatedFat decimal(7, 2) NULL,
	  TransFat decimal(7, 2) NULL,
	  ServingSizeUnit nvarchar(50) NOT NULL DEFAULT 'g',
	  ServingSizeValue decimal(7, 2) NOT NULL DEFAULT 1
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