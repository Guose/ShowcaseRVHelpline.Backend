namespace Helpline.Domain.Models.Types
{
    public enum ServiceCaseCallStatusType : byte
    {
        None = 0,
        Active = 1,
        PartsOrdered = 2,
        Transferred = 3,
        Resolved = 4,
        Canceled = 5,
    }
}
