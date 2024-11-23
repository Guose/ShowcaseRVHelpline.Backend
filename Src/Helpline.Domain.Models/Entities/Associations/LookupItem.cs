namespace Helpline.Domain.Models.Entities.Associations
{
    public class LookupItem
    {
        public int IntId { get; set; }
        public Guid GuidId { get; set; }
        public string DisplayMember { get; set; } = string.Empty;
    }

    public class NullLookupItem : LookupItem
    {
        public new int? IntId { get { return null; } }
        public new Guid? GuidId { get { return null; } }
    }
}
