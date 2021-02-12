﻿using System.IO;

namespace BookMan.ConsoleApp.Framework
{
	public abstract class ViewBase
	{
		protected Router Router = Router.Instance;
		public ViewBase() { }

		// bổ sung phương thức virtual Render, cho phép ghi đè
		public abstract void Render();
	}

	public abstract class ViewBase<T> : ViewBase
	{
		protected T Model;
		public ViewBase(T model) => Model = model;

		public virtual void RenderToFile(string path)
		{
			ViewHelp.WriteLine($"Saving data to file '{path}'");
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
			File.WriteAllText(path, json);
			ViewHelp.WriteLine("Done!");
		}
	}

	//public virtual void RenderToFile(string path)
	//{
	//	ViewHelp.WriteLine($"Saving data to file '{path}'");
	//	var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
	//	File.WriteAllText(path, json);
	//	ViewHelp.WriteLine("Done!");
	//}
}