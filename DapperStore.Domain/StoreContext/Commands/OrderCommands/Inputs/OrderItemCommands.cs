using System;

namespace DapperStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class OrderItemCommands
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}