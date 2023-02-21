namespace SpringCoApplication.Services
{
    public interface ICustomerService
    {
        public CustomerDto RegisterCustomer(CustomerDto customerDto);


        public Task<IEnumerable<CustomerDto>> ListCustomers();



        public CustomerDto GetCustomer(long customerId);

        public Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto);


        public  Task DeleteCustomer(long customerId);
          
   
    }
}