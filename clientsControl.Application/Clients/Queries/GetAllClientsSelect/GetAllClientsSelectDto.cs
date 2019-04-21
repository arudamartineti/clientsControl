using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Queries.GetAllClientsSelect
{
    public class GetAllClientsSelectDto
    {
        public Guid Id { set; get; }
        public string Code { set; get; }
        public string Description { set; get; }
    }
}
