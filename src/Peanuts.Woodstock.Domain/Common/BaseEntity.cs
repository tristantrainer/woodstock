namespace Peanuts.Woodstock.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; init; }
    public Guid PublicId { get; init; }
}