using Microsoft.EntityFrameworkCore;

namespace SpringCoApplication.Repositories
{
    public interface IAccountRepository
    {
        public Task<IEnumerable<Account>> GetAccounts();

        public Account GetAccountById(string id);

        public Account Save(Account account);

        public Task UpdateAccount(Account account);


        public Task DeleteAccount(string id);
       

    }
}