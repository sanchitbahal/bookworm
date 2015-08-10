using System.Net.Http;
using System.Threading.Tasks;

namespace Bookworm.UnitTests
{

	public class FakeHttpMessageHandler : HttpMessageHandler
	{
		readonly HttpResponseMessage response;

		public FakeHttpMessageHandler(HttpResponseMessage response)
		{
			this.response = response;
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, 
		                                                       System.Threading.CancellationToken cancellationToken)
		{
			var tcs = new TaskCompletionSource<HttpResponseMessage>();

			tcs.SetResult(response);

			return tcs.Task;
		}
	}
}
