using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Configuration.Commands.UpdateConfiguration
{
    public class UpdateConfigurationCommandHandler : IRequestHandler<UpdateConfigurationCommand, UpdateConfigurationDto>
    {
        clientsControlDbContext db;

        public UpdateConfigurationCommandHandler(clientsControlDbContext db)
        {
            this.db = db;
        }

        public async Task<UpdateConfigurationDto> Handle(UpdateConfigurationCommand request, CancellationToken cancellationToken)
        {
            var configuration = db.Configuration.First();

            if (configuration == null)
            {
                configuration = new clientsControl.Domain.Entities.Configuration()
                {
                    Id = Guid.NewGuid(),
                    ClientConsecutive = request.ClientConsecutive,
                    GeneratedPaymentControlPath = request.GeneratedPaymentControlPath,
                    LicenceConsecutive = request.LicenceConsecutive,
                    SmtpPassword = request.SmtpPassword,
                    SmtpPort = request.SmtpPort,
                    SmtpServer = request.SmtpServer,
                    StmpUser = request.StmpUser
                };

                await db.Configuration.AddAsync(configuration, cancellationToken);                
            }
            else
            {
                configuration.ClientConsecutive = request.ClientConsecutive;
                configuration.GeneratedPaymentControlPath = request.GeneratedPaymentControlPath;
                configuration.LicenceConsecutive = request.LicenceConsecutive;
                configuration.SmtpPassword = request.SmtpPassword;
                configuration.SmtpPort = request.SmtpPort;
                configuration.SmtpServer = request.SmtpServer;
                configuration.StmpUser = request.StmpUser;

                db.Configuration.Update(configuration);
            }

            await db.SaveChangesAsync(cancellationToken);

            return new UpdateConfigurationDto()
            {
                Id = configuration.Id,
                ClientConsecutive = configuration.ClientConsecutive,
                GeneratedPaymentControlPath = configuration.GeneratedPaymentControlPath,
                LicenceConsecutive = configuration.LicenceConsecutive,
                SmtpPassword = configuration.SmtpPassword,
                SmtpPort = configuration.SmtpPort,
                SmtpServer = configuration.SmtpServer,
                StmpUser = configuration.StmpUser
            };
        }
    }
}
