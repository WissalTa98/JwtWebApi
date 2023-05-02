namespace JwtWebApi.Dto
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string Username { get; set; } = string.Empty;
		public byte[] PasswordHash { get; set; } = new byte[32];
		public byte[] PasswordSalt { get; set; } = new byte[32];
		public DateTime? VerifiedAt { get; set; }
		public string? PasswordResetToken { get; set; }
		public DateTime? ResetTokenExpires { get; set; }

		public string RefreshToken { get; set; } = string.Empty;
		public DateTime TokenCreated { get; set; }
		public DateTime TokenExpires { get; set; }


	}
}
