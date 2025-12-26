using ControlPlane.Application.Exceptions.Enums;

namespace ControlPlane.Application.Exceptions;

public class DuplicateRecordException(RecordType duplicateRecordType, string duplicateRecordName)
    : Exception(string.Format(DefaultMessageTemplate, duplicateRecordType, duplicateRecordName))
{
    private const string DefaultMessageTemplate = "{0} with value '{1}' already exists.";
}