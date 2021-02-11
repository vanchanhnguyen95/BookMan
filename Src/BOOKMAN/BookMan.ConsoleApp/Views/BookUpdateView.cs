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
			ViewHelp.WriteLine("UPDATE BOOK INFORMATION", ConsoleColor.Green); //sử dụng phương thức static

			var authors = ViewHelp.InputString("Authors", Book.Authors);
			var title = ViewHelp.InputString("Title", Book.Title);
			var publisher = ViewHelp.InputString("Publisher", Book.Publisher);
			var isbn = ViewHelp.InputString("Isbn", Book.Isbn);
			var tags = ViewHelp.InputString("Tags", Book.Tags);
			var description = ViewHelp.InputString("Description", Book.Description);
			var file = ViewHelp.InputString("File", Book.File);
			var year = ViewHelp.InputInt("Year", Book.Year);
			var edition = ViewHelp.InputInt("Edition", Book.Edition);
			var rating = ViewHelp.InputInt("Rate", Book.Rating);
			var reading = ViewHelp.InputBool("Reading", Book.Reading);
		}
	}
}