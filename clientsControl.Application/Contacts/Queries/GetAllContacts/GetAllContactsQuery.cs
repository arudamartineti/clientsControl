using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Queries.GetAllContacts
{
    public class GetAllContactsQuery : IRequest<IEnumerable<ContactAllDto>>
    {
    }
}
