# GitWise Service

---

## Local Development Setup

1. See `appsettings.Development.json` for local development configuration.

---

## Development Practices

This section outlines the agreed practices, principles, and conventions for this project.  
It serves as a guide for all contributors to maintain consistency, quality and extendibility.

- Remember to keep **SOLID** principles in mind.
- Leave code cleaner than you found it :)

### 1. Domain-Driven Design (DDD) & Onion Architecture

We follow **Domain-Driven Design** principles to ensure our codebase reflects the business domain.

#### **Api Layer**
- **THE API LAYER SHOULD ONLY DEPEND ON APPLICATION/DOMAIN LAYER.**
- Handles API endpoints.
- Defines DTO models for data transfer.
- Maps DTOs to domain models and vice versa.
- Should have minimal logic, delegating to the application layer.

#### **Application Layer**
- **THE APPLICATION LAYER SHOULD ONLY DEPEND ON DOMAIN LAYER.**
- Contains application services/interfaces that orchestrate domain processes.
- Should not contain business logic, only coordinate it.
- Coordinates between the API layer and the domain layer.

#### **Domain Layer**
- **THE DOMAIN LAYER SHOULD NEVER DEPEND ON OTHER PROJECTS.**
- Contains core business logic services and models.
- Interface definitions that only deal with domain entities.
- Place domain/externally implemented interface definitions in the corresponding folders.
- No infrastructure or external frameworks dependencies.
- Ensures ease of testing and modularity, the domain layer is always protected from external changes.

#### **Infrastructure Layer**
- Includes implementations for external services, adapters, databases, and other infrastructure concerns.
- Implements contracts/interfaces defined in the domain/application layer.
- Should be replaceable without impacting domain/application logic.

### 2. Unit Testing

- Ensure high code coverage with unit tests, ideally 100%.
- Ensure mocking of dependencies to isolate the unit under test.
- Use descriptive test method names following the `MethodName_Scenario_DesiredOutput` convention.

#### Example Unit Test
Follow the **Arrange-Act-Assert** (AAA) pattern:
```csharp
[Fact]
public void CalculateTotal_WhenTwoItems_ReturnsCorrectSum()
{
  // Arrange
  var service = new OrderService();
  var items = new[] { 5, 10 };

  // Act
  var total = service.CalculateTotal(items);

  // Assert
  Assert.Equal(15, total);
}
```

### 3. Formatting & Style

- Follow C# naming conventions.
- Avoid long lines.
- Use explicit access modifiers (public, private, internal etc.) for all classes and members.
- Remove unused usings.
- Keep methods short and focused; extract logic into private methods if needed.
- Avoid side effects in methods, the name should describe what it does, and it should only do that.
- Write comments only where necessary to explain why (not what) the code does. Code should be self-explanatory.
- Remember to include Cancellation Tokens in async methods.
- Async method names should end with "Async".
- Use primary constructors for dependency injection:
    ```csharp
    public class MyService(IMyDependency myDependency)
    {
    }
    ```
- Use file-scoped namespaces rather than block-scoped:
    ```csharp
    namespace MyNamespace;
    
    public class MyClass
    {
    }
    ```
---
