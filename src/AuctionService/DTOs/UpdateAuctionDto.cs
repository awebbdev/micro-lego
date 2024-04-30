namespace AuctionService.DTOs;

public class UpdateAuctionDto
{
    public string Name { get; set; }
    public string Theme { get; set; }
    public int? Year { get; set; }
    public string SetNumber { get; set; }
    public int? PieceCount { get; set; }

}
