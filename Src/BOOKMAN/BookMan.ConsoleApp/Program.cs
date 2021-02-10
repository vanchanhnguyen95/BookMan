using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp
{
	using Controllers;
	class Program
	{
		/// <summary>
		/// Main
		/// </summary>
		/// <param name="args"></param>
		private static void Main(string[] args)
		{
			// Khởi tạo  controller
			BookController controller = new BookController();

			// Gọi controller
			controller.Single(0);
			Console.ReadKey();
		}
	}
}
