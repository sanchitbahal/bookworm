using System;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Text.Method;

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
			var bookAuthor = Intent.GetStringExtra("bookAuthor");
			var bookAbstract = Intent.GetStringExtra("bookAbstract");

			var imgBook = FindViewById<ImageView>(Resource.Id.imgBook);
			var txtBookName = FindViewById<TextView>(Resource.Id.txtBookName);
			var txtBookAuthor = FindViewById<TextView>(Resource.Id.txtBookAuthor);
			var txtBookAbstract = FindViewById<TextView>(Resource.Id.txtBookAbstract);
			txtBookAbstract.MovementMethod = new ScrollingMovementMethod();

			imgBook.SetPadding(8, 8, 8, 8);
			imgBook.SetImageResource((int)typeof(Resource.Drawable).GetField(bookImage).GetValue(null));

			txtBookName.Text = bookName;
			txtBookAbstract.Text = bookAbstract;
			txtBookAuthor.Text = bookAuthor;
			txtBookAbstract.Text = bookAbstract;
			Title = bookName;
		}
	}
}

