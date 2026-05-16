using NetCord.Gateway;
using NetCord.Hosting.Gateway;

namespace Momoka.Bot.Handlers;

public class MessageCreate() : IMessageCreateGatewayHandler
{
    public ValueTask HandleAsync(Message message)
    {
        Console.WriteLine("{message.Content}");

        return default;
    }
}