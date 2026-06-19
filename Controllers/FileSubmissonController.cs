using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/submission-files")]
public class FileSubmissionController : ControllerBase
{
    private readonly ISubmissionService _submissionControllerService;
    private readonly ILogger<SubmissionController> _logger;
    public FileSubmissionController(ISubmissionService submissionControllerService, ILogger<SubmissionController> logger)
    {
        _submissionControllerService = submissionControllerService;
        _logger = logger;
    }

    /// <summary>
    /// Download submission.
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    /// <response code="200">Retrieve file with matching submission Id.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpGet("{id:int}/download")]
    public async Task<IActionResult> download(int id)
    {
        FileStream stream = await _submissionControllerService.download(id);
        string FileName=Path.GetFileName(stream.Name);
        string extension=Path.GetExtension(FileName);
        return File(stream,$"application/{extension.Substring(1)}",FileName);
    }
    /// <summary>
    /// Delete Submitted file.
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    /// <response code="204">Delete file with matching  submission Id.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpDelete("{id:int}/download")]
    public async Task<IActionResult> delete(int id)
    {
        bool res =  await _submissionControllerService.delete(id);
        if (!res)
        {
            _logger.LogInformation("Submission file with ID {id} not found", id);
            return NotFound(new { message = $"submission file with ID {id} not found" });
        }
        _logger.LogInformation("file deleted successfully. submissionFileId: {Id}", id);
        return NoContent();
    }


}