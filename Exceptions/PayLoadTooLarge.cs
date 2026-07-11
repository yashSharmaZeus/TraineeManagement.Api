namespace TraineeManagement.Api.Exceptions;

public class PayLoadTooLarge : Exception
{
    public PayLoadTooLarge(string message) : base(message) { }
}