using clientsControl.Application.Users.Queries.GetAllUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<GetAllUsersQueryDto>
    {
        public string FullName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Password { set; get; }
        public bool ClientUser { set; get; }
        public string ClientReup { set; get; }
    }
}
