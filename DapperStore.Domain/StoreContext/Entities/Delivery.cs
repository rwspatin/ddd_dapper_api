using System;

namespace DapperStore.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public Delivery(
            DateTime createDate, 
            DateTime estimatedDeliveryDate, 
            string status)
        {
            this.CreateDate = createDate;
            this.EstimatedDeliveryDate = estimatedDeliveryDate;
            this.Status = status;

        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public string Status { get; private set; }
    }
}