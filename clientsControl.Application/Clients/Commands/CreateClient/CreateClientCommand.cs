﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<CreateClientCreated> //public class CreateClientCommand : IRequest
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string AssetsCode { get; set; }
    }
}
