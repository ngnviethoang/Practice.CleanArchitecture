namespace WeTicket.Contract.Exceptions;

public class WeTicketException : Exception
{
    public WeTicketException(string message) : base(message)
    {
    }

    public WeTicketException(string message, Exception innerException) : base(message, innerException)
    {
    }
}