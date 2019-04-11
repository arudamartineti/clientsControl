using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Exceptions
{
    public class DescriptionUsedException : Exception
    {
        public DescriptionUsedException(string catalog, object value) : base($"The calaog  \"{catalog}\" has ({value}) on use")
        {

        }
    }
}
