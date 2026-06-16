using System.ComponentModel.DataAnnotations.Schema;

public class SubmissionStatus
{    
    public int Id {get;set;}
    public int StatusId { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string Status { get; set; } = null!;
}   