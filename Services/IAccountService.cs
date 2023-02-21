namespace SpringCoApplication.Services
{
    public interface IAccountService
    {
        public AccountDto GetAccount(string accountId);


        public void Debit(string accountId, double amount, string description);


        public void Credit(string accountId, double amount, string description);


        public void Transfer(string accountIdSource, string accountIdDestination, double amount);

        public double GetBalance(string accountId);

        public FlexDto SaveFlexAccount(double initialBalance, long customerId);

        public DeluxeDto SaveDeluxeAccount(double initialBalance, long customerId);


        public PiggyDto SavePiggyAccount(double initialBalance, long customerId);


        public SupaDto SaveSupaAccount(double initialBalance, long customerId);


        public VivaDto SaveVivaAccount(double initialBalance, long customerId);


        public Task<List<AccountDto>> ListAccounts();


        public double GetTheInterestWithMinBalancePerYears(int numberOfYears, string accountId);


        public List<Customer> FilterAllCustomersWithASpecificAccountType(string type);


        public Task<List<Account>> FilterAllAccountsForASpecificCustomer(string customerName);


        public Task<List<Account>> FilterAllAccountsWithoutCustomer();
       
    }
}