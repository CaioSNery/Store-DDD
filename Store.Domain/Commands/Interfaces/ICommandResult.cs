using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain.Commands.Interfaces
{
    public interface ICommandResult
    {
        public bool Success { get; }
        public string Message { get; }
        public object Data { get; }
    }
}