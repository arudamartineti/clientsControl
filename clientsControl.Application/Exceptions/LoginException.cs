using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException() : base("Incorrect login")
        {

        }
    }
}
