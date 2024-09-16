using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuiderTestTask.Data.Entities;

[Table("establishments")]
[Index("Address", Name = "address_idx", IsUnique = true)]
[Index("CategoryId", Name = "category_idx")]
public partial class Establishment : IEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(120)]
    public string Name { get; set; } = null!;

    [Column("address")]
    [StringLength(400)]
    public string Address { get; set; } = null!;
    
    [Column("description")]
    [StringLength(3000)]
    public string? Description { get; set; }

    [Column("categoryId")]
    public long CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Establishments")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("EstablishmentId")]
    [InverseProperty("Establishments")]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
