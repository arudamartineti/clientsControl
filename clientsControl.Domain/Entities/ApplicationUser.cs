using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { set; get; }
        public bool ComercialAuthorized { set; get; }
        public bool ClientUser { set; get; }
        public string ClientReup { set; get; }
    }
}
