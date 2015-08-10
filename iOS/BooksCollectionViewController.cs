using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Net.Http;

namespace Bookworm.iOS
{
	partial class BooksCollectionViewController : UICollectionViewController
	{
		static NSString bookCellId = new NSString("BookCell");
		private BookService service = new BookService(new HttpClient());
		private List<Book> books = new List<Book>();

		public BooksCollectionViewController(UICollectionViewFlowLayout layout) : base(layout)
		{
		}

		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();

			CollectionView.RegisterClassForCell(typeof(BookCell), bookCellId);

			books = await service.GetBooksAsync();
			CollectionView.ReloadData();
		}

		public override void ViewDidUnload()
		{
			service.Dispose();
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
