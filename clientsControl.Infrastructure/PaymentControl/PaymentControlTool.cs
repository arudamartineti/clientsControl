using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace clientsControl.Infrastructure.PaymentControl
{
    public class PaymentControlTool
    {
        private string generatedPaymentControlPath;
        private string key = "FCKGWRHQQ2YXRKT8TG6W2B7Q8";

        public PaymentControlTool(string generatedPaymentControlPath)
        {
            this.generatedPaymentControlPath = generatedPaymentControlPath;            
        }

        #region General Utils
        public string createDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            return directoryPath;
        }

        #endregion

        public string generatePaymentControl(string clientDescription, string licenseName, DateTime authorizedUntil)
        {
            string location = "";

            bool generated = true;


            return location;
        }

    }
}
