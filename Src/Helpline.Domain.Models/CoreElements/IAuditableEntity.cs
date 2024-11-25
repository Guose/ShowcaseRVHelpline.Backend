namespace Helpline.Domain.Models.CoreElements
{
    public interface IAuditableEntity
    {
        public bool IsActive { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
