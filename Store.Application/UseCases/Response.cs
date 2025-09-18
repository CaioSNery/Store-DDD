using System;
using System.Collections.Generic;

using Flunt.Notifications;

namespace Store.Application.UseCases.Create
{
    public class Response : Application.Shared.Response
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