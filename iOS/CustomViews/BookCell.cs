using System;
using UIKit;

namespace Bookworm.iOS.CustomViews
{
	partial class BookCell : UICollectionViewCell
	{
		public BookCell(IntPtr handle) : base(handle)
		{
		}

		public String Image {
			set { 
				imgBook.Image = UIImage.FromBundle(value); 
				SetNeedsDisplay();
			}
		}
	}
}
