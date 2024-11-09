namespace Helpline.Common.Essentials
{
    public interface IAuditableEntity
    {
        DateTime CreatedOnUtc { get; set; }
        DateTime? LastModifiedOnUtc { get; set; }
    }
}
