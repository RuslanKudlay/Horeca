namespace Horeca.DTOs.Core.MenuManagement;

public record MenuGroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MenuItemDto> Items { get; set; }
    
    public Guid? ParentId { get; set; }
    public MenuGroupDto? Parent { get; set; }
    
    public Guid MenuId { get; set; }
    public MenuDto Menu { get; set; }
}