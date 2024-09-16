using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuiderTestTask.Data.Entities;

[Table("categories")]
public partial class Category : IEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [StringLength(2000)]
    public string? Description { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Establishment> Establishments { get; set; } = new List<Establishment>();
}
