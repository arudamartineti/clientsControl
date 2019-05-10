using clientsControl.Application.Users.Queries.GetAllUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Queries.GetAllInstallers
{
    public class GetAllInstallersQuery : IRequest<IEnumerable<GetAllUsersQueryDto>>
    {

    }
}
