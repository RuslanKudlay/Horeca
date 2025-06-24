namespace Horeca.DTOs.Core.MenuManagement;

public record MenuItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}