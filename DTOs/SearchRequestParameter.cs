using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Api.DTO;

/// <summary>
/// Parameters for filtering, searching, and paginating trainee lists.
/// </summary>
public class SearchRequestParameter
{
    /// <summary>
    /// The page number to retrieve.
    /// </summary>
    /// <example>1</example>
    [Range(1, int.MaxValue, ErrorMessage = StringConstant.MINIMUM_PAGE_NUMBER)]
    public int pageNumber { get; set; } = 1;

    /// <summary>
    /// The number of records to return per page.
    /// </summary>
    /// <example>10</example>
    [Range(1, int.MaxValue, ErrorMessage = StringConstant.MINIMUM_PAGE_SIZE)]
    public int pageSize { get; set; } = 10;

    /// <summary>
    /// Optional keyword to search trainees by name, email, or identifier code.
    /// </summary>
    /// <example>John</example>
    public string? search { get; set; }

    /// <summary>
    /// Filter trainees by their current status. 
    /// </summary>
    public string? status { get; set; }
}
