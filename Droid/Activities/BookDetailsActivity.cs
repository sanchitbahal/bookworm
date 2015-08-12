using System;

using Android.App;
using Android.OS;
using Android.Widget;

namespace Bookworm.Droid.Activities
{
	[Activity]			
	public class BookDetailsActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.BookDetails);

			var bookName = Intent.GetStringExtra("bookName");
			var bookImage = Intent.GetStringExtra("bookImage");

			var imgBook = FindViewById<ImageView>(Resource.Id.imgBook);
			var txtBookName = FindViewById<TextView>(Resource.Id.txtBookName);

			imgBook.SetPadding(8, 8, 8, 8);
			imgBook.SetImageResource((int)typeof(Resource.Drawable).GetField(bookImage).GetValue(null));

			txtBookName.Text = bookName;
			Title = bookName;
		}
	}
}

