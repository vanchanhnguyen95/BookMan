﻿using System;
using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Models;

namespace BookMan.ConsoleApp.Views
{
	/// <summary>
	/// Class để hiển thị một cuốn sách, chỉ sử dụng trong dự án (internal)
	/// </summary>
	internal class BookSingleView
	{
		// Biến này để lưu trữ thông tin cuốn sách đang cần hiển thị
		protected Book Book;

		/// <summary>
		/// Đây là hàm tạo, sẽ được gọi đầu tiên khi tạo object
		/// </summary>
		/// <param name="book">cuốn sách cụ thể sẽ được hiển thị</param>
		public BookSingleView(Book book)
		{
			// Chuyển dữ liệu từ tham số sang biến thành viên để sử dụng trong toàn class
			Book = book;
		}

		/// <summary>
		/// Thực hiện in thông tin ra màn hình console
		/// </summary>
		public void Render()
		{
			// Kiếm tra xem object có dữ liệu không
			if (Book == null)
			{
				// sử dụng phương thức tĩnh WriteLine của lớp ViewHelp
				ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
				return;
			}

			// Hiển thị thông tin ra màn hình
			// sử dụng phương thức tĩnh WriteLine của lớp ViewHelp
			ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);

			/* các dòng dưới đây viết ra thông tin cụ thể theo từng dòng
			* sử dụng cách tạo xâu kiểu "interpolation"
			* và dùng dấu cách để căn chỉnh tạo thẩm mỹ
			*/
			Console.WriteLine($"Authors:		{Book.Authors}");
			Console.WriteLine($"Title:			{Book.Title}");
			Console.WriteLine($"Publisher:		{Book.Publisher}");
			Console.WriteLine($"Year:			{Book.Year}");
			Console.WriteLine($"Edition:		{Book.Edition}");
			Console.WriteLine($"Isbn:			{Book.Isbn}");
			Console.WriteLine($"Tags:			{Book.Tags}");
			Console.WriteLine($"Description:	{Book.Description}");
			Console.WriteLine($"Rating:			{Book.Rating}");
			Console.WriteLine($"Reading:		{Book.Reading}");
			Console.WriteLine($"File:			{Book.File}");
			Console.WriteLine($"FileName:		{Book.FileName}");
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