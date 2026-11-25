using Microsoft.Data.SqlClient;
using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Infrastructure;

namespace HospitalManagementSystem.Data;

/// <summary>Converts SQL errors into friendly application exceptions.</summary>
public static class SqlErrorMapper
{
    public static AppException Map(SqlException exception, string deleteMessage = null)
    {
        Logger.Error("SQL operation failed.", exception);
        if (exception.Number == 547)
            return new RecordInUseException(deleteMessage ?? "This record is used by other records and cannot be deleted.", exception);
        if (exception.Number is 2601 or 2627)
            return new DuplicateRecordException(innerException: exception);
        if (exception.Number is -1 or 2 or 40 or 53 or 4060 or 10060 or 18456)
            return new DatabaseConnectionException(exception);
        return new DatabaseException(exception);
    }
}
