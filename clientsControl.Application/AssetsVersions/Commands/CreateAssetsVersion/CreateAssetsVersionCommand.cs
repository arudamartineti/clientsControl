using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.AssetsVersions.Commands.CreateAssetsVersion
{
    public class CreateAssetsVersionCommand : IRequest<CreateAssetsVersionCreated>
    {        
        public string Description { get; set; }
    }
}
