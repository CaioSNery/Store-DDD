using System;
using System.Collections.Generic;
using Flunt.Notifications;

namespace Store.Domain.UseCases.Authenticate
{
    public class Response : Shared.Response
    {
        protected Response() { }

        public Response(string message,
        int status,
        IEnumerable<Notification> notifications = null)
        {
            Message = message;
            Status = status;
            Notifications = notifications;
        }

        public Response(string message, ResponseData data)
        {
            Message = message;
            Status = 200;
            Data = data;
            Notifications = null;
        }

        public ResponseData Data { get; set; }

        public class ResponseData
        {

            public string Id { get; set; } = string.Empty;
            public string Token { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string[] Roles { get; set; } = Array.Empty<string>();
        }
    }
}