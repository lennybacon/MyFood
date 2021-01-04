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
	  Carbohydrate int NOT NULL DEFAULT 0,
	  Protein int NOT NULL DEFAULT 0,
	  Fat int NOT NULL DEFAULT 0,
	  Fiber int NOT NULL DEFAULT 0,
	  Sodium int NOT NULL DEFAULT 0,
	  Sugar int NOT NULL DEFAULT 0,
	  Cholesterol int NOT NULL DEFAULT 0,
	  SaturatedFat int NOT NULL DEFAULT 0,
	  UnsaturatedFat int NOT NULL DEFAULT 0,
	  transFatT int NOT NULL DEFAULT 0,
	  ServingSizeUnit nvarchar(50) NOT NULL DEFAULT 0,
	  ServingSizeValue decimal(1) NOT NULL DEFAULT 0 
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