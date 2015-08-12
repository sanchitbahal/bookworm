
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

namespace Bookworm.Droid
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

