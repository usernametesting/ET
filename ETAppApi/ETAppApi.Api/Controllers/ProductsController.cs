using ETAppApi.Application.Abtractions;
using ETAppApi.Application.Repostories;
using ETAppApi.Application.ViewModels;
using ETAppApi.Domain.Entities;
using ETAppApi.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ETAppApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //public IProductService ProductService { get; }
        public IReadRepostory<Product> readRep { get; }
        public IWriteRepostory<Product> writeRep { get; }
        public ETAppContext Context { get; }

        public ProductsController(IReadRepostory<Product> rep, ETAppContext context, IWriteRepostory<Product> writeRep)
        {
            //ProductService = productService;
            this.readRep = rep;
            this.writeRep = writeRep;
            Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var res = await readRep.GetAll().ToListAsync();
            return Ok(res);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await readRep.GetById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatProduct_VM model)
        {
            await writeRep.AddAsync(new Product()
            {
                Name = model.Name,
            });
            await writeRep.SaveAsync();
            return Ok(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProduct_VM model)
        {
            var product = (await readRep.GetById(model.Id));
            product.Name = model.Name;
            await readRep.SaveAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletee(int id)
        {
            await writeRep.Remove(await readRep.GetById(id));
            await writeRep.SaveAsync();
            return Ok();
        }
    }
}
