using System.Collections.Generic;
using MediatR;

namespace Shop.Features.Product
{
    public class Index
    {
        public class Query : IRequest<Model>
        {
        }
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

            public Media CoverImage { get; set; }
        }

        public class Media
        {
            public string Url { get; set; }
        }
    }
}