namespace Bookworm
{
	public class Book
	{
		public string Name { get; private set; }

		public string Image { get; private set; }

		public Book(string name, string image)
		{
			Name = name;
			Image = image;
		}
	}
}

