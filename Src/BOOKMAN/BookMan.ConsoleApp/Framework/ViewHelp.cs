﻿using System;

namespace BookMan.ConsoleApp.Framework
{
	public static class ViewHelp
	{
		/// <summary>
		/// xuất thông tin ra console với màu sắc (WriteLine có màu)
		/// </summary>
		/// <param name="message">thông tin cần xuất</param>
		/// <param name="color">màu chữ</param>
		/// <param name="resetColor">trả lại màu mặc định hay không</param>
		public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
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
		public static void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
		{
			Console.ForegroundColor = color;
			Console.Write(message);
			if (resetColor)
				Console.ResetColor();
		}

		/// <summary>
		/// in ra thông báo, chờ người dùng bấm phím bất kỳ.
		/// Nếu bấm 'y' sẽ trả về true, bấm phím khác sẽ trả về false
		/// </summary>
		/// <param name="label"></param>
		/// <param name="labelColor"></param>
		/// <param name="valueColor"></param>
		/// <returns></returns>
		public static bool InputBool(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
		{
			Write($"{label} [y/n]: ", labelColor); //phương thức tĩnh gọi phương thức tĩnh khác trong cùng class
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
		public static int InputInt(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
		{
			while (true)
			{
				var str = InputString(label, labelColor, valueColor); //phương thức tĩnh gọi phương thức tĩnh khác trong cùng class
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
		public static string InputString(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
		{
			Write($"{label}: ", labelColor, false); //phương thức tĩnh gọi phương thức tĩnh khác trong cùng class
			Console.ForegroundColor = valueColor;
			string value = Console.ReadLine();
			Console.ResetColor();
			return value;
		}
	}
}