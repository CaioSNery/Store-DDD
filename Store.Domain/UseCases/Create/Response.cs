using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;

namespace Store.Domain.UseCases.Create
{
    public class Response : Shared.Response
    {
        public Response()
        {
            Notifications = new List<Notification>();
        }

        public Response(string message,
        int status,
        IEnumerable<Notification> notifications = null)
        {
            Message = message;
            Status = status;
            Notifications = notifications;
        }

        public record ResponseData(Guid Id, string Name, string Email);

        public ResponseData Data { get; set; }

        public Response(string message, ResponseData data)
        {
            Message = message;
            Status = 201;
            Data = data;
            Notifications = null;
        }
    }
}