using System;

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
			while (true)
			{
				Console.Write("Request> ");
				string request = Console.ReadLine();

				switch (request.ToLower())
				{
					case "single":
						controller.Single(1);
						break;

					case "create":
						controller.Create();
						break;

					default:
						Console.WriteLine("Unknown command");
						break;
				}
			}
		}
	}
}
