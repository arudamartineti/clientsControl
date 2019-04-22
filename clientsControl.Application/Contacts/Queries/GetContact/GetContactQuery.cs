using clientsControl.Application.Contacts.Queries.GetAllContacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Queries.GetContact
{
    public class GetContactQuery : IRequest<ContactAllDto>
    {
        public Guid Id { set; get; }
    }
}
