namespace Helpline.Contracts.v1.Requests
{
    public class TechnicianRequest
    {
        private TechnicianRequest(string company, string referralCode, bool isW9OnFile, string website)
        {
            Company = company;
            ReferralCode = referralCode;
            IsW9OnFile = isW9OnFile;
            Website = website;
        }

        public string? Company { get; set; }
        public string? ReferralCode { get; set; }
        public bool IsW9OnFile { get; set; }
        public string? Website { get; set; }

        public static TechnicianRequest Create(string company, string referralCode, bool isW9OnFile, string website)
        {
            return new TechnicianRequest(company, referralCode, isW9OnFile, website);
        }
    }
}
