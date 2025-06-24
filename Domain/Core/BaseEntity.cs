namespace Domain.Core;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime DateCreated { get; protected set; } = DateTime.Now;
    public DateTime DateUpdated { get; protected set; }
    
    public void SetUpdated() => DateUpdated = DateTime.Now;
}