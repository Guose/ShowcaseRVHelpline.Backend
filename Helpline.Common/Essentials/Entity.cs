namespace Helpline.Common.Essentials
{
    public class Entity : IEquatable<Entity>
    {
        public Entity()
        {
        }
        protected Entity(Guid guidId)
        {
            GuidId = guidId;
            IdType = IdType.Guid;
        }
        protected Entity(int intId)
        {
            IntId = intId;
            IdType = IdType.Int;
        }

        public Guid GuidId { get; private set; }
        public int IntId { get; private set; }

        public IdType IdType { get; set; }

        public static bool operator ==(Entity? first, Entity? second) =>
            first is not null && second is not null && first.Equals(second);

        public static bool operator !=(Entity? first, Entity? second) =>
            !(first == second);

        public bool Equals(Entity? other)
        {
            if (other is null || other.GetType() != GetType())
                return false;

            return IdType == other.IdType &&
                (IdType == IdType.Guid ?
                GuidId == other.GuidId :
                IntId == other.IntId);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity entity || entity.GetType() != GetType())
                return false;

            return Equals(entity);
        }

        public override int GetHashCode()
        {
            return IdType switch
            {
                IdType.Guid => GuidId.GetHashCode() * 41,
                IdType.Int => IntId.GetHashCode() * 41,
                _ => base.GetHashCode()
            };
        }
    }

    public enum IdType
    {
        Guid,
        Int,
    }
}
