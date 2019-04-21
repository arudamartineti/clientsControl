using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Interfaces
{
    public interface IPaymentControlTool
    {
        string generatePaymentControl(string clientDescripcion, string licenseName, DateTime authorizeUntil, string directoryPayments);        
    }
}
