using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Entity
{
	[Table("device_types")]
	public class DeviceType
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("provider")]
		public string Provider { get; set; }

		[Column("model")]
		public string Model { get; set; }

		public virtual ICollection<Device> Devices { get; set; }
	}
}

