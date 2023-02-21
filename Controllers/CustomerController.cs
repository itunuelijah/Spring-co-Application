using Microsoft.AspNetCore.Mvc;
using SpringCoApplication.Dtos;
using SpringCoApplication.Services;


namespace SpringCoApplication.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }



        [HttpGet("list")]
        public ActionResult<List<CustomerDto>> Customers()
        {
            try
            {
                var customers = _customerService.ListCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting customers");
                return StatusCode(500, "An error occurred while getting customers");
            }
          
        }


        //   [HttpGet("search")]
        //    public ActionResult<List<CustomerDto>> SearchCustomers([FromQuery(Name = "keyword")] string keyword = "")
        //   {
        //       return Ok(_customerService.SearchCustomers("%" + keyword + "%"));
        //    }
        //


        [HttpGet("get/{customerId}")]
        public ActionResult<CustomerDto> GetCustomer(long customerId)
        {
            try
            {
                return Ok(_customerService.GetCustomer(customerId));
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost("save")]
        public ActionResult<CustomerDto> RegisterCustomer([FromBody] CustomerDto customerDTO)
        {
            return Ok(_customerService.RegisterCustomer(customerDTO));

        }



        [HttpDelete("delete/{customerId}")]
        public ActionResult<string> DeleteCustomer(long customerId)
        {
            _customerService.DeleteCustomer(customerId);
            return Ok("Customer successfully deleted");
        }

    }

}

