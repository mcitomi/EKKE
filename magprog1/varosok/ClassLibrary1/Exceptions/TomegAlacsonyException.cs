namespace szallitoDll.Exceptions
{
    [Serializable]
    public class TomegAlacsonyException : Exception
    {
        public TomegAlacsonyException()
        {
        }

        public TomegAlacsonyException(string? message) : base(message)
        {
        }

        public TomegAlacsonyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}