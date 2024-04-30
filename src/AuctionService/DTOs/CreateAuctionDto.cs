using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTOs;

public class CreateAuctionDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Theme { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string SetNumber { get; set; }
    [Required]
    public int PieceCount { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public int ReservePrice { get; set; }
    [Required]
    public DateTime AuctionEnd { get; set; }
}
