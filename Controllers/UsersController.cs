using Microsoft.AspNetCore.Mvc;
using SmartOffice.Issat.API.Models;
using SmartOffice.Issat.API.Services;

namespace SmartOffice.Issat.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _usersService;

        public UsersController(UserService usersService) =>
            _usersService = usersService;


        [HttpGet]
        public async Task<List<UserDefinition>> Get() =>
        await _usersService.GetAsync();


        [HttpPost ("isExist")]
        public async Task<bool> isExist( UserDefinition user) 
       
        {
          
               var result = await _usersService.GetUserAsync(user);

               if (result == null) return false;

              return true;
           
          


           
        }
      

        [HttpPut]
        public async Task<ActionResult<UserDefinition>> AddUser(UserDefinition user)
        {
           await _usersService.CreateAsync(user);
            
            return  user;
        }
        /* [HttpPost]
      public async Task<IActionResult> Post(User user) {
            await _usersService.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
                }*/
        /*   [HttpPut("{id:length(24)}")]
         public async Task<IActionResult> Update(string id, User updatedUser)
           {
               var user = await _usersService.GetAsync(id);

               if (user is null)
               {
                   return NotFound();
               }

               updatedUser.Id = user.Id;

               await _usersService.UpdateAsync(id, updatedUser);

               return NoContent();
           }*/

    }
}
