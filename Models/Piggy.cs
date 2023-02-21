using System.ComponentModel.DataAnnotations.Schema;

namespace SpringCoApplication.Models
{
    public class Piggy : Account
    {
        [Column("Type")]
        public string Discriminator => "Piggy";

        public double InterestRate { get; set; }

        public Piggy(string id,
                             DateTime createdAt,
                             Customer customer,
                             IList<AccountOperation> accountOperations)
        {
            Id = id;
            Balance = 0.0;
            CreatedAt = createdAt;
            Customer = customer;
            AccountOperations = accountOperations;
            InterestRate = 6.0;
        }

        public Piggy()
        {
        }
    }
}
