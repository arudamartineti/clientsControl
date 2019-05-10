using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Contracts = new HashSet<Contract>();
            SupportDays = new HashSet<SupportDayPlanification>();
        }

        public string FullName { set; get; }
        public bool ComercialAuthorized { set; get; }
        public bool ClientUser { set; get; }
        public string ClientReup { set; get; }
        public ICollection<Contract> Contracts {private set; get;}
        public ICollection<SupportDayPlanification> SupportDays { private set; get; }
    }
}
