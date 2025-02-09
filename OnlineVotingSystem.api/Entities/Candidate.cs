using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVotingSystem.api.Entities;

public class Candidate
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey("ElectionPosition")] public Guid ElectionPositionId { get; set; }

    public ElectionPosition? ElectionPosition { get; set; }

    [StringLength(100)] public required string Name { get; set; }

    [DefaultValue("independent"), StringLength(100)]
    public string? Party { get; set; }

    [StringLength(255)] public string? Bio { get; set; }

    [StringLength(255)] public string? PhotoUrl { get; set; }
}