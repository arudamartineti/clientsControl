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

namespace clientsControl.Application.Licenses.Queries.GetAllLicenses
{
    public class GetAllLicensesQueryHandler : IRequestHandler<GetAllLicensesQuery, IEnumerable<LicenseDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetAllLicensesQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LicenseDto>> Handle(GetAllLicensesQuery request, CancellationToken cancellationToken)
        {            

            var qry = 
                from l in db.Licenses
                join c in db.Clients on l.ClientId equals c.Id into cs
                from c in cs.DefaultIfEmpty()
                join lc in db.LicenseClientClasification on l.ClasificationId equals lc.Id into lcs
                from lc in lcs.DefaultIfEmpty()
                join st in db.StockTypes on l.StockTypeId equals st.Id into sts
                from st in sts.DefaultIfEmpty()
                join v in db.AssetsVersions on l.VersionId equals v.Id into vs
                from v in vs.DefaultIfEmpty()
                where !l.Descontinued
                select new LicenseDto()
                {
                    Id = l.Id,
                    ClasificationClientDescription = lc.Name ?? "Indefenido",
                    ClasificationId = l.ClasificationId,
                    ClientCode = c.Code ?? "Indefinido",
                    ClientDescription = c.Description ?? "Indefinido",
                    ClientId = l.ClientId,
                    Code = l.Code,
                    CreationDate = l.CreationDate,                    
                    Name = l.Name,
                    REUP = l.REUP,
                    StockTypeDescription = st.Description ?? "Indefinido",
                    StockTypeId = l.StockTypeId,
                    VersionDescription = v.Description ?? "Indefinido",
                    VersionId = l.VersionId
                };

            return qry;

            //return mapper.ProjectTo<LicenseDto>(db.Licenses.Where(c => c.Descontinued == false).AsQueryable<License>());
        }
    }
}
