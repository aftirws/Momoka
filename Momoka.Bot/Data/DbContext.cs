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

        options.UseSeeding((context, _) =>
        {
            if (!context.Set<Species>().Any())
            {
                context.Set<Species>().AddRange(
                    new Species { Name = "Red" },
                    new Species { Name = "Arctic" },
                    new Species { Name = "Fennec" }
                );

                context.SaveChanges();
            }

            if (!context.Set<Fox>().Any())
            {
                context.Set<Fox>().Add(
                    new Fox { Name = "Finnegan", SpeciesId = 1, Age = 10 }
                );

                context.SaveChanges();
            }
        });
    }

    public DbSet<Fox> Foxes { get; set; }

    public DbSet<Species> Species { get; set; }
}
