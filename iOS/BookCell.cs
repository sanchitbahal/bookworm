using Foundation;
using System;
using UIKit;
using CoreGraphics;

namespace Bookworm.iOS
{
	partial class BookCell : UICollectionViewCell
	{
		private UILabel lblBookName { get; set; }

		private UIImageView imgBook { get; set; }

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

		[Export("initWithFrame:")]
		public BookCell(CGRect frame) : base(frame)
		{			
			ContentView.BackgroundColor = UIColor.White;

			imgBook = new UIImageView(UIImage.FromBundle("placeholder.png"));
			imgBook.Center = ContentView.Center;

			lblBookName = new UILabel(new CGRect(0, ContentView.Frame.Bottom - 55, frame.Width, frame.Height));
			lblBookName.AdjustsFontSizeToFitWidth = true;
			lblBookName.TextAlignment = UITextAlignment.Center;

			ContentView.AddSubviews(imgBook, lblBookName);	
		}
	}
}
