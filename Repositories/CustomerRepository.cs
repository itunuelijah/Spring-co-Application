using Microsoft.EntityFrameworkCore;
using SpringCoApplication.Models;
using System;
using System.Data;

namespace SpringCoApplication.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {

            if (_context.Database.GetDbConnection().State != ConnectionState.Open)
            {
                // The database connection is not open, so open it.
                await _context.Database.OpenConnectionAsync();
            }

            return await _context.Customers.ToListAsync();
        }

        public Customer GetCustomerById(long id)
        {
            return  _context.Customers.Find(id);
            
        }

        public Customer CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
             _context.SaveChanges();
            return customer;

        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return  customer;
        }

        public async Task DeleteCustomer(long id)
        {
            var product = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(product);
            await _context.SaveChangesAsync();
        }

        public Customer GetCustomerByNameAndEmail(string name, string email)
        {
            return _context.Customers.FirstOrDefault(c => c.Name == name && c.Email == email);
        }



        public List<Customer> FindByNameContainsAsync(string keywords)
        {
            return _context.Set<Customer>().Where(c => c.Name.Contains(keywords)).ToList();
        }

        public List<Customer> FindByAccountsContainingAsync(string type)
        {
            return _context.Set<Customer>().Where(c => c.Accounts.Any(a => a.Type == type)).ToList();
        }
    }
}
