using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class SupportDayPlanification
    {
        public SupportDayPlanification()
        {
            Installers = new HashSet<ApplicationUser>();
        }
        public Guid Id { set; get; }
        public DateTime DateSupport { set; get; }
        public bool NotWorkHolliday { set; get; }
        public SupportPlanification SupportPlanification { set; get; }
        public Guid SupportPlanificationId { set; get; }
        public ICollection<ApplicationUser> Installers { private set; get; }
    }
}
