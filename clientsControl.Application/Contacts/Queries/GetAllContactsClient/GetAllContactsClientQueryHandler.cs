using AutoMapper;
using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Contacts.Queries.GetAllContactsClient
{
    public class GetAllContactsClientQueryHandler : IRequestHandler<GetAllContactsClientQuery, IEnumerable<ContactsAllClientDto>>
    {
        private clientsControlDbContext db;
        private IMediator mediator;
        private IMapper mapper;

        public GetAllContactsClientQueryHandler(clientsControlDbContext db, IMediator mediator, IMapper mapper)
        {
            this.db = db;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ContactsAllClientDto>> Handle(GetAllContactsClientQuery request, CancellationToken cancellationToken)
        {
            if (!db.Clients.Where(c => c.Id == request.Id).Any())
                throw new NotFoundException(nameof(Client), request.Id);

            return mapper.ProjectTo<ContactsAllClientDto>(db.Contacts.Where(c => c.ClientId == request.Id).AsQueryable<Contact>());
        }
    }
}
