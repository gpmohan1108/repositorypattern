namespace repositorypattern.Exceptions
{
    public class NotFoundException : Exception
    {
        //Global exception handling
        
        public NotFoundException(string message): base(message) { }
    }
}
