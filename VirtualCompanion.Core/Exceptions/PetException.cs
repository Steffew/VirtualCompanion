namespace VirtualCompanion.Core.Exceptions
{
    public class PetException : Exception
    {
        public PetException(string message) : base(message)
        {

        }

        public PetException(string message, Exception innerException) : base(message,innerException)
        {

        }
    }
}
