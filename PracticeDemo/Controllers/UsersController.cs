using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeDemo.Data;
using PracticeDemo.Models;

namespace PracticeDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShopDbContext shopDbContext;

        public UsersController(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        [HttpPost]
        [Route("/add")]
        public async Task<IActionResult> CreateUser(User user)
        {
            await shopDbContext.Users.AddAsync(user);
            await shopDbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet]
        [Route("/users")]
        public  async Task<IActionResult> GetUsers()
        {
            List<User>users=await shopDbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("/user/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute]int id)
        {
         User user=  await shopDbContext.Users.FindAsync(id);
         if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }

        }

        [HttpPost]
        [Route("/update/{id}")]
        public async Task <IActionResult> UpdateUser([FromRoute] int id,User updatedUSer)
        {
            User ExistingUser= await shopDbContext.Users.FindAsync(id);
            if (ExistingUser != null)
            {
                ExistingUser.Name = updatedUSer.Name;
                ExistingUser.City= updatedUSer.City;
                ExistingUser.Email= updatedUSer.Email;
                shopDbContext.Users.Update(ExistingUser);
                shopDbContext.SaveChanges();
                return Ok(ExistingUser);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]int id)
        {
            User Founduser = await shopDbContext.Users.FindAsync(id);
            if (Founduser != null)
            {
                shopDbContext.Remove(Founduser);
                shopDbContext.SaveChanges();
                return Ok(id+"Deleted");
            }
            else 
            {
                return NotFound(); 
            }
        }
    }
}
