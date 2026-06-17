using System.ComponentModel.DataAnnotations.Schema;

public class TraineeStatus
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    [Column(TypeName = "varchar(10)")]
    public string Status { get; set; } = null!;
}