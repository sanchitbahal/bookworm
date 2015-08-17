using NUnit.Framework;
using System.Threading.Tasks;
using System.Net.Http;

namespace Bookworm.UnitTests
{
	[TestFixture]
	public class BookServiceTest
	{
		[Test]
		public void ShouldReturnBookList()
		{
			var fakeResponse = new HttpResponseMessage();
			fakeResponse.Content = new StringContent("[{\"name\":\"Book 1\"},{\"name\":\"Book 2\"}]");
			var client = new HttpClient(new FakeHttpMessageHandler(fakeResponse));

			var service = new BookService(client);
			var response = service.GetBooksAsync();

			var books = response.Result;

			Assert.That(books.Count, Is.EqualTo(2));
			Assert.That(books[0].Name, Is.EqualTo("Book 1"));
			Assert.That(books[1].Name, Is.EqualTo("Book 2"));
		}
	}
}

