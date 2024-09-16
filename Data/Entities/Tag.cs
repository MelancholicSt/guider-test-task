using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuiderTestTask.Data.Entities;

[Table("tags")]
public partial class Tag : IEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(40)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [StringLength(600)]
    public string Description { get; set; } = null!;

    [ForeignKey("TagId")]
    [InverseProperty("Tags")]
    public virtual ICollection<Establishment> Establishments { get; set; } = new List<Establishment>();
}
