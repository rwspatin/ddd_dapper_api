using System;
using System.Collections.Generic;

namespace DapperStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand
    {
        public Guid Customer { get; set; }
        public IList<OrderItemCommands> OrderItems { get; set; }
    }
}