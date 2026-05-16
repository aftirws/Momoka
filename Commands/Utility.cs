using NetCord;
using NetCord.Rest;
using NetCord.Services.ApplicationCommands;

namespace Momoka.Bot.Commands;

public class Utility : ApplicationCommandModule<ApplicationCommandContext>
{
    [SlashCommand("ping", "Replies with Pong!")]
    public static string Ping() => "Pong!";

    [UserCommand("ID")]
    public static string Id(User user) => user.Id.ToString();

    [MessageCommand("Timestamp")]
    public static string Timestamp(RestMessage message) => message.CreatedAt.ToString();
}