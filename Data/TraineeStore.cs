using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Data;

public static class TraineeStore
{
    public static List<Trainee> trainees {get;} = new();

    public static int _nextId = 0;

    public static int GetNextId() => _nextId++; 
}