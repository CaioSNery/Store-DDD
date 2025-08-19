using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Entities

{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new Customer("Caio Nery", "caionery@.com");
        private readonly Product _product = new Product("Teste1", 10, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));


        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmPedidoValidoEleGeraUmNumeroCom8Caracters()
        {
            var order = new Order(_customer, 0, _discount);
            Assert.AreEqual(8, order.Number.Length);

        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmPedidoSeuStatusDeveSerAguardandoPagamento()
        {
            var order = new Order(_customer, 0, _discount);
            Assert.AreEqual(order.Status, EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmPedidoSeuStatusDeveSerAguardandoEntrega()
        {
            var order = new Order(_customer, 0, _discount);
            order.AddItem(_product, 1);
            order.Pay(20);
            Assert.AreEqual(EOrderStatus.WaitingDelivery, EOrderStatus.WaitingDelivery);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmPedidoCanceladoSeuStatusDeveSerCancelado()
        {
            var order = new Order(_customer, 0, _discount);
            order.Cancel();
            Assert.AreEqual(order.Status, EOrderStatus.Canceled);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoItemSemProdutoOMesmoNaoDeveSerAdicionado()
        {
            var order = new Order(_customer, 0, _discount);
            order.AddItem(null, 10);
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoItemComQuantidadeZeroOuMenorMesmoNaoDeveSerAdicionado()
        {
            var order = new Order(_customer, 0, _discount);
            order.AddItem(_product, 0);
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmNovoPedidoOTotalDeveSer50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoDescontoExpiradoOTotalDeveSer60()
        {
            var expirateDiscount = new Discount(10, DateTime.Now.AddDays(-5));
            var order = new Order(_customer, 10, expirateDiscount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoDescontoInvalidoOTotalDeveSer60()
        {
            var order = new Order(_customer, 10, null);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoDescontoDe10OTotalDeveSer50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmaTaxaDeEntragaDe10oTotalDeveSer60()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 6);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void DadoUmPedidoSemClienteOMesmoDeveSerInvalido()
        {
            var order = new Order(null, 10, _discount);
            Assert.AreEqual(order.Valid, false);
        }




    }
}