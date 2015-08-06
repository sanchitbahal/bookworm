using System;
using System.Collections.Generic;

namespace Bookworm
{
	public class BookService
	{
		public BookService()
		{
		}

		public List<Book> GetBooks()
		{
			const string image = "monkey";

			return new List<Book> {
				new Book("Book 1", image),
				new Book("Book 2", image),
				new Book("Book 3", image),
				new Book("Book 4", image),
				new Book("Book 5", image)
			};

		}
	}
}

