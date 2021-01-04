﻿SELECT 
  [Id],
  [Created],
  [CreatedBy],
  [Modified],
  [ModifiedBy],
  [Name],
  [Carbohydrate],
  [Protein],
  [Fat],
  [Fiber],
  [Sodium],
  [Sugar],
  [Cholesterol],
  [SaturatedFat],
  [UnsaturatedFat],
  [TransFat],
  [ServingSizeUnit],
  [ServingSizeValue]
FROM [dbo].[Food] 
WHERE [Name] = @Name;