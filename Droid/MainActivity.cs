using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using Android.Content;

namespace Bookworm.Droid
{
	[Activity(Label = "Book Store", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		GridView gridView1;
		BookService service;

		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
		
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			gridView1 = FindViewById<GridView>(Resource.Id.gridView1);

			service = new BookService(new HttpClient());
			var books = await service.GetBooksAsync();
			var adapter = new ImageAdapter(this, books);
			gridView1.Adapter = adapter;

			gridView1.ItemClick += (sender, e) => {
				var bookDetailsActivity = new Intent(this, typeof(BookDetailsActivity));
				var selectedBook = books[e.Position];
				bookDetailsActivity.PutExtra("bookName", selectedBook.Name);
				bookDetailsActivity.PutExtra("bookImage", selectedBook.Image);
				StartActivity(bookDetailsActivity);
			};
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			service.Dispose();
		}
	}
}


