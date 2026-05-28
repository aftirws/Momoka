using Microsoft.Extensions.Logging;

using NetCord.Gateway;
using NetCord.Hosting.Gateway;

namespace Momoka.Bot.Handlers;

public class MessageCreateHandler(ILogger<MessageCreateHandler> logger) : IMessageCreateGatewayHandler
{
    public ValueTask HandleAsync(Message message)
    {
        logger.LogInformation("[{}]: {}", message.Author.Username, message.Content);
        return default;
    }
}