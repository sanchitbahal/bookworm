using System;
using UIKit;

namespace Bookworm.iOS.CustomViews
{
	partial class BookCell : UICollectionViewCell
	{
		public BookCell(IntPtr handle) : base(handle)
		{
		}

		public String BookName {
			get { return lblBookName.Text; }
			set { 
				lblBookName.Text = value; 
				SetNeedsDisplay();
			}
		}

		public String Image {
			set { 
				imgBook.Image = UIImage.FromBundle(value); 
				SetNeedsDisplay();
			}
		}
	}
}
