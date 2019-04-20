using AutoMapper;
using clientsControl.Application.Exceptions;
using clientsControl.Application.Licenses.Queries.GetAllLicenses;
using clientsControl.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clientsControl.Application.Licenses.Queries.GetLicense
{
    public class GetLicenseQueryHandler : IRequestHandler<GetLicenseQuery, GetLicenseDto>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetLicenseQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<GetLicenseDto> Handle(GetLicenseQuery request, CancellationToken cancellationToken)
        {            
            var ent = await db.Licenses.Include(c => c.LicenseDetails).FirstOrDefaultAsync(c => c.Id == request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(License), request.Id);

            //var qry =
            //    from l in db.Licenses
            //    join c in db.Clients on l.ClientId equals c.Id into cs
            //    from c in cs.DefaultIfEmpty()
            //    join lc in db.LicenseClientClasification on l.ClasificationId equals lc.Id into lcs
            //    from lc in lcs.DefaultIfEmpty()
            //    join st in db.StockTypes on l.StockTypeId equals st.Id into sts
            //    from st in sts.DefaultIfEmpty()
            //    join v in db.AssetsVersions on l.VersionId equals v.Id into vs
            //    from v in vs.DefaultIfEmpty()
            //    where l.Id == request.Id
            //    select new LicenseDto()
            //    {
            //        Id = l.Id,
            //        ClasificationClientDescription = lc.Name ?? "Indefenido",
            //        ClasificationId = l.ClasificationId,
            //        ClientCode = c.Code ?? "Indefinido",
            //        ClientDescription = c.Description ?? "Indefinido",
            //        ClientId = l.ClientId,
            //        Code = l.Code,
            //        CreationDate = l.CreationDate,
            //        Descontinued = l.Descontinued,
            //        Name = l.Name,
            //        REUP = l.REUP,
            //        StockTypeDescription = st.Description ?? "Indefinido",
            //        StockTypeId = l.StockTypeId,
            //        VersionDescription = v.Description ?? "Indefinido",
            //        VersionId = l.VersionId
            //    };

            return mapper.Map<GetLicenseDto>(ent);
        }
    }
}
