using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Net.Http;

namespace Bookworm.iOS
{
	partial class BooksCollectionViewController : UICollectionViewController
	{
		const string bookCellId = "BookCell";
		BookService service = new BookService(new HttpClient());
		List<Book> books = new List<Book>();

		public BooksCollectionViewController(IntPtr handle) : base(handle)
		{
		}

		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();

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

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			var bookDetailsViewController = (BookDetailsViewController)segue.DestinationViewController;
			var indexPath = CollectionView.GetIndexPathsForSelectedItems()[0].Row;
			var selectedItem = books[indexPath];

			bookDetailsViewController.Title = selectedItem.Name;
			bookDetailsViewController.BookName = selectedItem.Name;
			bookDetailsViewController.Image = selectedItem.Image;
		}
	}
}
