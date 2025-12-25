using ControlPlane.Infrastructure.AzureSql.Exceptions.Enums;

namespace ControlPlane.Infrastructure.AzureSql.Exceptions;

public class DuplicateRecordException(RecordType duplicateRecordType, string duplicateRecordName)
    : Exception(string.Format(DefaultMessageTemplate, duplicateRecordType, duplicateRecordName))
{
    private const string DefaultMessageTemplate = "{0} with value '{1}' already exists.";
}