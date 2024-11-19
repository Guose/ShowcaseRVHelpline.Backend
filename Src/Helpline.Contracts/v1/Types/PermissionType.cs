namespace Helpline.Contracts.v1.Types
{
    public enum PermissionType : byte
    {
        None = 0,
        Admin = 1,
        Limited = 2,
        Guest = 3,
        Contractor = 4,
    }
}
