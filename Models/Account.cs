using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpringCoApplication.Models
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public string Id { get; set; }

        public double Balance { get; set; }

        public DateTime CreatedAt { get; set; }

        public Customer Customer { get; set; }

        public IList<AccountOperation>? AccountOperations { get; set; }
        public long CustomerId { get; internal set; }

        public string Type { get; internal set; }
        public Account(string id,
                           DateTime createdAt,
                           Customer customer,
                           IList<AccountOperation> accountOperations)
        {
            Id = id;
            Balance = 0.0;
            CreatedAt = createdAt;
            Customer = customer;
            AccountOperations = accountOperations;
           
        }


        public Account(string id, double balance, DateTime createdAt, Customer customer, IList<AccountOperation>? accountOperations, long customerId, string type)
        {
            Id = id;
            Balance = balance;
            CreatedAt = createdAt;
            Customer = customer;
            AccountOperations = accountOperations;
            CustomerId = customerId;
            Type = type;
        }

        public Account()
        {
        }
    }
}
