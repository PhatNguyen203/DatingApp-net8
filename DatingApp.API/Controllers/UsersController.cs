using DatingApp.API.Data;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController(DataContext context) : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
		{ 
			var users = await context.AppUsers.ToListAsync();
			return Ok(users);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<AppUser>> GetById(int id)
		{ 
			var user = await context.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
			if (user == null) 
			{
				return NotFound("User not found");
			}
			return Ok(user);
		}
	}
}
