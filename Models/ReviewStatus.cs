using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class ReviewStatus
{    
    public int Id {get;set;}
    public int StatusId { get; set; }

    [Column(TypeName = "varchar" )]
    [MaxLength(25)]
    public string Status { get; set; } = null!;
}   