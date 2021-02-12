using System;
using BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp.Views
{
	internal class BookCreateView : ViewBase
	{
		public BookCreateView() { }

		/// <summary>
		/// Yêu cầu người dùng nhập từng thông tin và lưu lại thông tin đó
		/// </summary>
		public void Render()
		{
			ViewHelp.WriteLine("CREATE A NEW BOOK", ConsoleColor.Green);

			// Đọc 1 dòng và lưu vào biến title
			var title = ViewHelp.InputString("Title");

			// Đọc 1 dòng và lưu vào biến authors
			var authors = ViewHelp.InputString("Authors");

			// Đọc 1 dòng và lưu vào biến publisher
			var publisher = ViewHelp.InputString("Publisher");

			// nhập giá trị cho biến year
			var year = ViewHelp.InputInt("Year");

			// nhập giá trị cho biến edition
			var edition = ViewHelp.InputInt("Edition");

			// nhập giá trị cho biến tags
			var tags = ViewHelp.InputString("Tags");

			// nhập giá trị cho biến description
			var description = ViewHelp.InputString("Description");

			// nhập giá trị cho biến rate
			var rate = ViewHelp.InputInt("Rate");

			// nhập giá trị cho biến reading
			var reading = ViewHelp.InputBool("Reading");

			// nhập giá trị cho biến file
			var file = ViewHelp.InputString("File");
		}

	}
}