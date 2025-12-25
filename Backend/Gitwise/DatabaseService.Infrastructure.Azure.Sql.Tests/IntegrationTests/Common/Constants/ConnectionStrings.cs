namespace DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Common.Constants;

public static class ConnectionStrings
{
    public static string TestDbConnectionString =>
        "Server=localhost,1433;Database=GitWise;User Id=sa;Password=Rollo!234;TrustServerCertificate=True;";
}