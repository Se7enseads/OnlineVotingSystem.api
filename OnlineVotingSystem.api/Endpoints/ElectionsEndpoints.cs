using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.api.Data;
using OnlineVotingSystem.api.DTOs.Election;
using OnlineVotingSystem.api.Mapping;

namespace OnlineVotingSystem.api.Endpoints;

public static class ElectionsEndpoints
{
    public static RouteGroupBuilder MapElectionEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("elections").WithParameterValidation(); // Parent route
        
        // Get all elections - "http://localhost:PORT/elections/"
        group.MapGet("/", async (OnlineVotingSystemContext dbContext) =>
        {
            // select all elections
            return await dbContext.Elections
                .Select(election => election.ToElectionDetailsDto())
                .AsNoTracking()
                .ToListAsync();
        }).WithName("getElections"); // name of the route
        
        // Get election by id - "http://localhost:PORT/elections/{id}"
        group.MapGet("/{id:guid}", async (Guid id, OnlineVotingSystemContext dbContext) =>
        {
            var election = await dbContext.Elections.FindAsync(id); // find election by id
            // return null or the election when found
            return election is null ? Results.NotFound() : Results.Ok(election.ToElectionDetailsDto());
        });
        
        // Create election - "http://localhost:PORT/elections/create" - ADMIN ONLY
        group.MapPost("/create",
            async (CreateElectionDto newElection, OnlineVotingSystemContext dbContext, ClaimsPrincipal user) =>
            {
                // get userId from JWT/ from logged-in user
                var userId = Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
                var election = newElection.ToEntity(userId); // convert Json to entity data

                dbContext.Elections.Add(election); // add election to database
                await dbContext.SaveChangesAsync(); // save changes to the database

                return Results.CreatedAtRoute("getElections", new { id = election.Id },
                    election.ToElectionDetailsDto()); // return created election
            }).RequireAuthorization("AdminOnly");

        // Delete election by id - "http://localhost:PORT/elections/{id}" - ADMIN ONLY
        group.MapDelete("/{id:guid}", async (Guid id, OnlineVotingSystemContext dbContext) =>
        {
            // delete by id
            await dbContext.Elections.Where(election => election.Id == id).ExecuteDeleteAsync();

            return Results.NoContent(); // return no-content
        }).RequireAuthorization("AdminOnly");

        return group;
    }
}