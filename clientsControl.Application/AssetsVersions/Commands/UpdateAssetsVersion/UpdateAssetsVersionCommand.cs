using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.AssetsVersions.Commands.UpdateAssetsVersion
{
    public class UpdateAssetsVersionCommand : IRequest<UpdateAssetsVersionUpdated>
    {
        public Guid Id { set; get;  }
        public string Description { get; set; }
    }
}
