using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<IEnumerable<IdentityRole>>
    {
    }
}
