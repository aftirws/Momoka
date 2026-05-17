using NetCord.Services.ApplicationCommands;

using Momoka.Bot.Models;
using Momoka.Bot.Data;
using Microsoft.VisualBasic;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace Momoka.Bot.Commands;

public class DbCommands
{
    public required FoxesContext dbContext;

    [SlashCommand("get", "Returns fox records")]
    public async Task<List<Fox>> GetAllFoxes(
        FoxesContext dbContext,
        [SlashCommandParameter(Name = "id", Description = "Id of fox to fetch")]
        int? id = null
    )
    {
        return await dbContext.Foxes.ToListAsync();
    }
}
