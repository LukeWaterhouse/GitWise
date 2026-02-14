using System.Diagnostics.CodeAnalysis;
using OpenAI.Chat;
using SummaryEngine.Adapter.Github.AzureAi.Interfaces;

namespace SummaryEngine.Adapter.Github.AzureAi.Clients;

[ExcludeFromCodeCoverage(Justification = "Dependency has no way to be mocked, so this class is not unit testable. Keep logic minimal.")]
public class AzureAiClient(ChatClient azureAiChatClient) : IAzureAiClient
{
    public async Task<string> GetMessageResponseAsync(string message, CancellationToken ct)
    {
        List<ChatMessage> messages =
        [
            new UserChatMessage(message)
        ];

        var response = await azureAiChatClient.CompleteChatAsync(messages, new ChatCompletionOptions(), ct);
        
        return response.Value.Content[0].Text;
    }
}