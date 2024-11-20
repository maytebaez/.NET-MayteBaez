namespace AccountsMicroservice.Exceptions
{
    public class ValidationException(string message) : Exception(message)
    {
    }
}