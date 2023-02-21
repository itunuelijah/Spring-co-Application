using System.ComponentModel.DataAnnotations.Schema;

namespace SpringCoApplication.Models
{
    public class Flex : Account
    {
        [Column("Type")]
        public string Discriminator => "Flex";

        public double InterestRate { get; set; }

        public Flex(string id,
                             DateTime createdAt,
                             Customer customer,
                             IList<AccountOperation> accountOperations)
        {
            Id = id;
            Balance = 0.0;
            CreatedAt = createdAt;
            Customer = customer;
            AccountOperations = accountOperations;
            InterestRate = 3.0;
        }

        public Flex()
        {
        }
    }
}
