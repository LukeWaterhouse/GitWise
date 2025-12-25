using ControlPlane.Infrastructure.AzureSql.Exceptions.Enums;

namespace ControlPlane.Infrastructure.AzureSql.Exceptions;

public class RecordNotFoundException(RecordType recordType, string recordName)
    : Exception(string.Format(DefaultMessageTemplate, recordType, recordName))
{
    private const string DefaultMessageTemplate = "{0} with value '{1}' not found.";
}