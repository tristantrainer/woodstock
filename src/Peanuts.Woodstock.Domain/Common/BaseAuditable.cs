namespace Peanuts.Woodstock.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    // public DateTimeOffset LastModified { get; set; }

    // public Guid? LastModifiedBy { get; set; }
}