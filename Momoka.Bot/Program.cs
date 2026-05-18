using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NetCord.Gateway;
using NetCord.Hosting.Gateway;
using NetCord.Hosting.Services;
using NetCord.Hosting.Services.ApplicationCommands;

using Momoka.Bot.Data;
using Momoka.Bot.Models;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddDiscordGateway(options =>
    {
        options.Intents = GatewayIntents.GuildMessages | GatewayIntents.DirectMessages | GatewayIntents.MessageContent;
    })
    .AddGatewayHandlers(typeof(Program).Assembly)
    .AddApplicationCommands()
    .AddDbContext<FoxesContext>(
        optionsAction: options => options.UseSeeding((context, _) =>
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
        })
    );

var host = builder.Build();

host.AddModules(typeof(Program).Assembly);

var scope = host.Services.CreateScope();
var database = scope.ServiceProvider.GetRequiredService<FoxesContext>();
database.Database.Migrate();

await host.RunAsync();
