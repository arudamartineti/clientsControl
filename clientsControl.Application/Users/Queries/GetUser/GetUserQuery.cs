using clientsControl.Application.Users.Queries.GetAllUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<GetAllUsersQueryDto>
    {
        public string Id { set; get; }
    }
}
