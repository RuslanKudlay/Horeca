using Application.Eceptions;

namespace Domain.Core.Menu;

public class Menu : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;

    private readonly List<MenuGroup> _groups = new();
    public IReadOnlyCollection<MenuGroup> Groups => _groups;

    public Menu(string name)
    {
        Name = name;
    }

    public void CreateGroups(List<MenuGroup> groups)
    {
        _groups.AddRange(groups);
    }

    public void UpdateGroups(List<MenuGroup> groupsForUpdate)
    {
        groupsForUpdate.ForEach(group =>
        {
            var updatedGroup = Groups.FirstOrDefault(g => g.Id == group.Id);
            updatedGroup
                .Rename(group.Name)
                .ChangeMenuId(group.MenuId)
                .ChangeParent(group.ParentId)
                .SetItems(group.Items.ToList());
            updatedGroup.SetUpdated();
        });
        
    }
}