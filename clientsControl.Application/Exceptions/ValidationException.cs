using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Failures { get; }
        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }
    }
}
