using BookMan.ConsoleApp.DataServices;
using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Models;
using BookMan.ConsoleApp.Views;

namespace BookMan.ConsoleApp.Controllers
{
	/// <summary>
	/// lớp điều khiển, giúp ghép nối dữ liệu sách với giao diện
	/// </summary>
	internal class BookController : ControllerBase
	{
		protected Repository Repository;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="context"></param>
		public BookController(SimpleDataAccess context)
		{
			Repository = new Repository(context);
		}

		/// <summary>
		/// Ghép nối dữ liệu 1 cuốn sách với giao diện hiển thị 1 cuốn sách
		/// </summary>
		/// <param name="id">mã định danh của cuốn sách</param>
		public void Single(int id, string path = "")
		{
			// lấy dữ liệu qua repository
			var book = Repository.Select(id);

			// gọi phương thức Render để thực sự hiển thị ra màn hình
			Render(new BookSingleView(book), path);
		}

		/// <summary>
		/// Kích hoạt chức năng nhập dữ liệu cho 1 cuốn sách
		/// </summary>
		public void Create(Book book = null)
		{
			if (book == null)
			{
				Render(new BookCreateView());
				return;
			}

			Repository.Insert(book);
			Success("Book created!");
		}

		/// <summary>
		/// kích hoạt chức năng hiển thị danh sách
		/// </summary>
		public void List(string path = "")
		{
			// lấy dữ liệu qua repository
			var model = Repository.Select();
			Render(new BookListView(model), path);
		}

		/// <summary>
		/// kích hoạt chức năng cập nhật
		/// </summary>
		/// <param name="id"></param>
		public void Update(int id, Book book = null)
		{
			if (book == null)
			{
				var model = Repository.Select(id);
				var view = new BookUpdateView(model);
				Render(view);
				return;
			}

			Repository.Update(id, book);
			Success("Book updated!");
		}
	}
}