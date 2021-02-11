﻿using System;

namespace BookMan.ConsoleApp.Views
{
	internal class BookCreateView
	{
		public BookCreateView()
		{
		}

		/// <summary>
		/// Yêu cầu người dùng nhập từng thông tin và lưu lại thông tin đó
		/// </summary>
		public void Render()
		{
			WriteLine("CREATE A NEW BOOK", ConsoleColor.Green);

			// Đọc 1 dòng và lưu vào biến title
			var title = InputString("Title");
			// Đọc 1 dòng và lưu vào biến authors
			var authors = InputString("Authors");
			// Đọc 1 dòng và lưu vào biến publisher
			var publisher = InputString("Publisher");
			// nhập giá trị cho biến year
			var year = InputInt("Year");
			// nhập giá trị cho biến edition
			var edition = InputInt("Edition");
			var tags = InputString("Tags");
			var description = InputString("Description");
			var rate = InputInt("Rate");
			var reading = InputBool("Reading");
			var file = InputString("File");
		}

		/// <summary>
		/// xuất thông tin ra console với màu sắc (WriteLine có màu)
		/// </summary>
		/// <param name="message">thông tin cần xuất</param>
		/// <param name="color">màu chữ</param>
		/// <param name="resetColor">trả lại màu mặc định hay không</param>
		private void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			if (resetColor)
				Console.ResetColor();
		}

		/// <summary>
		/// xuất thông tin ra console với màu sắc (Write có màu)
		/// </summary>
		/// <param name="message">thông tin cần xuất</param>
		/// <param name="color">màu chữ</param>
		/// <param name="resetColor">trả lại màu mặc định hay không</param>
		private void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
		{
			Console.ForegroundColor = color;
			Console.Write(message);
			if (resetColor)
				Console.ResetColor();
		}

		/// <summary>
		/// in ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
		/// rồi chuyển sang kiểu bool
		/// </summary>
		/// <param name="label">dòng thông báo</param>
		/// <param name="labelColor">màu chữ thông báo</param>
		/// <param name="valueColor">màu chữ người dùng nhập</param>
		/// <returns></returns>
		private bool InputBool(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
		{
			Write($"{label} [y/n]: ", labelColor);
			ConsoleKeyInfo key = Console.ReadKey(); //đọc 1 ký tự vào biến key
			Console.WriteLine();
			bool @char = key.KeyChar == 'y' || key.KeyChar == 'Y' ?
				true : false; //chuyển sang kiểu bool dùng biểu thức điều kiện
			return @char; // lưu ý cách viết tên biến @char
		}

		/// <summary>
		/// in ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
		/// rồi chuyển sang số nguyên
		/// </summary>
		/// <param name="label">dòng thông báo</param>
		/// <param name="labelColor">màu chữ thông báo</param>
		/// <param name="valueColor">màu chữ người dùng nhập</param>
		/// <returns></returns>
		private int InputInt(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
		{
			while (true)
			{
				var str = InputString(label, labelColor, valueColor);
				var result = int.TryParse(str, out int i);
				if (result == true)
				{
					return i;
				}
			}
		}

		/// <summary>
		/// in ra thông báo và tiếp nhận chuỗi ký tự người dùng nhập
		/// </summary>
		/// <param name="label">dòng thông báo</param>
		/// <param name="labelColor">màu chữ thông báo</param>
		/// <param name="valueColor">màu chữ người dùng nhập</param>
		/// <returns></returns>
		private string InputString(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
		{
			Write($"{label}: ", labelColor, false);
			Console.ForegroundColor = valueColor;
			string value = Console.ReadLine();
			Console.ResetColor();
			return value;
		}
	}
}