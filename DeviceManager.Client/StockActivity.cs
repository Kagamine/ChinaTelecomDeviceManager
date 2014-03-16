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
using ZXing;
using ZXing.Mobile;

namespace DeviceManager.Client
{
	[Activity (Label = "入库管理")]			
	public class StockActivity : Activity
	{
		public EditText txtCode;
		public Spinner lstDevice;
		string[] lst = { "ZTE N919", "iPhone 5S", "iPhone 5C" };
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Stock);


			lstDevice = FindViewById<Spinner> (Resource.Id.lstDevice);
			var adapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleSpinnerItem, lst);
			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			lstDevice.Adapter = adapter;

			txtCode = FindViewById<EditText> (Resource.Id.txtCode);
			Button btnScan = FindViewById<Button> (Resource.Id.btnScan);
			btnScan.Click += Scan;
		}
		public async void Scan(object sender, EventArgs e)
		{
			MobileBarcodeScanner scanner;
			scanner = new MobileBarcodeScanner(this);
			scanner.UseCustomOverlay = false;
			scanner.TopText = "请保持手机与串码间距离15cm";
			scanner.CancelButtonText = "取消";
			scanner.FlashButtonText = "开灯";
			var result = await scanner.Scan();
			new AlertDialog.Builder(this)
				.SetTitle("提示")
				.SetMessage("串码： " + result.Text + "\n型号： " + lst[lstDevice.SelectedItemPosition] + "\n是否入库？")
				.SetPositiveButton("确定", Scan)
				.SetNeutralButton("取消", delegate 
					{

					})
				.Show();
			this.RunOnUiThread(new Action(()=>
				{
					txtCode.Text = result.Text;
				}));
		}
	}
}

