using System;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Entity
{
	[Table("users")]
	public class User
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("username")]
		public string Username { get; set; }

		[Column("password")]
		public string Password { get; set; }

		[Column("display_name")]
		public string DisplayName{ get; set; }

		[Column("access_token")]
		public string AccessToken { get; set; }

		[Column("role")]
		[ForeignKey("Role")]
		public int RoleAsInt{ get; set;}

		[NotMapped]
		public UserRole Role 
		{ 
			get{ return (UserRole)RoleAsInt; } 
			set{ RoleAsInt = (int)value; } 
		}
	}

	public enum UserRole { StockManager, Seller, Root }
}