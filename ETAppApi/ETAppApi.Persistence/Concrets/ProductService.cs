using ETAppApi.Application.Abtractions;
using ETAppApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETAppApi.Persistence.Concrets
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
            => new()
            {
                new(){Id = 1,CreatedDate = DateTime.Now,Name="pro1"},
                new(){Id = 2,CreatedDate = DateTime.Now,Name="pro2"},
                new(){Id = 3,CreatedDate = DateTime.Now,Name="pro3"},
            };
    }
}
