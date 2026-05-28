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

        string formattedResponse = "";

        foreach (Fox f in foxes)
        {
            formattedResponse += $"`{f.Id}: {f.Name}, {f.Species!.Name} fox, age {f.Age}`\n";
        }

        return BuildDbResponseFormat(formattedResponse);
    }

    [SlashCommand("get_species", "Returns species records")]
    public async Task<InteractionMessageProperties> GetAllSpecies()
    {
        List<Species> species = await dbContext.Species.AsNoTracking().ToListAsync();

        string formattedResponse = "";

        foreach (Species s in species)
        {
            formattedResponse += $"`{s.Id}: {s.Name}`\n";
        }

        return BuildDbResponseFormat(formattedResponse);
    }

    private InteractionMessageProperties BuildDbResponseFormat(string formattedResponse)
    {
        return new InteractionMessageProperties()
            .WithContent("**Database Response**")
            .WithEmbeds([
                new EmbedProperties {
                    Description = formattedResponse
                }
            ]);
    }
}
