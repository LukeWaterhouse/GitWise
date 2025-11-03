using DatabaseService.Infrastructure.Azure.Sql.Exceptions.Enums;

namespace DatabaseService.Infrastructure.Azure.Sql.Exceptions;

public class RecordNotFoundException(RecordType recordType, string recordName)
    : Exception(string.Format(DefaultMessageTemplate, recordType, recordName))
{
    private const string DefaultMessageTemplate = "{0} with value '{1}' not found.";
}