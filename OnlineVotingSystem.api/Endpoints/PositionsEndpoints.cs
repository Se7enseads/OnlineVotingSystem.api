using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.api.Data;
using OnlineVotingSystem.api.DTOs.Position;
using OnlineVotingSystem.api.Mapping;

namespace OnlineVotingSystem.api.Endpoints;

public static class PositionsEndpoints
{
    public static RouteGroupBuilder MapPositionEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("positions").WithParameterValidation();

        group.MapGet("/", async (OnlineVotingSystemContext dbContext) =>
        {
            return await dbContext.Positions
                .Select(position => position.ToPositionDetails())
                .AsNoTracking()
                .ToListAsync();
        }).WithName("getPositions");

        group.MapGet("/{id:guid}",
            async (Guid id, OnlineVotingSystemContext dbContext) =>
            {
                var position = await dbContext.Positions.FindAsync(id);
                return
                    position is null
                        ? Results.NotFound()
                        : Results.Ok(position.ToPositionDetails());
            });

        group.MapPost("/create",
            async (CreatePositionDto newPosition,
                OnlineVotingSystemContext dbContext) =>
            {
                var position = newPosition.ToEntity();

                dbContext.Positions.Add(position);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("getPositions",
                    new { id = position.Id },
                    position.ToPositionDetails());
            }).RequireAuthorization("AdminOnly");

        group.MapDelete("/{id:guid}",
            async (Guid id, OnlineVotingSystemContext dbContext) =>
            {
                await dbContext.Positions
                    .Where(position => position.Id == id)
                    .ExecuteDeleteAsync();
                
                return Results.NoContent();
            }).RequireAuthorization("AdminOnly");

        return group;
    }
}