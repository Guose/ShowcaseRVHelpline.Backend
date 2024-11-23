using Helpline.Contracts.v1.Responses;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Addresses.Queries
{
    public sealed record AddressByUserIdQuery(Guid UserId) : IQuery<AddressResponse>;
}
