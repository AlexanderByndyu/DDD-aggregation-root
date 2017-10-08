using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Enums;

namespace DomainModel
{
    public class Order
    {
        private readonly List<OrderHistoryEntry> historyEntries;
        private readonly List<Product> products;

        protected Order()
        {
            historyEntries = new List<OrderHistoryEntry>();
            products = new List<Product>();
        }

        public Order(IEnumerable<Product> products, Client client) : this()
        {
            if (products == null)
                throw new ArgumentNullException("products");

            if (client == null)
                throw new ArgumentNullException("client");

            Client = client;
            products = products.ToList();
        }

        public Client Client { get; protected set; }

        public bool IsApproved { get; protected set; }

        public IEnumerable<Product> Products
        {
            get { return products; }
        }

        public IEnumerable<OrderHistoryEntry> HistoryEntries
        {
            get { return historyEntries; }
        }

        public void AddProduct(Product product)
        {
            product.Order = this;
            products.Add(product);
        }

        public void Approve()
        {
            IsApproved = true;

            var clientHistoryEntry = new OrderHistoryEntry(this, OrderHistoryType.Approved);

            historyEntries.Add(clientHistoryEntry);
        }
    }
}