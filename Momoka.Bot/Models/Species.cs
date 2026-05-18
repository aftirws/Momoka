using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Momoka.Bot.Models;

[Table("species")]
public class Species
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("species_id")]
    public int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }
}
