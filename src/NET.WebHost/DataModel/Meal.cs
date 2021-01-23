using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lennybacon.MyFood.DataModel
{
  [Table("Meal")]
  public class Meal
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

   

  }
}