using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest
    {
        public Guid Id { set; get; }
    }
}
