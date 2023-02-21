using SpringCoApplication.Models;

namespace SpringCoApplication.Repositories
{
    public class AccountOperationRepository : IAccountOperationRepository
    {

        private readonly ApplicationDbContext _context;

        public AccountOperationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountOperation>> GetAccountOperations()
        {
            return await _context.AccountOperations.ToListAsync();
        }

        public async Task<Account> GetAccountOperationById(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task CreateAccountOperation(AccountOperation accountOperation)
        {
            _context.AccountOperations.Add(accountOperation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountOperation(AccountOperation accountOperation)
        {
            _context.AccountOperations.Update(accountOperation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountOperation(int id)
        {
            var accountOperation = await _context.AccountOperations.FindAsync(id);
            _context.AccountOperations.Remove(accountOperation);
            await _context.SaveChangesAsync();
        }

    }
}
