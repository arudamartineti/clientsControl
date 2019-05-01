using clientsControl.Application.Configuration.Commands.UpdateConfiguration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Configuration.Queries.GetConfiguration
{
    public class GetConfigurationQuery : IRequest<UpdateConfigurationDto>
    {
    }
}
