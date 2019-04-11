using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Commands.DeleteLicense
{
    public class DeleteLicenseCommand : IRequest
    {
       public Guid Id { set; get; }
    }
}
