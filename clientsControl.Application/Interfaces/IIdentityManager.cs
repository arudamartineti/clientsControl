using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Interfaces
{
    public interface IIdentityManager
    {
        object registerUser(string userName, string userEmail, string userPassword);
        object authenticatheUser(string userName, string userPassword);
        object authorizeUser(string userName);
        object buildToken(string user);
    }
}
