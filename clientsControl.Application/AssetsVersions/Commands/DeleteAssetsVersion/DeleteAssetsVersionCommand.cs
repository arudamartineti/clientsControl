using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.AssetsVersions.Commands.DeleteAssetsVersion
{
    public class DeleteAssetsVersionCommand : IRequest
    {
        public Guid Id { set; get; }
    }
}
