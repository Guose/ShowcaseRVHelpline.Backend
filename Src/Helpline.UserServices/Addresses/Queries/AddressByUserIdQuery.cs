using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Addresses.Queries
{
    public sealed record AddressByUserIdQuery(Guid UserId) : IQuery<AddressResponse>;
}
