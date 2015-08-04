using System;
using Android.Widget;
using Android.Content;
using Android.Views;

namespace Bookworm.Droid
{
	public class ImageAdapter : BaseAdapter
	{
		private readonly Context context;

		// references to our book names
		private readonly string[] books = {
			"Book 1",
			"Book 2",
			"Book 3",
			"Book 4",
			"Book 5"
		};


		public ImageAdapter(Context c)
		{
			context = c;
		}

		public override int Count
		{
			get { return books.Length; }
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return 0;
		}
			
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View customView;
			if (convertView == null)
			{
				LayoutInflater inflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
				
				customView = inflater.Inflate (Resource.Layout.BookCell, null);
				
				var imageView = customView.FindViewById<ImageView>(Resource.Id.imageView1);
				imageView.SetImageResource(Resource.Drawable.Icon);
//				imageView.LayoutParameters = new AbsListView.LayoutParams(85, 85);
//				imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
				imageView.SetPadding(8, 8, 8, 8);

				var textView = customView.FindViewById<TextView>(Resource.Id.textView1);
				textView.Text = books [position];
			}
			else
			{
				customView = (View) convertView;
			}

			return customView;
		}

	}
}

