using System;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Entity
{
	[Table("devices")]
	public class Device
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("device_type_id")]
		[ForeignKey("DeviceType")]
		public int DeviceTypeID { get; set; }

		public virtual DeviceType DeviceType { get; set; }
	}
}

