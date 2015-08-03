using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Bookworm.Droid
{
	[Activity(Label = "Bookworm.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private List<string> bookNames;
		private ListView listView1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
		
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
//			listView1 = FindViewById<ListView> (Resource.Id.Equals ("listView1"));
			listView1 = FindViewById<ListView> (Resource.Id.listView1);

			bookNames = new List<string>();
			bookNames.Add("Lean In by Sheryl Sandberg");
			bookNames.Add("The Untethered Soul by Michael Singer");

			ArrayAdapter<string> adapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, bookNames);
			listView1.Adapter = adapter;


		}
	}
}


