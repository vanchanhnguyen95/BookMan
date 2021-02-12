using BookMan.ConsoleApp.Models;
using BookMan.ConsoleApp.Views;

namespace BookMan.ConsoleApp.Controllers
{
	
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

		/// <summary>
		/// kích hoạt chức năng cập nhật
		/// </summary>
		/// <param name="id"></param>
		public void Update(int id)
		{
			var book = new Book();
			var view = new BookUpdateView(book);
			view.Render();
		}

		/// <summary>
		/// kích hoạt chức năng hiển thị danh sách
		/// </summary>
		public void List()
		{
			/* khai báo và khởi tạo một mảng, mỗi phần tử thuộc kiểu Book.
			* Lệnh dưới dây khai báo và khởi tạo 1 mảng gồm 6 phần tử,
			* mỗi phần tử thuộc kiểu Book.
			* Do Book là class, mỗi phần tử của mảng cũng phải được khởi tạo
			* sử dụng từ khóa new, tương tự như khởi tạo một object bình thường
			*/
			Book[] book = new Book[]
			{
				new Book{Id=1, Title = "A new book 1"},
				new Book{Id=2, Title = "A new book 2"},
				new Book{Id=3, Title = "A new book 3"},
				new Book{Id=4, Title = "A new book 4"},
				new Book{Id=5, Title = "A new book 5"},
				new Book{Id=6, Title = "A new book 6"},
			};

			BookListView view = new BookListView(book);
			view.Render();
		}
	}
}