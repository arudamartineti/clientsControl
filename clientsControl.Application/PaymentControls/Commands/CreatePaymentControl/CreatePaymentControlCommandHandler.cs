using AutoMapper;
using clientsControl.Application.Exceptions;
using clientsControl.Application.Interfaces;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.PaymentControls.Commands.CreatePaymentControl
{
    public class CreatePaymentControlCommandHandler : IRequestHandler<CreatePaymentControlCommand, CreatePaymentControlCreated>
    {
        private IPaymentControlTool paymentTool;
        private clientsControlDbContext db;
        private IMapper mapper;

        public CreatePaymentControlCommandHandler(IPaymentControlTool paymentTool, clientsControlDbContext db, IMapper mapper)
        {
            this.paymentTool = paymentTool;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<CreatePaymentControlCreated> Handle(CreatePaymentControlCommand request, CancellationToken cancellationToken)
        {
            var license = await db.Licenses.FindAsync(request.LicenceId);

            if (license == null)
                throw new NotFoundException(nameof(License), request.LicenceId);

            var client = await db.Clients.FindAsync(license.ClientId);

            if (client == null)
                throw new NotFoundException(nameof(Client), request.LicenceId);

            var configuration = db.Configuration.FirstOrDefault();

            if (configuration == null)
                throw new NotFoundException(nameof(Configuration), Guid.Empty);

            string location = paymentTool.generatePaymentControl(client.Description, license.Name, request.ExpirationDate, configuration.GeneratedPaymentControlPath);

            var ent = new PaymentControl()
            {
                Id = Guid.NewGuid(),
                GeneratedDate = DateTime.Now,
                ExpirationDate = request.ExpirationDate,
                LicenceId = request.LicenceId,
                Localization = location,
                Public = request.Public,
                SendByEmail = request.SendByEmail,
                SentByEmail = false,
                SentByEmailDate = DateTime.Now
            };

            await db.PaymentControls.AddAsync(ent);

            await db.SaveChangesAsync();

            return mapper.Map<CreatePaymentControlCreated>(ent);      
        }
    }
}
