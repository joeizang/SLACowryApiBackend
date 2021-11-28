using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IWebhookPayload : INotification
    {
    }
}
