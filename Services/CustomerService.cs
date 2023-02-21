
namespace SpringCoApplication.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly AccountMapperService _dtoMapper;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository,
                                   AccountMapperService dtoMapper,
                                   ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _dtoMapper = dtoMapper;
            _logger = logger;
        }

        public CustomerDto RegisterCustomer(CustomerDto customerDto)
        {
            _logger.LogInformation("Saving new customer");
            Customer customer = _dtoMapper.FromCustomerDto(customerDto);

            // Check if a customer with the same name and email already exists
            if (_customerRepository.GetCustomerByNameAndEmail(customer.Name, customer.Email) != null)
            {
                throw new ArgumentException("A customer with the same name and email already exists.");
            }

            Customer savedCustomer = _customerRepository.CreateCustomer(customer);
            _logger.LogInformation("Saved Customer: {0}", savedCustomer);
            return _dtoMapper.FromCustomer(savedCustomer);
        }



        public async Task<IEnumerable<CustomerDto>> ListCustomers()
        {
            IEnumerable < Customer > customers = await _customerRepository.GetCustomers();
            List<CustomerDto> customerDtos = customers.Select(customer => _dtoMapper.FromCustomer(customer)).ToList();
            return customerDtos;
        }


        public CustomerDto GetCustomer(long customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException("Customer Not Found");
            }
            return _dtoMapper.FromCustomer(customer);
        }

        public async Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto)
        {
            _logger.LogInformation("Updating customer");
            Customer customer = _dtoMapper.FromCustomerDto(customerDto);
            Customer updatedCustomer = await _customerRepository.UpdateCustomerAsync(customer);
            CustomerDto updatedCustomerDto = _dtoMapper.FromCustomer(updatedCustomer);
            return updatedCustomerDto;
        }


        public async Task DeleteCustomer(long customerId)
        {
            await _customerRepository.DeleteCustomer(customerId);
        }



    }
}
