using Microsoft.EntityFrameworkCore;

namespace SpringCoApplication.Repositories
{
    public interface IAccountOperationRepository
    {
        public Task<IEnumerable<AccountOperation>> GetAccountOperations();



        public Task<Account> GetAccountOperationById(int id);


        public Task CreateAccountOperation(AccountOperation accountOperation);



        public Task UpdateAccountOperation(AccountOperation accountOperation);



        public Task DeleteAccountOperation(int id);
      
    }
}