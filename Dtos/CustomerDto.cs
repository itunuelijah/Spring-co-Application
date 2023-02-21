namespace SpringCoApplication.Dtos
{
    public class CustomerDto
    {
        internal readonly Account Account;

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
