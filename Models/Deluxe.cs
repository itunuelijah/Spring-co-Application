using System.ComponentModel.DataAnnotations.Schema;

namespace SpringCoApplication.Models
{
    public class Deluxe : Account
    {
        [Column("Type")]
        public string Discriminator => "Deluxe";

        public double InterestRate { get; set; }

        public Deluxe(string id,
                             DateTime createdAt,
                             Customer customer,
                             IList<AccountOperation> accountOperations)
        {
            Id = id;
            Balance = 0.0;
            CreatedAt = createdAt;
            Customer = customer;
            AccountOperations = accountOperations;
            InterestRate = 5.0;
        }

        public Deluxe()
        {
        }
    }
}
