using System;
using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Models;

namespace BookMan.ConsoleApp.Views
{
	class BookUpdateView
	{
		protected Book Book;
		public BookUpdateView(Book book)
		{
			Book = book;
		}

		public void Render()
		{
			//sử dụng phương thức static
			ViewHelp.WriteLine("UPDATE BOOK INFORMATION", ConsoleColor.Green);

			ConsoleColor labelColor = ConsoleColor.Magenta, valueColor = ConsoleColor.White;

			// hiển thị giá trị cũ
			//sử dụng phương thức static
			ViewHelp.Write("Authors: ", labelColor);
			//sử dụng phương thức static
			ViewHelp.WriteLine(Book.Authors, valueColor);

			// yêu cầu nhập giá trị mới
			//sử dụng phương thức static
			ViewHelp.Write("New value: ", labelColor);

			// đọc giá trị mới
			var str = Console.ReadLine();
			/* nếu người dùng ấn enter luôn (bỏ qua nhập dữ liệu) thì lấy lại giá trị cũ
				* của trường Authors gán cho biến cục bộ authors.
				* Nếu người dùng nhập giá trị mới thì biến cục bộ authors nhận giá trị này.
				* Giá trị của biến authors về sau sẽ chuyển về controller để xử lý.
			*/
			var authors = string.IsNullOrEmpty(str.Trim()) ? Book.Authors : str;
		}
	}
}