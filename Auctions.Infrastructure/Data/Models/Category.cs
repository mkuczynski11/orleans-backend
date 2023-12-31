﻿namespace Auctions.Infrastructure.Data.Models
{
    public class Category
    {
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
