using static SpringCoApplication.Repositories.AccountRepository;
using System;

namespace SpringCoApplication.Repositories
{
    public class AccountRepository : IAccountRepository
    {

            private readonly ApplicationDbContext _context;

            public AccountRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Account>> GetAccounts()
            {
                return await _context.Accounts.ToListAsync();
            }


            public Account GetAccountById(string accountId)
            {
                return  _context.Accounts.Include(a => a.Customer).FirstOrDefault(a => a.Id.Equals(accountId));
            }

             public Account Save(Account account)
             {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return account;
             }
      
            public async Task UpdateAccount(Account account)
            {
                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAccount(string id)
            {
                var account = await _context.Accounts.FindAsync(id);
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        

    }
}
