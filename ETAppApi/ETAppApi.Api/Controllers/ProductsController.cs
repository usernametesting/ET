using ETAppApi.Application.Abtractions;
using ETAppApi.Application.Repostories;
using ETAppApi.Domain.Entities;
using ETAppApi.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //public IProductService ProductService { get; }
        public IReadRepostory<Product> rep { get; }
        public ETAppContext Context { get; }

        public ProductsController(IReadRepostory<Product> rep,ETAppContext context)
        {
            //ProductService = productService;
            this.rep = rep;
            Context = context;
        }

        [HttpGet]
        public  async Task<IActionResult> GetProducts()
        {
            var res = await rep.GetAll().ToListAsync();
            return Ok(res);
        }
    }
}
