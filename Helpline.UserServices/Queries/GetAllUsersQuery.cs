﻿using Helpline.Domain.Messaging;
using Helpline.UserServices.DTOs.Responses;
using MediatR;

namespace Helpline.UserServices.Queries
{
    public sealed record GetAllUsersQuery : IQuery<IEnumerable<UserResponse>>;
}
