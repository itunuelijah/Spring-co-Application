namespace SpringCoApplication.Exceptions
{
    public class BalanceNotSufficientException : Exception
    {
        public BalanceNotSufficientException(string message) : base(message)
        {
        }

    }
}
