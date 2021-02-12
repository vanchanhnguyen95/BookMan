﻿using System;
using BookMan.ConsoleApp.Controllers;
using BookMan.ConsoleApp.DataServices;
using BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp
{
	class Program
	{
		/// <summary>
		/// Main
		/// </summary>
		/// <param name="args"></param>
		private static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			SimpleDataAccess context = new SimpleDataAccess();
			BookController controller = new BookController(context);

			Router r = Router.Instance;

			r.Register("about", About);
			r.Register("help", Help);
			r.Register(route: "create",
				action: p => controller.Create(),
				help: "[create]\r\nnhập sách mới");
			r.Register(route: "update",
				action: p => controller.Update(p["id"].ToInt()),
				help: "[update ? id = <value>]\r\ntìm và cập nhật sách");
			r.Register(route: "list",
				action: p => controller.List(),
				help: "[list]\r\nhiển thị tất cả sách");
			r.Register(route: "single",
				action: p => controller.Single(p["id"].ToInt()),
				help: "[single ? id = < value >]\r\nhiển thị một cuốn sách theo id");

			while (true)
			{
				ViewHelp.Write("# Request >>> ", ConsoleColor.Green);
				string request = Console.ReadLine();

				Router.Instance.Forward(request);
				Console.WriteLine();
			}
		}

		private static void About(Parameter parameter)
		{
			ViewHelp.WriteLine("BOOK MANAGER version 1.0", ConsoleColor.Green);
			ViewHelp.WriteLine("by ChiChi@TuHocIct.com", ConsoleColor.Magenta);
		}

		private static void Help(Parameter parameter)
		{
			if (parameter == null)
			{
				ViewHelp.WriteLine("SUPPORTED COMMANDS:", ConsoleColor.Green);
				ViewHelp.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Yellow);
				ViewHelp.WriteLine("type: help ? cmd= <command> to get command details", ConsoleColor.Cyan);
				return;
			}
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			var command = parameter["cmd"].ToLower();
			ViewHelp.WriteLine(Router.Instance.GetHelp(command));

		}
	}
}
