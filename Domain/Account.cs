using System.Collections.Generic;
using DomainModel.Enums;

namespace DomainModel
{
    public class Account
    {
        private readonly List<Role> roles;

        protected Account()
        {
            roles = new List<Role>();
        }

        public Account(string email, string password) : this()
        {
            Email = email;
            Password = password;
            IsActive = false;

            AddRole(Role.Member);
        }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public IEnumerable<Role> Roles
        {
            get { return roles; }
        }

        public bool IsActive { get; protected set; }

        public void AddRole(Role role)
        {
            if (roles.Contains(role))
                return;

            roles.Add(role);
        }

        public void Activate()
        {
            IsActive = true;
        }

        internal void Disable()
        {
            IsActive = false;
        }
    }
}