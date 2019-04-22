using AutoMapper;
using clientsControl.Application.Contacts.Queries.GetAllContacts;
using clientsControl.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Contacts.Queries.GetContact
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactAllDto>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetContactQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<ContactAllDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var ent = await db.Contacts.FindAsync(request.Id);

            if (ent == null)
        }

        
    }
}
