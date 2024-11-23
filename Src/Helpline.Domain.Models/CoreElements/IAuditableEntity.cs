namespace Helpline.Domain.Models.CoreElements
{
    public interface IAuditableEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
