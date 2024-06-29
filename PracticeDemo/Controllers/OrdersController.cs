using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeDemo.Data;
using PracticeDemo.Models;

namespace PracticeDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ShopDbContext shopDbContext;
        public OrdersController(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        [HttpPost]
        [Route("/addproduct")]
        public async Task<IActionResult> InsertProduct(Order order)
        {
            await shopDbContext.Orders.AddAsync(order);
            await shopDbContext.SaveChangesAsync();
            return Ok(order);
        }

        [HttpGet]
        [Route("/allproduct")]
        public async Task<IActionResult> GetProducts()
        {
            List<Order> orders = await shopDbContext.Orders.ToListAsync();
            return Ok(orders);
        }


    }
}
