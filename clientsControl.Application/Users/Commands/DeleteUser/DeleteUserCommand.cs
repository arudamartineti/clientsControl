using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public string Id { set; get;  }
    }
}
