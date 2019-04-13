using AutoMapper;
using clientsControl.Application.AssetsVersions.Queries.GetAllAssetsVersions;
using clientsControl.Application.Exceptions;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.AssetsVersions.Queries.GetAssetsVersion
{
    public class GetAssetsVersionQueryHandler : IRequestHandler<GetAssetsVersionQuery, AssetsVersionDto>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetAssetsVersionQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<AssetsVersionDto> Handle(GetAssetsVersionQuery request, CancellationToken cancellationToken)
        {
            var ent = await db.AssetsVersions.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(AssetsVersion), request.Id);

            return mapper.Map<AssetsVersionDto>(ent);
        }
    }
}
