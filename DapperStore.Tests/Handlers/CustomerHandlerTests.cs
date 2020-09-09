using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using DapperStore.Domain.StoreContext.Handlers;
using DapperStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid(){
            var command = new CreateCustomerCommand();
            command.FirstName = "Andre";
            command.LastName = "Baltieri";
            command.Document = "544546564654";
            command.Email = "baltieri@gmail.com";
            command.Phone = "4635454354";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());

            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.IsTrue(handler.Valid);
        }
    }
}