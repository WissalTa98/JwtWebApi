using System.Security.Claims;

namespace JwtWebApi.services.UserService
{
	public class UserService : IUserService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserService(IHttpContextAccessor httpContextAccessor) {
			_httpContextAccessor = httpContextAccessor;
		}
		string IUserService.GetMyName()
		{
			var result = string.Empty;
			if(_httpContextAccessor.HttpContext != null) {
				result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
			}
			return result;
		}
	}
}
