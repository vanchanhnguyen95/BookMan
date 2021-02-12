using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using BookMan.ConsoleApp.Models;

namespace BookMan.ConsoleApp.DataServices
{
	public class XmlDataAccess : IDataAccess
	{
		public List<Book> Books { get; set; } = new List<Book>();
		private readonly string _file = "data.xml";

		/// <summary>
		/// Load
		/// </summary>
		public void Load()
		{
			if (!File.Exists(_file))
			{
				SaveChanges();
				return;
			}
			var serializer = new XmlSerializer(typeof(List<Book>));
			using (var reader = XmlReader.Create(_file))
			{
				Books = (List<Book>)serializer.Deserialize(reader);
			}
		}

		/// <summary>
		/// SaveChanges
		/// </summary>
		public void SaveChanges()
		{
			var serializer = new XmlSerializer(typeof(List<Book>));
			using (var writer = XmlWriter.Create(_file))
			{
				serializer.Serialize(writer, Books);
			}
		}
	}
}