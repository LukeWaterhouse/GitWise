using CommonResources.Models.Messaging.SaveData.SaveTypes;
using UiService.Domain.Interfaces.External;
using UiService.Domain.Models;
using UiService.Infrastructure.DatabaseService.MessageQueue.Senders;

namespace UiService.Infrastructure.DatabaseService.Services;

public class DatabaseService(ServiceBusSenderService serviceBusSenderService) : IExternalDatabaseService
{
    public async Task CreateUserAsync(string email, string externalId, string tenantId, Role role)
    {
        var user = new User(email, externalId, tenantId, (CommonResources.Models.Messaging.SaveData.SaveTypes.Enums.Role)role);
        await serviceBusSenderService.SendMessageAsync(user);
    }
}