using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<object>
    {
        public string Username { set; get; }
        public string Password { set; get; }
    }
}
