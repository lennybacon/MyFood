using System;

namespace lennybacon.MyFood.DataModel
{
  public class Food
  {
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public string CreatedBy { get; set; }
    public DateTime Modified { get; set; }
    public string ModifiedBy { get; set; }
    public string Name { get; set; }
    public decimal Carbohydrate { get; set; }
    public decimal Protein { get; set; }
    public decimal Fat { get; set; }
    public decimal Fiber { get; set; }
    public decimal Sodium { get; set; }
    public decimal Sugar { get; set; }
    public decimal Cholesterol { get; set; }
    public decimal SaturatedFat { get; set; }
    public decimal UnsaturatedFat { get; set; }
    public decimal TransFat { get; set; }
    public string ServingSizeUnit { get; set; }
    public decimal ServingSizeValue { get; set; }
  }
}