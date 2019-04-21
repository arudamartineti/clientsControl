using AutoMapper;
using clientsControl.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace clientsControl.Application.PaymentControls.Queries.GetAllPaymentControls
{
    public class GetAllPaymentControlsQueryHandler : IRequestHandler<GetAllPaymentControlsQuery, IEnumerable<PaymentControlDto>>
    {
        private clientsControlDbContext db;
        private IMapper mapper;

        public GetAllPaymentControlsQueryHandler(clientsControlDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PaymentControlDto>> Handle(GetAllPaymentControlsQuery request, CancellationToken cancellationToken)
        {
            var qry =
                from pc in db.PaymentControls
                join l in db.Licenses on pc.LicenceId equals l.Id into ls
                from l in ls.DefaultIfEmpty()
                join c in db.Clients on l.ClientId equals c.Id into cs
                from c in cs.DefaultIfEmpty()
                select new PaymentControlDto()
                {
                    Id = pc.Id,
                    ClientDescription = c.Description ?? "Indefinido",
                    ExpirationDate = pc.ExpirationDate,
                    GeneratedDate = pc.GeneratedDate,
                    LicenceId = pc.LicenceId,
                    LicenseName = l.Name ?? "Indefinido",
                    SentByEmail = pc.SentByEmail,
                    SentByEmailDate = pc.SentByEmailDate
                };

            return qry;
        }
    }
}
