using System.Collections.Generic;
using DataAccess;
using DomainModel;
using DomainModel.Enums;
using Infrastructure;

namespace Demo
{
    internal class ScenarioSuite
    {
        private readonly AccountRepository accountRepository = new AccountRepository();

        /// NOTE
        /// Приложение для демонстрации корня агрегации. Основной код в сборке DomainModel. Сборки DataAccess и Infrastructure только в качестве вспомогательных.
        
        private readonly ClientRepository clientRepository = new ClientRepository();
        private readonly OrderRepository orderRepository = new OrderRepository();
        private readonly ProductRepository productRepository = new ProductRepository();
        private readonly UnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        private void Scenario1()
        {
            using (unitOfWorkFactory.Create())
            {
                var account = new Account("email", "password");

                account.AddRole(Role.Admin);

                accountRepository.Save(account);
            }
        }

        /// <summary>
        /// Создание клиента
        /// </summary>
        private void Scenario2()
        {
            using (unitOfWorkFactory.Create())
            {
                Account account = accountRepository.GetByEmail("email");

                var client = new Client(account);

                clientRepository.Save(client);
            }
        }

        /// <summary>
        /// Создание заказа
        /// </summary>
        private void Scenario3()
        {
            using (unitOfWorkFactory.Create())
            {
                Client client = clientRepository.Get(23);

                Product product1 = productRepository.Get(1);
                Product product2 = productRepository.Get(2);

                var products = new List<Product> {product1, product2};

                var order = new Order(products, client);

                orderRepository.Save(order);
            }
        }

        /// <summary>
        /// Подтверждение заказа
        /// </summary>
        private void Scenario4()
        {
            using (unitOfWorkFactory.Create())
            {
                Order order = orderRepository.Get(1000);

                order.Approve();
            }
        }

        /// <summary>
        /// Блокирование клиента
        /// </summary>
        private void Scenario5()
        {
            using (unitOfWorkFactory.Create())
            {
                Client client = clientRepository.Get(1000);

                client.Lock();
            }
        }
    }
}