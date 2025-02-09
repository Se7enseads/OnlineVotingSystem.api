using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.api.Entities;

namespace OnlineVotingSystem.api.Data;

public class OnlineVotingSystemContext(DbContextOptions<OnlineVotingSystemContext> options) : DbContext(options)
{
    public DbSet<Candidate> Candidates => Set<Candidate>();
    public DbSet<Election> Elections => Set<Election>();
    public DbSet<ElectionPosition> ElectionsPositions => Set<ElectionPosition>();
    public DbSet<Position> Position => Set<Position>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Vote> Votes => Set<Vote>();
}