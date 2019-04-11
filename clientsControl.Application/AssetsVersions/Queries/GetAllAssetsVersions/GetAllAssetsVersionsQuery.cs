using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.AssetsVersions.Queries.GetAllAssetsVersions
{
    public class GetAllAssetsVersionsQuery : IRequest<IEnumerable<AssetsVersionDto>>
    {
    }
}
