using System.Diagnostics.CodeAnalysis;
using OpenAI.Chat;
using SummaryEngine.Infrastructure.Azure.AzureAi.Interfaces;

namespace SummaryEngine.Infrastructure.Azure.AzureAi.Clients;

[ExcludeFromCodeCoverage(Justification = "Dependency has no way to be mocked, so this class is not unit testable. Keep logic minimal.")]
public class AzureAiClient(ChatClient azureAiChatClient) : IAzureAiClient
{
    public async Task<string> GetMessageResponseAsync(string message, CancellationToken ct)
    {
        List<ChatMessage> messages =
        [
            new UserChatMessage(message)
        ];

        var response = await azureAiChatClient.CompleteChatAsync(messages, new(), ct);
        
        return response.Value.Content[0].Text;
    }
}