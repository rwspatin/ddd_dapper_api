using System;
using DapperStore.Domain.StoreContext.Enums;

namespace DapperStore.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public Delivery(
            DateTime estimatedDeliveryDate)
        {
            this.CreateDate = DateTime.Now;
            this.EstimatedDeliveryDate = estimatedDeliveryDate;
            this.Status = EDeliveryStatus.Waiting;

        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}