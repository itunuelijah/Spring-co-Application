namespace SpringCoApplication.Dtos
{
    public class DeluxeDto : AccountDto
    {
        public string Id { get; set; }
        public double Balance { get; set; }
        public CustomerDto CustomerDto { get; set; }
        public double InterestRate { get; set; }
       

    }
}
