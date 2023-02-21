using Microsoft.EntityFrameworkCore;

namespace SpringCoApplication.Repositories
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetCustomers();


        public Customer GetCustomerById(long id);


        public Customer CreateCustomer(Customer customer);


        public Task<Customer> UpdateCustomerAsync(Customer customer);


        public Task DeleteCustomer(long id);

        public Customer GetCustomerByNameAndEmail(string name, string email);

        public List<Customer> FindByNameContainsAsync(string keywords);


        public List<Customer> FindByAccountsContainingAsync(string type);
      

    }
}