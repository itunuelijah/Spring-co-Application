using System.ComponentModel.DataAnnotations.Schema;

namespace SpringCoApplication.Models
{
    public class Supa : Account 
    {
        [Column("Type")]
        public string Discriminator => "Supa";

        public double InterestRate { get; set; }

        public Supa(string id,
                             DateTime createdAt,
                             Customer customer,
                             IList<AccountOperation> accountOperations)
        {
            Id = id;
            Balance = 0.0;
            CreatedAt = createdAt;
            Customer = customer;
            AccountOperations = accountOperations;
            InterestRate = 6.5;
        }

        public Supa()
        {
        }
    }
}
