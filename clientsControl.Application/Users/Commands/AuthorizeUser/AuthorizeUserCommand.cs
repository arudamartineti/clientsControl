using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Commands.AuthorizeUser
{
    public class AuthorizeUserCommand : IRequest
    {
        public string Id { set; get; }
    }
}
