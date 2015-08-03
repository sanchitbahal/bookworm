using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Bookworm.iOS
{
	partial class BooksCollectionViewController : UICollectionViewController
	{
		static NSString bookCellId = new NSString("BookCell");
		private List<string> books;

		public BooksCollectionViewController(UICollectionViewFlowLayout layout) : base(layout)
		{
			books = new List<string>() { "Book 1", "Book 2", "Book 3", "Book 4", "Book 5", };
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			CollectionView.RegisterClassForCell(typeof(BookCell), bookCellId);
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var bookCell = (BookCell)collectionView.DequeueReusableCell(bookCellId, indexPath);
			bookCell.BookName = books[indexPath.Row];
			bookCell.Image = "monkey.png";
			return bookCell;
		}

		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return books.Count;
		}
	}
}
