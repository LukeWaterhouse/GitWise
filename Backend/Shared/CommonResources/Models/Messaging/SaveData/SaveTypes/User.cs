using CommonResources.Models.Messaging.SaveData.SaveTypes.Enums;

namespace CommonResources.Models.Messaging.SaveData.SaveTypes;

public record User(string EmailAddress, string ExternalId, string TenantId, Role Role);