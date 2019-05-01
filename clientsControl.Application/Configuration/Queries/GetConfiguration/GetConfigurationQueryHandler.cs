using AutoMapper;
using clientsControl.Application.Configuration.Commands.UpdateConfiguration;
using clientsControl.Application.Exceptions;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Configuration.Queries.GetConfiguration
{
    public class GetConfigurationQueryHandler : IRequestHandler<GetConfigurationQuery, UpdateConfigurationDto>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetConfigurationQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<UpdateConfigurationDto> Handle(GetConfigurationQuery request, CancellationToken cancellationToken)
        {
            var configuration = db.Configuration.FirstOrDefault();

            if (configuration == null)
                throw new NotFoundException(nameof(clientsControl.Domain.Entities.Configuration), "");

            //return mapper.Map<clientsControl.Domain.Entities.Configuration>(configuration);

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
