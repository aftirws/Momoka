using NetCord.Services.ApplicationCommands;

using Momoka.Bot.Models;
using Momoka.Bot.Data;
using Microsoft.EntityFrameworkCore;
using NetCord.Rest;

namespace Momoka.Bot.Commands;

public class DbCommands(FoxesContext dbContext)
    : ApplicationCommandModule<ApplicationCommandContext>
{
    [SlashCommand("get", "Returns fox records")]
    public async Task<InteractionMessageProperties> GetAllFoxes(
        [SlashCommandParameter(Name = "id", Description = "Id of fox to fetch")]
        int? id = null
    )
    {
        List<Fox> foxes;
        IQueryable<Fox> foxesQuery = dbContext.Foxes.AsNoTracking();

        if (id is not null)
        {
            foxesQuery = foxesQuery.Where(fox => fox.Id == id);
        }

        foxes = await foxesQuery.ToListAsync();

        return new InteractionMessageProperties().WithEmbeds([
            new EmbedProperties {
                Title = "Database Response",
                Description = string.Join("", foxes.Select(fox => fox.Name))
            }
        ]);
    }

    [SlashCommand("get_species", "Returns species records")]
    public async Task<InteractionMessageProperties> GetAllSpecies()
    {
        List<Species> species = await dbContext.Species.AsNoTracking().ToListAsync();

        return new InteractionMessageProperties().WithEmbeds([
            new EmbedProperties {
                Title = "Database Response",
                Description = string.Join("", species.Select(species => species.Name))
            }
        ]);
    }
}
