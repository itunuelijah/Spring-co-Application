using Microsoft.AspNetCore.Mvc;
using SpringCoApplication.Services;


namespace SpringCoApplication.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;

        public AccountController(IAccountService accountService, ICustomerService customerService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet("{accountId}")]
        public ActionResult<AccountDto> GetAccount(string accountId)
        {
            try
            {
                return Ok(_accountService.GetAccount(accountId));
            }
            catch (AccountNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("list")]
        public ActionResult<List<AccountDto>> ListAccounts()
        {
            return Ok(_accountService.ListAccounts());
        }

        [HttpPost("debit")]
        public ActionResult<DebitDto> Debit([FromBody] DebitDto debitDTO)
        {
            try
            {
                _accountService.Debit(debitDTO.AccountId, debitDTO.Amount, debitDTO.Description);
                return Ok(debitDTO);
            }
            catch (AccountNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BalanceNotSufficientException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("credit")]
        public ActionResult<CreditDto> Credit([FromBody] CreditDto creditDTO)
        {
            try
            {
                _accountService.Credit(creditDTO.AccountId, creditDTO.Amount, creditDTO.Description);
                return Ok(creditDTO);
            }
            catch (AccountNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("saveFlex")]
        public ActionResult<FlexDto> SaveFlexAccount([FromBody] FlexDto flexDTO)
        {
            try
            {
                return Ok(_accountService.SaveFlexAccount(flexDTO.Balance, flexDTO.CustomerDto.Id));
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }




        [HttpPost("saveDeluxe")]
        public ActionResult<DeluxeDto> SaveDeluxeAccount(DeluxeDto deluxeDTO)
        {
            try
            {
                return Ok(_accountService.SaveDeluxeAccount(deluxeDTO.Balance, deluxeDTO.CustomerDto.Id));
            }
            catch (CustomerNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("savePiggy")]
        public ActionResult<PiggyDto> SavePiggyAccount(PiggyDto piggyDTO)
        {
            try
            {
                return Ok(_accountService.SavePiggyAccount(piggyDTO.Balance, piggyDTO.CustomerDto.Id));
            }
            catch (CustomerNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("saveSupa")]
        public ActionResult<SupaDto> SaveSupaAccount(SupaDto supaDTO)
        {
            try
            {
                return Ok(_accountService.SaveSupaAccount(supaDTO.Balance, supaDTO.CustomerDto.Id));
            }
            catch (CustomerNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("saveViva")]
        public ActionResult<VivaDto> SaveVivaAccount(VivaDto vivaDTO)
        {
            try
            {
                return Ok(_accountService.SaveVivaAccount(vivaDTO.Balance, vivaDTO.CustomerDto.Id));
            }
            catch (CustomerNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("/get/{accountType}")]
        public ActionResult<List<Customer>> FilterAllCustomersWithASpecificAccountType(string accountType)
        {
            try
            {
                return Ok(_accountService.FilterAllCustomersWithASpecificAccountType(accountType));
            }
            catch (AccountNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("/{customerName}")]
        public ActionResult<List<Account>> FilterAllAccountsForASpecificCustomer(string customerName)
        {
            return Ok(_accountService.FilterAllAccountsForASpecificCustomer(customerName));
        }

        [HttpGet("/get/noCustomer")]
        public ActionResult<List<Account>> FilterAllAccountsWithoutCustomer()
        {
            return Ok(_accountService.FilterAllAccountsWithoutCustomer());
        }

    }

}

