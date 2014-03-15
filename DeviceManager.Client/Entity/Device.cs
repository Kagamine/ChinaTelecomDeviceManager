using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DeviceManager.Client.Entity
{
	public class Device
	{
		public int ID { get; set; }
		public string Provider { get; set; }
		public string Model { get; set; }
	}
}

