namespace TraineeManagement.Api.DTO;

public class PagedResponse
{
    public int pageNumber{get; set;}
    public int pageSize {get; set;}
    public int totalRecords {get; set;}

    public List<TraineeResponse>? data{ get; set;}

    public PagedResponse(List<TraineeResponse>? trainees, int TotalResponse,int pgNum=1,int pgSize =10)
    {
        pageNumber = pgNum;
        pageSize = pgSize; 
        totalRecords = TotalResponse;
        data = trainees;
    }
}
