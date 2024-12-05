namespace Helpline.Contracts.v1.Requests
{
    public class EmployeeRequest
    {
        private readonly List<string>? attachments = [];

        private EmployeeRequest(Guid userId, string company, string jobTitle, DateTime createdOn)
        {
            UserId = userId;
            Company = company;
            JobTitle = jobTitle;
            CreatedOn = createdOn;
        }
        private EmployeeRequest(bool isActive, string referralCode, DateTime? modifiedOn = null)
        {
            ModifiedOn = modifiedOn;
            IsActive = isActive;
            ReferralCode = referralCode;
        }

        public Guid UserId { get; set; }
        public string? Company { get; private set; }
        public string? JobTitle { get; private set; }
        public string? ReferralCode { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IReadOnlyCollection<string>? Attachments => attachments;

        public static EmployeeRequest Create(Guid userId, string company, string jobTitle, DateTime createdOn)
        {
            return new EmployeeRequest(userId, company, jobTitle, createdOn);
        }

        public static EmployeeRequest Update(
            bool isActive,
            string referralCode,
            DateTime modifiedOn)
        {
            return new EmployeeRequest(
                isActive,
                referralCode,
                modifiedOn);
        }
    }
}
