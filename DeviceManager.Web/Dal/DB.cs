using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DeviceManager.Entity;

namespace DeviceManager.Web
{
	public class DB : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<DeviceType> DeviceTypes { get; set; }
		public DbSet<Device> Devices { get; set; }
		public DbSet<Scan> Scans { get; set; }

		public DB () : base("mysqldb")
		{
		}

		protected override void OnModelCreating (DbModelBuilder modelBuilder)
		{
			base.OnModelCreating (modelBuilder);
			modelBuilder.Entity<DeviceType> ()
				.HasMany (dt => dt.Devices)
				.WithRequired (d => d.DeviceType);
		}
	}
}
