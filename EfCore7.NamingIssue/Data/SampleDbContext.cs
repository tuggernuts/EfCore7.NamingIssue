using System;
using System.Diagnostics;
using EfCore7.NamingIssue.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCore7.NamingIssue.Data;

public class SampleDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Aircraft> Aircraft { get; set; }
    public DbSet<AirplaneSingle> AirplaneSingles { get; set; }
    public DbSet<AirplaneMulti> AirplaneMultis { get; set; }
    public DbSet<RotorCraft> RotorCrafts { get; set; }
    public DbSet<Glider> Gliders { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<AirplaneSingle>().ToTable("airplane_singles");
        modelBuilder.Entity<AirplaneMulti>().ToTable("airplane_multis");
        modelBuilder.Entity<RotorCraft>().ToTable("rotorcraft");
        modelBuilder.Entity<Glider>().ToTable("gliders");

        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Name = "United States"},
            new Country { Id = 2, Name = "Canada"},
            new Country { Id = 3, Name = "Mexico" }
        );

        modelBuilder.Entity<Company>().HasData(new Company { Id = 1, Name = "Tuggernuts, Inc.", CountryId = 1});

        modelBuilder.Entity<Manufacturer>().HasData(
              new Manufacturer { Id = 1, Name = "Cessna" }
            , new Manufacturer { Id = 2, Name = "Piper" }
            , new Manufacturer { Id = 3, Name = "Beechcraft" }
            , new Manufacturer { Id = 4, Name = "Robinson" }
            , new Manufacturer { Id = 5, Name = "Bell" }
            , new Manufacturer { Id = 6, Name = "Grob" }
            );

        modelBuilder.Entity<AirplaneSingle>().HasData(
            new AirplaneSingle { Id = 1, CommonName = "Skyhawk", ModelNumber = "C172", ManufacturerId = 1, OwnerId = 1},
            new AirplaneSingle { Id = 2, CommonName = "Arrow", ModelNumber = "P28R-200", ManufacturerId = 2, OwnerId = 1 }, 
            new AirplaneSingle { Id = 3, CommonName = "Bonanza", ModelNumber = "BE36", ManufacturerId = 3, OwnerId = 1 }

            );

        modelBuilder.Entity<RotorCraft>().HasData(
            new RotorCraft { Id = 4, CommonName = "R44", ModelNumber = "R44", ManufacturerId = 4, OwnerId = 1 });

        modelBuilder.Entity<AirplaneMulti>().HasData(
            new AirplaneMulti { Id=5, CommonName = "Baron", ModelNumber = "BE58", ManufacturerId = 3, EngineCount = 2, OwnerId = 1},
            new AirplaneMulti { Id =6, CommonName = "Twin Comanche", ModelNumber = "PA30", ManufacturerId = 2, EngineCount = 2, OwnerId = 1 }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention().LogTo(message => Debug.WriteLine(message), LogLevel.Information ).EnableSensitiveDataLogging();
    }

    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {
    }
}