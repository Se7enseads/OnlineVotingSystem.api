using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.api.Entities;

namespace OnlineVotingSystem.api.Data;

public class OnlineVotingSystemContext(DbContextOptions<OnlineVotingSystemContext> options) : DbContext(options)
{
    public DbSet<Candidate> Candidates => Set<Candidate>();
    public DbSet<Election> Elections => Set<Election>();
    public DbSet<ElectionPosition> ElectionsPositions => Set<ElectionPosition>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Vote> Votes => Set<Vote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"), // Hardcoded UUID
                Name = "Admin",
                NationalId = 10000001,
                Email = "admin@system.com",
                Password = "$2a$11$PlHURX9wlCUp.yY038iuOu6u9k7oMIZ2O6vAwiaRsJtMzYlC8NWby", // Securely hashed password
                IsAdmin = true,
                CreatedAt = new DateTime(2024, 2, 11, 12, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}