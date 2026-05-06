namespace szallitoDll.Exceptions
{
    public class NemTalalhatoOrszagKodException : Exception
    {
        private string orszagKod;

        public NemTalalhatoOrszagKodException(string orszagKod)
        {
            this.orszagKod = orszagKod;
        }
    }
}