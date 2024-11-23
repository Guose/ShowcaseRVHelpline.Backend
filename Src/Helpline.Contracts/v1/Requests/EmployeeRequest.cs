namespace Helpline.Contracts.v1.Requests
{
    public class EmployeeRequest
    {
        private readonly List<string>? attachments = [];

        private EmployeeRequest(Guid userId, string company, string jobTitle)
        {
            UserId = userId;
            Company = company;
            JobTitle = jobTitle;
            CreatedOn = DateTime.UtcNow;
        }
        private EmployeeRequest(int id, bool isActive, List<string> attachments, DateTime? modifiedOn = null)
        {
            ModifiedOn = modifiedOn;
            IsActive = isActive;
            this.attachments = attachments;
        }

        public Guid UserId { get; set; }
        public string? Company { get; private set; }
        public string? JobTitle { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IReadOnlyCollection<string>? Attachments => attachments;

        public static EmployeeRequest Create(Guid userId, string company, string jobTitle)
        {
            return new EmployeeRequest(userId, company, jobTitle);
        }

        public static EmployeeRequest Update(
            int id,
            bool isActive,
            List<string> attachments,
            DateTime modifiedOn)
        {
            return new EmployeeRequest(
                id,
                isActive,
                attachments,
                modifiedOn);
        }
    }
}
