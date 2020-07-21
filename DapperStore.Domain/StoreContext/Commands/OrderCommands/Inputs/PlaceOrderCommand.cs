using System;
using System.Collections.Generic;
using System.Linq;
using DapperStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace DapperStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommands>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommands> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                                .Requires()
                                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
                                .IsGreaterThan(OrderItems.Count(), 0, "Items", "Nenhum item do pedido foi encontrado")
                                );

            return Valid();
        }
    }
}