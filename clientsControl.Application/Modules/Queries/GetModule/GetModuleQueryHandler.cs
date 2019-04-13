using AutoMapper;
using clientsControl.Application.Exceptions;
using clientsControl.Application.Modules.Queries.GetAllModules;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Modules.Queries.GetModule
{
    public class GetModuleQueryHandler : IRequestHandler<GetModuleQuery, ModuleDto>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetModuleQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<ModuleDto> Handle(GetModuleQuery request, CancellationToken cancellationToken)
        {
            var ent = await db.Module.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(Module), request.Id);

            return mapper.Map<ModuleDto>(ent);
        }
    }
}
