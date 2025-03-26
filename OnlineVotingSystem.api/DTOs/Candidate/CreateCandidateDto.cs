using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.api.DTOs.Candidate;

public record CreateCandidateDto(
    string  NationalId,//FIX:  BUG CREATE DTO TO USE NATIONALID
    Guid? PositionId, //FIX:  BUG CREATE DTO TO USE POSITIONID
    [StringLength(100)] string? Party,
    [StringLength(255)] string Bio,
    [StringLength(255)] string? PhotoUrl
);