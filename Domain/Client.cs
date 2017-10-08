using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Enums;

namespace DomainModel
{
    public class Client
    {
        private readonly List<Order> orders;

        protected Client()
        {
            orders = new List<Order>();
        }

        public Client(Account account) : this()
        {
            if (account == null)
                throw new ArgumentNullException("account");

            Account = account;
            Account.AddRole(Role.Client);
        }

        public Account Account { get; protected set; }
        public bool IsLocked { get; protected set; }

        public IEnumerable<Order> Orders
        {
            get { return orders; }
        }

        public void Lock()
        {
            IEnumerable<Order> notApprovedOrders = orders.Where(o => o.IsApproved == false);

            foreach (Order order in notApprovedOrders)
                orders.Remove(order);

            Account.Disable();
        }
    }
}