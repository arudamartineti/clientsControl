using AutoMapper;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.AssetsVersions.Queries.GetAllAssetsVersions
{
    public class GetAllAssetsVersionsQueryHandler : IRequestHandler<GetAllAssetsVersionsQuery, IEnumerable<AssetsVersionDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetAllAssetsVersionsQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AssetsVersionDto>> Handle(GetAllAssetsVersionsQuery request, CancellationToken cancellationToken)
        {
            return mapper.ProjectTo<AssetsVersionDto>(db.AssetsVersions.AsQueryable<AssetsVersion>());
        }
    }
}
