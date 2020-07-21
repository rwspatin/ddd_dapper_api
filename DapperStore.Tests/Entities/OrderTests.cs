using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Enums;
using DapperStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _printer;
        private Product _chair;
        private Customer _customer;
        private Order  _order;
        public OrderTests()
        {
            var name = new Name("Renan", "Spatin");
            var doc = new Document("411.845.935-31");
            var email = new Email("rwspatin@gmail.com");

            _customer = new Customer(name, doc, email,"2323232323");

            _order = new Order(_customer);
            _mouse = new Product("Mouse", "Rato", "image.png", 100M, 10);
            _keyboard = new Product("Teclado", "Teclado", "image.png", 100M, 10);
            _printer = new Product("Impressora", "Impressora", "image.png", 100M, 10);
            _chair = new Product("Cadeira", "Cadeira", "image.png", 100M, 10);
        }
        
        [TestMethod]
        public void ShoulCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.Valid);
        }

        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_printer, 5);
            _order.AddItem(_mouse, 5);

            Assert.AreEqual(2, _order.Items.Count);
        }

        [TestMethod]
        public void ShoulReturnFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        [TestMethod]
        public void ShoudlReturnANumberWhenOrderPlaced(){
            _order.Place();
            Assert.IsFalse(string.IsNullOrEmpty(_order.Number));
        }

        [TestMethod]
        public void ShoulPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void ShoulReturnTwoWhenPurchasedTenProducts(){
            _order.AddItem(_mouse, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_printer, 1); 
            _order.AddItem(_chair, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_printer, 1); 
            _order.AddItem(_chair, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_keyboard, 1);

            _order.Ship();

            Assert.AreEqual(2, _order.Deliverys.Count);
        }

        [TestMethod]
        public void StatusShouldBeCanceledWhenORderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        [TestMethod]
        public void ShouldCancelShippingWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_printer, 1); 
            _order.AddItem(_chair, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_keyboard, 1);
            _order.AddItem(_printer, 1); 
            _order.AddItem(_chair, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_keyboard, 1);

            _order.Ship();

            _order.Cancel();

            foreach(var d in _order.Deliverys)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, d.Status);
            }
        }
    }
}