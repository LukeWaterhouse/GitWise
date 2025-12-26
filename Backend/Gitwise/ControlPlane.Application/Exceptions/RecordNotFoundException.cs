using ControlPlane.Application.Exceptions.Enums;

namespace ControlPlane.Application.Exceptions;

public class RecordNotFoundException(RecordType recordType, string identifier)
    : Exception(string.Format(DefaultMessageTemplate, recordType, identifier))
{
    private const string DefaultMessageTemplate = "{0} with value '{1}' not found.";
}