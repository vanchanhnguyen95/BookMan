using System.Diagnostics;
using System.IO;
using BookMan.ConsoleApp.DataServices;
using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Models;

namespace BookMan.ConsoleApp.Controllers
{
	internal class ShellController : ControllerBase
	{
		protected Repository Repository;
		public ShellController(IDataAccess context)
		{
			Repository = new Repository(context);
		}

		/// <summary>
		/// Add Shell
		/// </summary>
		/// <param name="folder"></param>
		/// <param name="ext"></param>
		public void Shell(string folder, string ext = "*.pdf")
		{
			if (!Directory.Exists(folder))
			{
				Error("Folder not found!");
				return;
			}
			var files = Directory.GetFiles(folder, ext ?? "*.pdf", SearchOption.AllDirectories);
			foreach (var f in files)
			{
				Repository.Insert(new Book { Title = Path.GetFileNameWithoutExtension(f), File = f });
			}
			if (files.Length > 0)
			{
				//Render(new BookListView(Repository.Select()));
				Success($"{files.Length} item(s) found!");
				return;
			}
			Inform("No item found!", "Sorry!");
		}

		/// <summary>
		/// Read
		/// </summary>
		/// <param name="id"></param>
		public void Read(int id)
		{
			var book = Repository.Select(id);
			if (book == null)
			{
				Error("Book not found!");
				return;
			}
			if (!File.Exists(book.File))
			{
				Error("File not found!");
				return;
			}
			Process.Start(book.File);
			Success($"You are reading the book '{book.Title}'");
		}

		/// <summary>
		/// Clear
		/// </summary>
		/// <param name="process"></param>
		public void Clear(bool process = false)
		{
			if (!process)
			{
				Confirm("Do you really want to clear the shell? ", "do clear");
				return;
			}
			Repository.Clear();
			Inform("The shell has been cleared");
		}

		/// <summary>
		/// Save
		/// </summary>
		public void Save()
		{
			Repository.SaveChanges();
			Success("Data save!");
		}
	}
}