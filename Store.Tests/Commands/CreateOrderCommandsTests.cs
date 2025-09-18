using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Application.Commands;
using Xunit;

namespace Store.Tests.Commands
{

    
    public class CreateOrderCommandsTests
    {

        [Fact]
        [Trait("Handlers", "CreateOrder")]
        public void DadoUmComandInvalidoOPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();

            command.ZipCode = "123456";
            command.PromoCode = "654321";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.False(command.IsValid);

        }
    }
}
