using BookMan.ConsoleApp.Models;
using System.Collections.Generic;

namespace BookMan.ConsoleApp.DataServices
{
	public class Repository
	{
		/// <summary>
		/// SimpleDataAccess
		/// </summary>
		protected readonly SimpleDataAccess _context;

		/// <summary>
		/// Repository
		/// </summary>
		/// <param name="context"></param>
		public Repository(SimpleDataAccess context)
		{
			_context = context;
			_context.Load();
		}

		/// <summary>
		/// SaveChanges
		/// </summary>
		public void SaveChanges() => _context.SaveChanges();

		/// <summary>
		/// List Book
		/// </summary>
		public List<Book> Books => _context.Books;

		/// <summary>
		/// Select Book
		/// </summary>
		/// <returns></returns>
		public Book[] Select() => _context.Books.ToArray();

		/// <summary>
		/// Select A Book
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Book Select(int id)
		{
			foreach (var b in _context.Books)
			{
				if (b.Id == id) return b;
			}
			return null;
		}

		/// <summary>
		/// Select Book
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public Book[] Select(string key)
		{
			var temp = new List<Book>();
			var k = key.ToLower();
			foreach (var b in _context.Books)
			{
				var logic =
					b.Title.ToLower().Contains(k) ||
					b.Authors.ToLower().Contains(k) ||
					b.Publisher.ToLower().Contains(k) ||
					b.Tags.ToLower().Contains(k) ||
					b.Description.ToLower().Contains(k)
					;
				if (logic) temp.Add(b);
			}
			return temp.ToArray();
		}

		/// <summary>
		/// Insert A Book
		/// </summary>
		/// <param name="book">Book</param>
		public void Insert(Book book)
		{
			var lastIndex = _context.Books.Count - 1;
			var id = lastIndex < 0 ? 1 : _context.Books[lastIndex].Id + 1;
			book.Id = id;
			_context.Books.Add(book);
		}

		/// <summary>
		/// Delete A Book
		/// </summary>
		/// <param name="id">id Book</param>
		/// <returns>True: Delete success; False: Delete false</returns>
		public bool Delete(int id)
		{
			var b = Select(id);
			if (b == null) return false;
			_context.Books.Remove(b);
			return false;
		}

		/// <summary>
		/// Update A Book
		/// </summary>
		/// <param name="id">id Book</param>
		/// <param name="book">book</param>
		/// <returns>True: Update success; False: Update false</returns>
		public bool Update(int id, Book book)
		{
			var b = Select(id);
			if (b == null) return false;
			b.Authors = book.Authors;
			b.Description = book.Description;
			b.Edition = book.Edition;
			b.File = book.File;
			b.Isbn = book.Isbn;
			b.Publisher = book.Publisher;
			b.Rating = book.Rating;
			b.Reading = book.Reading;
			b.Tags = book.Tags;
			b.Title = book.Title;
			b.Year = book.Year;
			return true;
		}

		/// <summary>
		/// SelectMarked
		/// </summary>
		/// <returns></returns>
		public Book[] SelectMarked()
		{
			var list = new List<Book>();
			foreach (var b in Books)
			{
				if (b.Reading) list.Add(b);
			}
			return list.ToArray();
		}

		/// <summary>
		/// Clear
		/// </summary>
		public void Clear()
		{
			_context.Books.Clear();
		}
	}
}