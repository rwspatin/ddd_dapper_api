using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid(){
            var command = new CreateCustomerCommand();
            command.FirstName = "Renan";
            command.LastName = "Spatin";
            command.Document = "411.845.935-31";
            command.Email = "rwspatin@gmail.com";
            command.Phone = "3232656598";

            Assert.IsTrue(command.Valid());
        }
    }
}