using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests;


[TestClass]
public class OrderTests
{
    private readonly Customer _customer = new Customer("Caio Nery", "caionery@.com");
    private readonly Product _product = new Product("Teste1", 10, true);
    private readonly Discount _discount = new Discount(8, DateTime.Now.AddDays(5));


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
        Assert.AreEqual(EOrderStatus.Canceled, EOrderStatus.Canceled);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void DadoUmNovoItemSemProdutoOMesmoNaoDeveSerAdicionado()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void DadoUmNovoItemComQuantidadeZeroOuMenorMesmoNaoDeveSerAdicionado()
    {
        Assert.Fail();
    }
}