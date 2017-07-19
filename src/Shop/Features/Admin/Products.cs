﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Features.Product;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Data.Extensions;

namespace Shop.Features.Admin
{
    public class Products
    {
        public class Query : IRequest<Index.Model>
        {
        }

        public class Model
        {
            public List<Index.Model.Product> Products { get; set; }

            public class Product
            {
                public string ProductReference { get; set; }
                public string ProductName { get; set; }
                public string ProductShortDescription { get; set; }
                public string Price { get; set; }
                public string CoverImageUrl { get; set; }
            }
        }

        public class Handler : IAsyncRequestHandler<Index.Query, Index.Model>
        {
            private readonly ShopContext _db;

            public Handler(ShopContext db)
            {
                _db = db;
            }

            public async Task<Index.Model> Handle(Index.Query message)
            {
                var products = await _db.Products
                    .Active()
                    .Where(p => p.AvailableForOrder)
                    .OrderBy(p => p.PricePreTax)
                    .ToListAsync();

                var viewModel = new Index.Model
                {
                    Products = products.Select(Mapper.Map<Core.Entites.Product, Index.Model.Product>).ToList()
                };

                return viewModel;
            }
        }
    }
}