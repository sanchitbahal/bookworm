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
		private BookService service = new BookService();
		private List<Book> books;

		public BooksCollectionViewController(UICollectionViewFlowLayout layout) : base(layout)
		{
			books = service.GetBooks();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			CollectionView.RegisterClassForCell(typeof(BookCell), bookCellId);
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var bookCell = (BookCell)collectionView.DequeueReusableCell(bookCellId, indexPath);

			var selectedBook = books[indexPath.Row];
			bookCell.BookName = selectedBook.Name;
			bookCell.Image = selectedBook.Image;

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
