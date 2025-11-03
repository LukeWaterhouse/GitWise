using DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Tests._01_Tenant;
using Xunit;

namespace DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Common.Collections;

[CollectionDefinition("Tenant Collection")]
public class UserRegistrationCollection : ICollectionFixture<TenantFixture>
{
}