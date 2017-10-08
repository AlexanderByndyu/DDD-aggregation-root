using System;
using DomainModel.Enums;

namespace DomainModel
{
    public class OrderHistoryEntry
    {
        protected OrderHistoryEntry()
        {
        }

        public OrderHistoryEntry(Order order, OrderHistoryType type)
        {
            Order = order;
            Type = type;
        }

        public OrderHistoryType Type { get; protected set; }
        public Order Order { get; protected set; }
        public DateTime DateCreate { get; protected set; }
    }
}