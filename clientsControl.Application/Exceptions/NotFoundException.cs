using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"La Entidad  \"{name}\"({key}) no fue encontrada.")
        {

        }
    }
}
