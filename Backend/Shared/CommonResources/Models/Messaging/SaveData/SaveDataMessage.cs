namespace CommonResources.Models.Messaging.SaveData;

public record SaveDataMessage<T>(
    SaveType SaveType,
    T Data);