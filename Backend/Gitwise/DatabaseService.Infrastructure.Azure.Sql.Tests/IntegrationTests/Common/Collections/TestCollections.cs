using DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Tests._01_Tenant;
using DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Tests._02_User;
using Xunit;

namespace DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Common.Collections;

[CollectionDefinition("Tenant Collection")]
public class TenantCollection : ICollectionFixture<TenantFixture>
{
}

[CollectionDefinition("User Collection")]
public class UserCollection : ICollectionFixture<UserFixture>
{
}