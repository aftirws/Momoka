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
    .AddDbContext<FoxesContext>();

var host = builder.Build();

host.AddModules(typeof(Program).Assembly);

var scope = host.Services.CreateScope();
var database = scope.ServiceProvider.GetRequiredService<FoxesContext>();
database.Database.Migrate();

await host.RunAsync();
