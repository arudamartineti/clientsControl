using AutoMapper;
using System.Linq;
using clientsControl.Application.Contacts.Queries.GetAllContacts;
using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
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
                throw new NotFoundException(nameof(Contact), request.Id);

            var qry =
               from contact in db.Contacts
               join client in db.Clients on contact.ClientId equals client.Id into clients
               from client in clients.DefaultIfEmpty()
               join license in db.Licenses on contact.LicenseId equals license.Id into licenses
               from license in licenses.DefaultIfEmpty()
               where contact.Id == request.Id
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

            return qry.FirstOrDefault();

        }

        
    }
}
