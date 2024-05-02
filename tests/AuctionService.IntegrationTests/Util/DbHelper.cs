using AuctionService.Data;
using AuctionService.Entities;

namespace AuctionService.IntegrationTests;

public static class DbHelper
{
    public static void InitDbForTests(AuctionDbContext db)
    {
        db.Auctions.AddRange(GetAuctionsForTest());
        db.SaveChanges();
    }

    public static void ReinitDbForTests(AuctionDbContext db)
    {
        db.Auctions.RemoveRange(db.Auctions);
        db.SaveChanges();
        InitDbForTests(db);
    }

    private static List<Auction> GetAuctionsForTest()
    {
        return new List<Auction>
        {
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
            }
        };
    }
}
