namespace Helpline.Common.Essentials
{
    public interface IAuditableEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
