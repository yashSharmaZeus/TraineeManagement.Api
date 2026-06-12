namespace TraineeManagement.Api.DTO;

public class PagedResponse<T>
{
    public int pageNumber{get; set;}
    public int pageSize {get; set;}
    public int totalRecords {get; set;}

    public List<T>? data{ get; set;}

    public PagedResponse(List<T>? trainees, int TotalResponse,int pgNum=1,int pgSize =10)
    {
        pageNumber = pgNum;
        pageSize = pgSize; 
        totalRecords = TotalResponse;
        data = trainees;
    }
}
