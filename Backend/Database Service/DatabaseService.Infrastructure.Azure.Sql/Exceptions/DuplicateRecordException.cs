using DatabaseService.Infrastructure.Azure.Sql.Exceptions.Enums;

namespace DatabaseService.Infrastructure.Azure.Sql.Exceptions;

public class DuplicateRecordException(RecordType duplicateRecordType, string duplicateRecordName)
    : Exception(string.Format(DefaultMessageTemplate, duplicateRecordType, duplicateRecordName))
{
    private const string DefaultMessageTemplate = "{0} with value '{1}' already exists.";
}