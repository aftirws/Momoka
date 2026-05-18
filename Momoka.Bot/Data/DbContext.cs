using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Momoka.Bot.Models;

namespace Momoka.Bot.Data;

public class FoxesContext(IConfiguration configuration) : DbContext
{
    protected readonly IConfiguration Configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("Database"));
    }

    public DbSet<Fox> Foxes { get; set; }

    public DbSet<Species> Species { get; set; }
}
