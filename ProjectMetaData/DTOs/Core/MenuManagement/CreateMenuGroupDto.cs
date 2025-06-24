namespace Horeca.DTOs.Core.MenuManagement;

public record CreateMenuGroupDto(string Name, Guid MenuId, Guid? ParentId);

public record UpdateMenuGroupDto(Guid Id, string Name, Guid MenuId, Guid? ParentId, List<MenuItemDto> Items);