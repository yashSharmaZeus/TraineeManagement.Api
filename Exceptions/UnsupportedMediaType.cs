namespace TraineeManagement.Api.Exceptions;

public class UnsupportedMediaType : Exception
{
    public UnsupportedMediaType(string message) : base(message) { }
}