using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Repositories;
using Store.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;

namespace Store.Tests.Handlers
{

    [TestClass]
    public class OrderHandlerTests
    {
        private readonly ICustomerRepository _customerrepositoty;
        private readonly IDeliveryFeeRepository _deliveryfeerepositoty;
        private readonly IDiscountRepository _discountrepositoty;
        private readonly IOrderRepository _orderrepositoty;
        private readonly IProductRepository _productrepositoty;

        public OrderHandlerTests()
        {
            _customerrepositoty = new FakeCostumerRepository();
            _deliveryfeerepositoty = new FakeDeliveryFeeRepository();
            _discountrepositoty = new FakeDiscountRepository();
            _orderrepositoty = new FakeOrderRepository();
            _productrepositoty = new FakeProductRepository();
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmClienteInexistenteOPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = Guid.Empty; // Cliente inexistente
            command.ZipCode = "12356";
            command.PromoCode = "123456789";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmCepInvalidoOPedidoDeveSerGeradoNormalmente()
        {
            var command = new CreateOrderCommand();
            command.Customer = Guid.Empty;
            command.ZipCode = ""; // CEP inválido
            command.PromoCode = "123456789";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmPromoCodeInexistenteOPedidoDeveSerGeradoNormalmente()
        {
            var command = new CreateOrderCommand();
            command.Customer = Guid.Empty;
            command.ZipCode = "12356";
            command.PromoCode = "";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmPedidoSemItemOMesmoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = Guid.Empty;
            command.ZipCode = "12356";
            command.PromoCode = "123456789";

            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmComandoInvalidOPedidoNaoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = Guid.Empty;
            command.ZipCode = "12356";
            command.PromoCode = "123456789";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();
            Assert.AreEqual(command.Valid, false);


        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void DadoUmComandoValidoOPedidoDeveSerGerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = Guid.Empty;
            command.ZipCode = "12356";
            command.PromoCode = "123456789";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }

    }
}