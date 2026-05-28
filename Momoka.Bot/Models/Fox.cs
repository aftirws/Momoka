using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Momoka.Bot.Models;

[Table("fox")]
public class Fox
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required string Name { get; set; }

    public int SpeciesId { get; set ;}

    [ForeignKey("SpeciesId")]
    public Species? Species { get; set; }

    public int Age { get; set; }
}
