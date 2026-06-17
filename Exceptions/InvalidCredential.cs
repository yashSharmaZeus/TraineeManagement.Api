namespace TraineeManagement.Api.Exceptions;

public class InvalidCredential : Exception
{
    public InvalidCredential(string message) : base(message) { }
}