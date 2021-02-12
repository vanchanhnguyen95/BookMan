using System.Collections.Generic;
using BookMan.ConsoleApp.Models;

namespace BookMan.ConsoleApp.DataServices
{
	public interface IDataAccess
	{
		List<Book> Books { get; set; }

		void Load();
		void SaveChanges();
	}
}