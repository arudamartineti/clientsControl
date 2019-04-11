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

namespace clientsControl.Application.Modules.Queries.GetAllModules
{
    public class GetAllModulesQueryHandler : IRequestHandler<GetAllModulesQuery, IEnumerable<ModuleDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetAllModulesQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ModuleDto>> Handle(GetAllModulesQuery request, CancellationToken cancellationToken)
        {
            return mapper.ProjectTo<ModuleDto>(db.Module.AsQueryable<Module>());
        }
    }
}
