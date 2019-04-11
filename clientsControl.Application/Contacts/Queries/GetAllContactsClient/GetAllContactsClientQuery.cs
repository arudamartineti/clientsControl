using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Contacts.Queries.GetAllContactsClient
{
    public class GetAllContactsClientQuery : IRequest<IEnumerable<ContactsAllClientDto>>
    {
        public Guid Id { set; get; }
    }
}
