using OnlineVotingSystem.api.DTOs.Election;
using OnlineVotingSystem.api.Entities;

namespace OnlineVotingSystem.api.Mapping;

public static class ElectionMapping
{
    public static ElectionDetailsDto ToElectionDetailsDto(this Election election)
    {
        return new ElectionDetailsDto
        (
            election.Id,
            election.Title,
            election.Description,
            election.StartTime,
            election.EndTime,
            election.CreatedBy
        );
    }
    
    public static Election ToEntity(this CreateElectionDto election, Guid userId )
    {
        return new Election
        {
            Id = Guid.NewGuid(),
            Title = election.Title,
            Description = election.Description,
            StartTime = election.StartTime,
            EndTime = election.EndTime,
            CreatedBy = userId
        };
    }
}