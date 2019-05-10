using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Domain.Entities
{
    public class SupportPlanification
    {
        public SupportPlanification()
        {
            DayPlanifications = new HashSet<SupportDayPlanification>();
        }
        public Guid Id { set; get; }
        public byte Month { set; get; }
        public int Year { set; get; }
        public bool Confirmed { set; get; }
        public ICollection<SupportDayPlanification> DayPlanifications { private set; get; }
    }
}
