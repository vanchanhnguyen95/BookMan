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
		public BookController(IDataAccess context)
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

		/// <summary>
		/// kích hoạt chức năng Delete
		/// </summary>
		/// <param name="id"></param>
		/// <param name="process"></param>
		public void Delete(int id, bool process = false)
		{
			if (process == false)
			{
				var b = Repository.Select(id);
				Confirm($"Do you want to delete this book ({b.Title})? ", $"do delete?id={b.Id}");
			}
			else
			{
				Repository.Delete(id);
				Success("Book deleted!");
			}
		}

		/// <summary>
		/// kích hoạt chức năng Filter
		/// </summary>
		/// <param name="key"></param>
		public void Filter(string key)
		{
			var model = Repository.Select(key);
			if (model.Length == 0)
				Inform("No matched book found!");
			else
				Render(new BookListView(model));
		}

		/// <summary>
		/// Mark
		/// </summary>
		/// <param name="id"></param>
		/// <param name="read"></param>
		public void Mark(int id, bool read = true)
		{
			var book = Repository.Select(id);
			if (book == null)
			{
				Error("Book not found!");
				return;
			}
			book.Reading = read;
			Success($"The book '{book.Title}' are marked as { (read ? "READ" : "UNREAD")}");
		}

		/// <summary>
		/// ShowMarks
		/// </summary>
		public void ShowMarks()
		{
			var model = Repository.SelectMarked();
			var view = new BookListView(model);
			Render(view);
		}

		/// <summary>
		/// Stats
		/// </summary>
		public void Stats()
		{
			var model = Repository.Stats();
			var view = new BookStatsView(model);
			Render(view);
		}
	}
}