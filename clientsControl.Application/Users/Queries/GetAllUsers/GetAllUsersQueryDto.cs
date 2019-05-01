using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryDto
    {
        public string Id { set; get; }
        public string Username { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }        
        public bool ClientUser { set; get; }
        public string ClientReup { set; get; }
        public bool Authorized { set; get; }
        public List<string> Roles { set; get; }
    }
}
