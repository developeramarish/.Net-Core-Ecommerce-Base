using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Data.Extensions;

namespace Shop.Features.Product
{
    public class Index
    {
        public class Query : IRequest<Model>
        {
        }
        
        public class Model
        {
            public List<Product> Products { get; set; }

            public class Product
            {
                public string ProductReference { get; set; }
                public string ProductName { get; set; }
                public string ProductShortDescription { get; set; }
                public string Price { get; set; }
                public string CoverImageUrl { get; set; }
            }
        }

        public class Handler : IAsyncRequestHandler<Query, Model>
        {
            private readonly ShopContext _db;

            public Handler(ShopContext db)
            {
                _db = db;
            }

            public async Task<Model> Handle(Query message)
            {
                var products = await _db.Products
                    .Active()
                    .Where(p => p.AvailableForOrder)
                    .OrderBy(p => p.Price)
                    .ToListAsync();
                
                var viewModel = new Model
                {
                    Products = products.Select(Mapper.Map<Core.Entites.Product, Model.Product>).ToList()
                };

                return viewModel;
            }
        }

    }
}