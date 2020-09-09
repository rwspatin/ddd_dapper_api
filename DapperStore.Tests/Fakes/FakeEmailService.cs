using DapperStore.Domain.StoreContext.Services;

namespace DapperStore.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
        }
    }
}