using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DeviceManager.Client
{
	[Activity (Label = "中国电信终端管理", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			Button btnAuth = FindViewById<Button>(Resource.Id.btnAuth);
			btnAuth.Click += (object sender, EventArgs e) => 
			{
				EditText txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
				EditText txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
				var result = Bll.HttpHelper.HttpGet
				(
					String.Format
					(
						Bll.StaticVariables.HttpHost + "Login.aspx?uid={0}&pwd={1}", 
						txtUsername.Text, 
						txtPassword.Text
					)
				);
				if(result != "")
				{
					new AlertDialog.Builder(this).SetTitle("错误").SetMessage("您的用户名或密码不正确，请重试！").Show();
				}
				else
				{
					StartActivity(typeof(StockActivity));
				}
			};
		}
	}
}


