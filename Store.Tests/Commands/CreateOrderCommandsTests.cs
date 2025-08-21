using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Commands;

namespace Store.Tests.Commands
{

    [TestClass]
    public class CreateOrderCommandsTests
    {

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmComandInvalidoOPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();

            command.ZipCode = "123456";
            command.PromoCode = "654321";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.IsValid, false);

        }
    }
}
