namespace Bookworm
{
	public class Book
	{
		public string Name { get; private set; }

		public string Image { get; private set; }

		public string Author { get; private set; }

		public string AbstractText { get; private set; }

		public Book(string name, string image, string author, string abstractText)
		{
			Name = name;
			Image = image;
			Author = author;
			AbstractText = abstractText;
		}
	}
}

