using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Momoka.Bot.Models;

[Table("fox")]
public class Fox
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [ForeignKey("species")]
    [Column("species_id")]
    public int SpeciesId { get; set ;}
    [Column("species")]
    public Species? Species { get; set; }

    [Column("age")]
    public int Age { get; set; }
}