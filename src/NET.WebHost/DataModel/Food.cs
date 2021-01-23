using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lennybacon.MyFood.DataModel
{
  [Table("Food")]
  public class Food
  {
    [Key]
    [Required]
    [Column("Id", TypeName = "uniqueidenifier")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [Column("Created", TypeName = "datetime2(3)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime Created { get; set; }

    [Required]
    [Column("CreatedBy", TypeName = "varchar(312)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string CreatedBy { get; set; }

    [Required]
    [Column("Modified", TypeName = "datetime2(3)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime Modified { get; set; }

    [Required]
    [Column("ModifiedBy", TypeName = "varchar(312)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string ModifiedBy { get; set; }

    [Required]
    [Column("Name", TypeName = "nvarchar(128)")]
    public string Name { get; set; }

    [Column("Carbohydrate", TypeName = "decimal(7, 2)")]
    public decimal? Carbohydrate { get; set; }

    [Column("Protein", TypeName = "decimal(7, 2)")]
    public decimal? Protein { get; set; }

    [Column("Fat", TypeName = "decimal(7, 2)")]
    public decimal? Fat { get; set; }

    [Column("Fiber", TypeName = "decimal(7, 2)")]
    public decimal? Fiber { get; set; }

    [Column("Sodium", TypeName = "decimal(7, 2)")]
    public decimal? Sodium { get; set; }

    [Column("Sugar", TypeName = "decimal(7, 2)")]
    public decimal? Sugar { get; set; }

    [Column("Cholesterol", TypeName = "decimal(7, 2)")]
    public decimal? Cholesterol { get; set; }

    [Column("SaturatedFat", TypeName = "decimal(7, 2)")]
    public decimal? SaturatedFat { get; set; }

    [Column("UnsaturatedFat", TypeName = "decimal(7, 2)")]
    public decimal? UnsaturatedFat { get; set; }

    [Column("TransFat", TypeName = "decimal(7, 2)")]
    public decimal? TransFat { get; set; }

    [DefaultValue("g.")]
    [Required]
    [Column("ServingSizeUnit", TypeName = "nvarchar(50)")]
    public string ServingSizeUnit { get; set; }

    [DefaultValue("1")]
    [Column("ServingSizeValue", TypeName = "decimal(7, 2)")]
    public decimal ServingSizeValue { get; set; }

  }
}