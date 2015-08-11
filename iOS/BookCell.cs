using Foundation;
using System;
using UIKit;
using CoreGraphics;

namespace Bookworm.iOS
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
