using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Exceptions
{
    public class UserRegisterException : Exception
    {
        public UserRegisterException() : base($"Error registering user")
        {

        }
    }
}
