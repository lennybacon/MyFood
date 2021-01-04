 IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'MyFood')
  BEGIN
    CREATE DATABASE [MyFood];
  END
GO