
using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class DbInitializer
{

    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<AuctionDbContext>());
    }

    private static void SeedData(AuctionDbContext context)
    {
        context.Database.Migrate();

        if (context.Auctions.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var auctions = new List<Auction>()
        {
            // Haunted House
            new Auction
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                Status = Status.Live,
                ReservePrice = 215,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Item = new Item
                {
                    Name = "Haunted House",
                    Theme = "Icons",
                    SetNumber = "10273",
                    PieceCount = 3231,
                    Year = 2020,
                    ImageUrl = "https://images.brickset.com/sets/large/10273-1.jpg?202005130214"
                }
            },
            // Police Station
            new Auction
            {
                Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                Status = Status.Live,
                ReservePrice = 185,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(60),
                Item = new Item
                {
                    Name = "Police Station",
                    Theme = "Icons",
                    SetNumber = "10278",
                    PieceCount = 2923,
                    Year = 2021,
                    ImageUrl = "https://images.brickset.com/sets/large/10278-1.jpg?202011270400"
                }
            },
            // UCS Imperial Star Destroyer
            new Auction
            {
                Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                Status = Status.Live,
                ReservePrice = 790,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(4),
                Item = new Item
                {
                    Name = "Imperial Star Destroyer",
                    Theme = "Star Wars",
                    SetNumber = "75252",
                    PieceCount = 4784,
                    Year = 2019,
                    ImageUrl = "https://images.brickset.com/sets/large/75252-1.jpg?201909050158"
                }
            },
            // Stormtrooper Helmet
            new Auction
            {
                Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
                Status = Status.ReserveNotMet,
                ReservePrice = 100,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(-10),
                Item = new Item
                {
                    Name = "Stormtrooper Helmet",
                    Theme = "Star Wars",
                    SetNumber = "75276",
                    PieceCount = 647,
                    Year = 2020,
                    ImageUrl = "https://images.brickset.com/sets/large/75276-1.jpg?202003170938"
                }
            },
            //City Shopping Street
            new Auction
            {
                Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                Status = Status.Live,
                ReservePrice = 65,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(30),
                Item = new Item
                {
                    Name = "Shopping Street",
                    Theme = "City",
                    SetNumber = "60306",
                    PieceCount = 533,
                    Year = 2021,
                    ImageUrl = "https://images.brickset.com/sets/large/60306-1.jpg?202012050841"
                }
            },
            // City Wildlife Rescue Camp
            new Auction
            {
                Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                Status = Status.Live,
                ReservePrice = 85,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(45),
                Item = new Item
                {
                    Name = "Wildlife Rescue Camp",
                    Theme = "City",
                    SetNumber = "60307",
                    PieceCount = 503,
                    Year = 2021,
                    ImageUrl = "https://images.brickset.com/sets/large/60307-1.jpg?202105031136"
                }
            },
            // Mos Eisley Cantina
            new Auction
            {
                Id = Guid.Parse("47111973-d176-4feb-848d-0ea22641c31a"),
                Status = Status.Live,
                ReservePrice = 375,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(13),
                Item = new Item
                {
                    Name = "Mos Eisley Cantina",
                    Theme = "Star Wars",
                    SetNumber = "75290",
                    PieceCount = 3187,
                    Year = 2020,
                    ImageUrl = "https://images.brickset.com/sets/large/75290-1.jpg?202009091255"
                }
            },
            // Republic Gunship
            new Auction
            {
                Id = Guid.Parse("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                Status = Status.Live,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(19),
                Item = new Item
                {
                    Name = "Republic Gunship",
                    Theme = "Star Wars",
                    SetNumber = "75309",
                    PieceCount = 3292,
                    Year = 2021,
                    ImageUrl = "https://images.brickset.com/sets/large/75309-1.jpg?202101060625"
                }
            },
            // Hogwarts Express
            new Auction
            {
                Id = Guid.Parse("40490065-dac7-46b6-acc4-df507e0d6570"),
                Status = Status.Live,
                ReservePrice = 65,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(20),
                Item = new Item
                {
                    Name = "Hogwarts Express",
                    Theme = "Harry Potter",
                    SetNumber = "75955",
                    PieceCount = 801,
                    Year = 2018,
                    ImageUrl = "https://images.brickset.com/sets/large/75955-1.jpg?201807101202"
                }
            },
            // Ocean Exploration Ship
            new Auction
            {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                Status = Status.Live,
                ReservePrice = 175,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(48),
                Item = new Item
                {
                    Name = "Ocean Exploration Ship",
                    Theme = "City",
                    SetNumber = "60266",
                    PieceCount = 745,
                    Year = 2020,
                    ImageUrl = "https://images.brickset.com/sets/large/60266-1.jpg?202005210857"
                }
            }
        };

        context.AddRange(auctions);

        context.SaveChanges();
    }
}
