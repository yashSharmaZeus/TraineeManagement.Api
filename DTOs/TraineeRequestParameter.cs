using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Api.DTO;

public class TraineeRequestParameter
{
    [Range(1, int.MaxValue,ErrorMessage =StringConstant.MINIMUM_PAGE_NUMBER)]
    public int pageNumber{get; set;} =1;

    [Range(1, int.MaxValue,ErrorMessage = StringConstant.MINIMUM_PAGE_SIZE)]
    public int pageSize {get; set;} = 10;

    public string? search {get; set;}
    
    public string? status {get; set;}
}
