using clientsControl.Application.AssetsVersions.Queries.GetAllAssetsVersions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.AssetsVersions.Queries.GetAssetsVersion
{
    public class GetAssetsVersionQuery : IRequest<AssetsVersionDto>
    {
        public Guid Id { set; get; }
    }
}
