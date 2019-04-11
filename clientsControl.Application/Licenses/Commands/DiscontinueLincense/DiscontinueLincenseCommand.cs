using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Commands.DiscontinueLincense
{
    public class DiscontinueLincenseCommand : IRequest
    {
        public Guid Id { set; get; }
    }
}
