using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService;

public class AuctionCreatedConsumer(IMapper mapper) : IConsumer<AuctionCreated>
{
    private readonly IMapper _mapper = mapper;

    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("--> Consuming auction created: ", context.Message.Id);

        var item = _mapper.Map<Item>(context.Message);

        if (item.Theme == "Foo") throw new ArgumentException("Cannot sell sets with theme of Foo");

        await item.SaveAsync();
    }
}
