using System;
using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Models;

namespace BookMan.ConsoleApp.Views
{
	/// <summary>
	/// Class để hiển thị một cuốn sách, chỉ sử dụng trong dự án (internal)
	/// </summary>
	internal class BookSingleView : ViewBase
	{
		public BookSingleView(Book model) : base(model) { }

		/// <summary>
		/// Thực hiện in thông tin ra màn hình console
		/// </summary>
		public void Render()
		{
			if (Model == null)
			{
				ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
				return;
			}

			ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);

			// chuyển đổi kiểu từ object sang Book, chỉ áp dụng với kiểu class
			var model = Model as Book;
			Console.WriteLine($"Authors:     {model.Authors}");
			Console.WriteLine($"Title:       {model.Title}");
			Console.WriteLine($"Publisher:   {model.Publisher}");
			Console.WriteLine($"Year:        {model.Year}");
			Console.WriteLine($"Edition:     {model.Edition}");
			Console.WriteLine($"Isbn:        {model.Isbn}");
			Console.WriteLine($"Tags:        {model.Tags}");
			Console.WriteLine($"Description: {model.Description}");
			Console.WriteLine($"Rating:      {model.Rating}");
			Console.WriteLine($"Reading:     {model.Reading}");
			Console.WriteLine($"File:        {model.File}");
			Console.WriteLine($"File Name:   {model.FileName}");
		}

	}
}