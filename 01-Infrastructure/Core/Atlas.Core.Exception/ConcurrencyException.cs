namespace Atlas.Core.Exception
{
    public class ConcurrencyException : System.Exception
    {
        public ConcurrencyException() : base()
        {

        }

        public ConcurrencyException(string message) : base(message)
        {

        }
    }
}
