using System.ComponentModel.DataAnnotations.Schema;
using AuctionService.Entities;

namespace AuctionService.Entities
{
    [Table("Items")]
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public int Year { get; set; }
        public string SetNumber { get; set; }
        public int PieceCount { get; set; }
        public string ImageUrl { get; set; }

        //nav properties

        public Auction Auction { get; set; }
        public Guid AuctionId { get; set; }
    }
}