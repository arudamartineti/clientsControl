using clientsControl.Application.Users.Queries.GetAllUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Commands.AddRolesUser
{
    public class AddRolesUserCommand : IRequest<GetAllUsersQueryDto>
    {
        public string Id { set; get; }
        public List<string> Roles { set; get; }
    }
}
