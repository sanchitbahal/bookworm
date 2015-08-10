using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace Bookworm
{
	public class BookService : IDisposable
	{
		readonly HttpClient httpClient;

		public BookService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
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

		public async Task<List<Book>> GetBooksAsync()
		{
			var json = await httpClient.GetStringAsync("http://localhost:3000/books");
			return JsonConvert.DeserializeObject<List<Book>>(json);
		}

		#region IDisposable implementation

		public void Dispose()
		{
			httpClient.Dispose();
		}

		#endregion
	}
}

