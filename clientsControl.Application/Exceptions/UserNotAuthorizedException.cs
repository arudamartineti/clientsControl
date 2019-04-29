using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Exceptions
{
    public class UserNotAuthorizedException : Exception
    {
        public UserNotAuthorizedException() : base("User not authorized")
        {

        }
    }
}
