using clientsControl.Persistence;
using clientsControl.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace clientsControl.Application.Contacts.Queries.GetAllContacts
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactAllDto>>
    {
        private clientsControlDbContext db;
        private IMediator mediator;
        private IMapper mapper;
        public GetAllContactsQueryHandler(clientsControlDbContext db, IMediator mediator,  IMapper mapper)
        {
            this.db = db;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ContactAllDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var qry =
                from contact in db.Contacts
                join client in db.Clients on contact.ClientId equals client.Id into clients         
                from client in clients.DefaultIfEmpty()
                join license in db.Licenses on contact.LicenseId equals license.Id into licenses
                from license in licenses.DefaultIfEmpty()
                select new ContactAllDto()
                {
                    Id = contact.Id,
                    ClientId = contact.ClientId,
                    ClientCode = client.Code,
                    ClientDescription = client.Description,
                    Email = contact.Email,
                    Name = contact.Name,
                    PhoneNumber = contact.PhoneNumber,
                    LicenseId = contact.LicenseId,
                    LicenseName = license.Name ?? "Indefinido",
                    RecibeLicencias = contact.RecibeLicencias
                };

            return qry;            
        }
    }
}
