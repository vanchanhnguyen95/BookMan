using System;
using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Models;

namespace BookMan.ConsoleApp.Views
{
	/// <summary>
	/// class để hiển thị danh sách Book
	/// </summary>
	internal class BookListView
	{
		protected Book[] Book; // mảng của các object kiểu Book

		public BookListView(Book[] books)
		{
			Book = books;
		}

		/// <summary>
		/// in danh sách ra console
		/// </summary>
		public void Render()
		{
			if (Book.Length == 0)
			{
				ViewHelp.WriteLine("No book found!", ConsoleColor.Yellow);
				return;
			}
			ViewHelp.WriteLine("THE BOOK LIST", ConsoleColor.Green);
			int i = 0;
			while (i < Book.Length)
			{
				ViewHelp.Write($"[{Book[i].Id}]", ConsoleColor.Yellow);
				ViewHelp.WriteLine($" {Book[i].Title}", Book[i].Reading ? ConsoleColor.Cyan : ConsoleColor.White);
				i++;
			}
		}

		/// <summary>
		/// RenderToFile
		/// </summary>
		/// <param name="path"></param>
		public void RenderToFile(string path)
		{
			ViewHelp.WriteLine($"Saving data to file '{path}'");
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(Book);
			System.IO.File.WriteAllText(path, json);
			ViewHelp.WriteLine("Done!");
		}
	}
}