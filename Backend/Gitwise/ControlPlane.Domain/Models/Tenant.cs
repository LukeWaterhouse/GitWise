namespace ControlPlane.Domain.Models;

public class Tenant(Guid id, string name)
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;
}