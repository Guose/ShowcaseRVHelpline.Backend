using Helpline.DataAccess.Models.CoreElements;

namespace Helpline.Contracts.v1.Requests
{
    public class EmployeeRequest : AggregateRoot, IAuditableEntity
    {
        private readonly List<string>? attachments = [];

        private EmployeeRequest(Guid userId, int id, string company, string jobTitle) : base(userId, id)
        {
            Company = company;
            JobTitle = jobTitle;
            CreatedOn = DateTime.Now;
        }
        private EmployeeRequest(Guid userId, int id, bool isActive, List<string> attachments, DateTime? modifiedOn = null) : base(userId, id)
        {
            ModifiedOn = modifiedOn;
            IsActive = isActive;
            this.attachments = attachments;
        }

        public string? Company { get; private set; }
        public string? JobTitle { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IReadOnlyCollection<string>? Attachments => attachments;

        public static EmployeeRequest Create(
            Guid userId,
            int id,
            string company,
            string jobTitle)
        {
            return new EmployeeRequest(
                userId,
                id,
                company,
                jobTitle);
        }

        public static EmployeeRequest Update(
            Guid userId,
            int id,
            bool isActive,
            List<string> attachments,
            DateTime modifiedOn)
        {
            return new EmployeeRequest(
                userId,
                id,
                isActive,
                attachments,
                modifiedOn);
        }
    }
}
