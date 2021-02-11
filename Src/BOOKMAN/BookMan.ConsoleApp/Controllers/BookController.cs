﻿
namespace BookMan.ConsoleApp.Controllers
{
	using Models;
	using Views;
	class BookController
	{
		/// <summary>
		/// Ghép nối dữ liệu 1 cuốn sách với giao diện hiển thị 1 cuốn sách
		/// </summary>
		/// <param name="id">mã định danh của cuốn sách</param>
		public void Single(int id)
		{
			// Khởi tạo object với property
			Book model = new Book
			{
				Id = 1,
				Authors = "Adam Freeman",
				Title = "Expert ASP.NET Web API 2 for MVC Developers (The Expert's Voice in .NET)",
				Publisher = "Apress",
				Year = 2014,
				Tags = "c#, asp.net, mvc",
				Description = "Expert insight and understanding of how to create, customize, and deploy complex, flexible, and robust HTTP web services",
				Rating = 5,
				Reading = true
			};

			// Khởi tạo view
			BookSingleView view = new BookSingleView(model);

			// Gọi phương thức Render để thực sự hiển thị ra màn hình
			view.Render();
		}

		/// <summary>
		/// Kích hoạt chức năng nhập dữ liệu cho 1 cuốn sách
		/// </summary>
		public void Create()
		{
			// Khởi tạo object
			BookCreateView view = new BookCreateView();

			// Hiển thị ra màn hình
			view.Render();
		}
	}
}