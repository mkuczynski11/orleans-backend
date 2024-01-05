using Auctions.Infrastructure.Data.Models;

namespace Auctions.Infrastructure.Data;

internal static class Seed
{
    internal static Category[] Categories = {
        new(new Guid("a5ae013c-14a1-4c2d-a731-47fbbd0ba527"), "Sport"),
        new(new Guid("5f923017-86da-4793-9332-7b74197acc51"), "AGD"),
        new(new Guid("2f07481d-5f3f-4bbf-923f-60e62fcfe4e7"), "Home"),
        new(new Guid("7322b307-1431-4203-bda8-9161b60c45d0"), "Electronic")
    };

    // internal static Item[] Items = {

    // }

    // internal static User[] Users = {

    // }
}