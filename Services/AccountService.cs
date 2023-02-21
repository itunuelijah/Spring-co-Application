using SpringCoApplication.Dtos;
using SpringCoApplication.Models;

namespace SpringCoApplication.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountOperationRepository _accountOperationRepository;
        private readonly AccountMapperService _dtoMapper;


        public AccountService(
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository,
            IAccountOperationRepository accountOperationRepository,
            AccountMapperService dtoMapper)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _accountOperationRepository = accountOperationRepository;
            _dtoMapper = dtoMapper;
           
        }


        public AccountDto GetAccount(string accountId)
        {
            var account = _accountRepository.GetAccountById(accountId);

            return account switch
            {
                Flex flex => _dtoMapper.FromFlex(flex),
                Deluxe deluxe => _dtoMapper.FromDeluxe(deluxe),
                Piggy piggy => _dtoMapper.FromPiggy(piggy),
                Supa supa => _dtoMapper.FromSupa(supa),
                Viva viva => _dtoMapper.FromViva(viva),
                _ => throw new InvalidOperationException("Unknown account type."),
            };
        }


        public void Debit(string accountId, double amount, string description)
        {
            var account = _accountRepository.GetAccountById(accountId);
            if (account == null) throw new AccountNotFoundException("Account not found");
            if (account.Balance < amount) throw new BalanceNotSufficientException("Balance not sufficient");

            var accountOperation = new AccountOperation
            {
                Type = OperationType.DEBIT,
                Amount = amount,
                OperationDate = DateTime.Now,
                Account = account
            };
            _accountOperationRepository.CreateAccountOperation(accountOperation);


            account.Balance -= amount;
            _accountRepository.UpdateAccount(account);
            _accountRepository.Save(account);

           //_logger.LogInformation("Debited account: {@account}", account);
        }


        public void Credit(string accountId, double amount, string description)
        {
            var account = _accountRepository.GetAccountById(accountId);
            if (account == null)
                throw new AccountNotFoundException("Account not found");

            var accountOperation = new AccountOperation
            {
                Type = OperationType.CREDIT,
                Amount = amount,
                OperationDate = DateTime.Now,
                Account = account
            };

            _accountOperationRepository.CreateAccountOperation(accountOperation);
           

            account.Balance += amount;
            _accountRepository.UpdateAccount(account);
            _accountRepository.Save(account);
        }

        public void Transfer(string accountIdSource, string accountIdDestination, double amount)
        {
            try
            {
                Debit(accountIdSource, amount, $"Transfer to {accountIdDestination}");
                Credit(accountIdDestination, amount, $"Transfer from {accountIdSource}");
            }
            catch (AccountNotFoundException)
            {
                throw;
            }
            catch (BalanceNotSufficientException)
            {
                throw;
            }
        }

        public double GetBalance(string accountId)
        {
            var account = _accountRepository.GetAccountById(accountId);
            if (account == null)
                throw new AccountNotFoundException("Account not found");

            return account.Balance;
        }

        public FlexDto SaveFlexAccount(double initialBalance, long customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException("Customer not found");
            }

            var flex = new Flex
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                Balance = initialBalance
            };
            var savedFlex = _accountRepository.Save(flex);
            return _dtoMapper.FromFlex((Flex)savedFlex);
        }

        public DeluxeDto SaveDeluxeAccount(double initialBalance, long customerId)
        {
            Customer customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException("Customer not found");
            }

            var deluxe = new Deluxe
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                Balance = initialBalance
            };
            var savedDeluxe = _accountRepository.Save(deluxe);
            return _dtoMapper.FromDeluxe((Deluxe)savedDeluxe);
        }








        public PiggyDto SavePiggyAccount(double initialBalance, long customerId)
        {
            Customer customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException("Customer not found");
            }

            Piggy piggy = new Piggy
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                Balance = initialBalance
            };
            Piggy savedPiggy = (Piggy)_accountRepository.Save(piggy);
            return _dtoMapper.FromPiggy(savedPiggy);
        }



        public SupaDto SaveSupaAccount(double initialBalance, long customerId)
        {
            Customer customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException("Customer not found");
            }

            Supa supa = new Supa
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                Balance = initialBalance
            };
            Supa savedSupa = (Supa)_accountRepository.Save(supa);
            return _dtoMapper.FromSupa(savedSupa);
        }



        public VivaDto SaveVivaAccount(double initialBalance, long customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException("Customer not found");
            }

            Viva viva = new Viva
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                Balance = initialBalance
            };
            Viva savedViva = (Viva)_accountRepository.Save(viva);
            return _dtoMapper.FromViva(savedViva);
        }


        public async Task<List<AccountDto>> ListAccounts()
        {
            IEnumerable<Account> accounts = await _accountRepository.GetAccounts();
            List<AccountDto> accountDtos = new List<AccountDto>();

            foreach (var account in accounts)
            {
                if (account is Flex flex)
                {
                    accountDtos.Add(_dtoMapper.FromFlex(flex));
                }
                else if (account is Deluxe deluxe)
                {
                    accountDtos.Add(_dtoMapper.FromDeluxe(deluxe));
                }
                else if (account is Piggy piggy)
                {
                    accountDtos.Add(_dtoMapper.FromPiggy(piggy));
                }
                else if (account is Supa supa)
                {
                    accountDtos.Add(_dtoMapper.FromSupa(supa));
                }
                else if (account is Viva viva)
                {
                    accountDtos.Add(_dtoMapper.FromViva(viva));
                }
                else
                {
                    throw new Exception("Unknown account type");
                }
            }

            return accountDtos;
        }




        public double GetTheInterestWithMinBalancePerYears(int numberOfYears, string accountId)
        {
            Account account = _accountRepository.GetAccountById(accountId);
            if (account == null)
            {
                throw new AccountNotFoundException("Account not found");
            }

            if (account.Balance >= 20000)
            {
                if (account.Type == "Flex")
                {
                    double interest = account.Balance * numberOfYears * 2.5;
                    return interest;
                }
                else if (account.Type == "Deluxe")
                {
                    double interest = account.Balance * numberOfYears * 3.5;
                    return interest;
                }
                else if (account.Type == "Viva")
                {
                    double interest = account.Balance * numberOfYears * 6.0;
                    return interest;
                }
                else if (account.Type == "Piggy")
                {
                    double interest = account.Balance * numberOfYears * 9.2;
                    return interest;
                }
                else if (account.Type == "Supa")
                {
                    double interest = account.Balance * numberOfYears * 10.0;
                    return interest;
                }
            }
            return 0;
        }




        public List<Customer> FilterAllCustomersWithASpecificAccountType(string type)
        {
            List<Customer> customers = _customerRepository.FindByAccountsContainingAsync(type);
            return customers;
        }

        public async Task<List<Account>> FilterAllAccountsForASpecificCustomer(string customerName)
        {
            IEnumerable<Account> accounts = await _accountRepository.GetAccounts();
            List<Account> filteredAccounts = new List<Account>();
            foreach (var account in accounts)
            {
                if (account.Customer != null && account.Customer.Name == customerName)
                {
                    filteredAccounts.Add(account);
                }
            }
            return filteredAccounts;
        }

        public async Task<List<Account>> FilterAllAccountsWithoutCustomer()
        {
            var filteredAccounts = new List<Account>();
            var accounts = await _accountRepository.GetAccounts();

            foreach (var account in accounts)
            {
                if (account.Customer == null)
                {
                    filteredAccounts.Add(account);
                }
            }
            return filteredAccounts;
        }


    }
}







