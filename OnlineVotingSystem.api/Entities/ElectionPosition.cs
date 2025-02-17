using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVotingSystem.api.Entities;

public class ElectionPosition

{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey("Election")] public Guid ElectionId { get; set; }

    public required Election Election { get; set; }

    [ForeignKey("Positions")] public Guid PositionId { get; set; }

    public required Position Position { get; set; }
}