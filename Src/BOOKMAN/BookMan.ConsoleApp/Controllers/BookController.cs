using BookMan.ConsoleApp.DataServices;
using BookMan.ConsoleApp.Models;
using BookMan.ConsoleApp.Views;

namespace BookMan.ConsoleApp.Controllers
{
	/// <summary>
	/// lớp điều khiển, giúp ghép nối dữ liệu sách với giao diện
	/// </summary>
	internal class BookController
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
		public void Single(int id)
		{
			// lấy dữ liệu qua repository
			var book = Repository.Select(id);

			// Khởi tạo view
			BookSingleView view = new BookSingleView(book);

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
		/// kích hoạt chức năng hiển thị danh sách
		/// </summary>
		public void List()
		{
			// lấy dữ liệu qua repository
			var model = Repository.Select();

			// khởi tạo view
			BookListView view = new BookListView(model);
			view.Render();
		}

		/// <summary>
		/// kích hoạt chức năng cập nhật
		/// </summary>
		/// <param name="id"></param>
		public void Update(int id)
		{
			// lấy dữ liệu qua repository
			var model = Repository.Select(id);
			var view = new BookUpdateView(model);
			view.Render();
		}
	}
}