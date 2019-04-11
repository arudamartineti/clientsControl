using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Exceptions
{
    public class CodeUsedException : Exception
    {
        public CodeUsedException(string Entity, object field) : base($"Entity \"{Entity}\" code ({field}) has is beign used")
        {

        }
    }
}
