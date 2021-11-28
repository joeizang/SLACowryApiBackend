using MediatR;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Notifications.WebhookNotifications
{
    public class WebhookNotificationHandler : INotificationHandler<IWebhookPayload>
    {
        private readonly SlaCowryWiseContext _context;

        public WebhookNotificationHandler(SlaCowryWiseContext context)
        {
            _context = context;
        }

        public Task Handle(IWebhookPayload notification, CancellationToken cancellationToken)
        {
            //if(notification is not null)
            //{
            //    // persist the json as a string in postgres.
            //}
            throw new NotImplementedException();
        }
    }
}
