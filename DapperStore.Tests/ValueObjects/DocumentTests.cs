using DapperStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;
        public DocumentTests(){
            invalidDocument = new Document("121313131");
            validDocument = new Document("411.845.935-31");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.IsFalse(invalidDocument.Valid);
            Assert.IsTrue(invalidDocument.Notifications.Count >= 1);
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid()
        {
            Assert.IsTrue(validDocument.Valid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}