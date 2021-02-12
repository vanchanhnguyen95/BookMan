using System;
using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Models;

namespace BookMan.ConsoleApp.Views
{
	/// <summary>
	/// class để hiển thị danh sách Book
	/// </summary>
	internal class BookListView : ViewBase<Book[]>
	{
		public BookListView(Book[] model) : base(model) { }

		/// <summary>
		/// in danh sách ra console
		/// </summary>
		public override void Render()
		{
			if (((Book[])Model).Length == 0)
			{
				ViewHelp.WriteLine("No book found!", ConsoleColor.Yellow);
				return;
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("THE BOOK LIST");
			Console.ForegroundColor = ConsoleColor.Yellow;

			foreach (Book b in Model as Book[])
			{
				ViewHelp.Write($"[{b.Id}]", ConsoleColor.Yellow);
				ViewHelp.WriteLine($" {b.Title}", b.Reading ? ConsoleColor.Cyan : ConsoleColor.White);
			}

			ViewHelp.WriteLine($"{Model.Length} item(s)", ConsoleColor.Green);
		}

	}
}