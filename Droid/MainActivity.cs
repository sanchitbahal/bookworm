
using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookworm.Droid
{
	[Activity(Label = "Bookworm.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private GridView gridView1;
		private BookService service;

		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
		
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			gridView1 = FindViewById<GridView>(Resource.Id.gridView1);

			service = new BookService(new HttpClient());
			var adapter = new ImageAdapter(this, await service.GetBooksAsync());
			gridView1.Adapter = adapter;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			service.Dispose();
		}
	}
}


