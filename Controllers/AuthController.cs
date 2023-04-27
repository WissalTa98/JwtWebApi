using JwtWebApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace JwtWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		public static User user = new User();

		//method to register user
		[HttpPost("register")]
		public async Task<ActionResult<User>> Register(UserDto request)
		{
			CreatePaswwordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
			user.Username = request.Username;
			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			return Ok(user);
		}

		//method to login user
		[HttpPost("login")]
		public async Task<ActionResult<string>> Login(UserDto request)
		{
			if(user.Username == request.Username)
			{
				return BadRequest("User not found.");
			}
			return Ok("My Token!");
		}


		private void CreatePaswwordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			//cryptography algorithm
			using(var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}


	}
}
