using NetCord.Services.ApplicationCommands;

namespace Momoka.Bot.Commands;

public class TestCommands : ApplicationCommandModule<ApplicationCommandContext>
{
    [SlashCommand("say", "Say something")]
    public static string Say(
        [SlashCommandParameter(Name = "message", Description = "What you want the bot to say")]
        string message
    )
    {
        return message;
    }
}