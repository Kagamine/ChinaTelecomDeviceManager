using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Entity
{
	[Table("scans")]
	public class Scan
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("device_id")]
		public int DeviceID { get; set; }

		[Column("user_id")]
		[ForeignKey("User")]
		public int UserID { get; set; }

		public virtual User User { get; set; }

		[Column("type")]
		public int TypeAsInt { get; set; }

		[NotMapped]
		public ScanType Type 
		{
			get { return (ScanType)TypeAsInt; }
			set { TypeAsInt = (int)value; }
		}

		[Column("time")]
		public DateTime Time { get; set; }
	}

	public enum ScanType { Stock, Delivery, TakeOver, Selled, Repair };
}

