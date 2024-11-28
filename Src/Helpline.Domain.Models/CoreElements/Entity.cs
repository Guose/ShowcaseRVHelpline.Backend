namespace Helpline.Domain.Models.CoreElements
{
    public enum IdType
    {
        Guid,
        Int,
        Both,
    }

    public class Entity : IEquatable<Entity>
    {
        public Entity()
        {
        }
        protected Entity(Guid guidId)
        {
            Id = guidId;
            IdType = IdType.Guid;
        }
        protected Entity(int intId)
        {
            IntId = intId;
            IdType = IdType.Int;
        }
        protected Entity(Guid guidId, int intId)
        {
            if (guidId == Guid.Empty || intId == 0)
                throw new ArgumentException("Both GuidId and IntId must be valid values.");

            Id = guidId;
            IntId = intId;
            IdType = IdType.Both;
        }

        public Guid Id { get; private init; }
        public int IntId { get; private init; }
        public IdType IdType { get; private init; }

        public static bool operator ==(Entity? first, Entity? second) =>
            first is not null && second is not null && first.Equals(second);

        public static bool operator !=(Entity? first, Entity? second) =>
            !(first == second);

        public bool Equals(Entity? other)
        {
            if (other is null || other.GetType() != GetType())
                return false;

            if (IdType == IdType.Both || other.IdType == IdType.Both)
                return Id == other.Id && IntId == other.IntId;

            return IdType == other.IdType &&
                (IdType == IdType.Guid ?
                Id == other.Id :
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
                IdType.Guid => Id.GetHashCode() * 41,
                IdType.Int => IntId.GetHashCode() * 41,
                IdType.Both => HashCode.Combine(Id, IntId) * 41,
                _ => base.GetHashCode()
            };
        }

        public override string ToString()
        {
            return IdType switch
            {
                IdType.Guid => $"Entity with GuidId: {Id}",
                IdType.Int => $"Entity with IntId: {IntId}",
                IdType.Both => $"Entity with GuidId: {Id} and IntId: {IntId}",
                _ => "Entity with unknown IdType"
            };
        }
    }
}
