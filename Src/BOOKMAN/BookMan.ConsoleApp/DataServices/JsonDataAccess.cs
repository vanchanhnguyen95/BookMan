using System.Collections.Generic;
using System.IO;
using BookMan.ConsoleApp.Models;
using Newtonsoft.Json;

namespace BookMan.ConsoleApp.DataServices
{
	public class JsonDataAccess : IDataAccess
	{
		//public List<Book> Books { get; set; } = new List<Book>();
		//private readonly string _file = "data.json";
		public List<Book> Books { get; set; } = new List<Book>();
		private readonly string _file = Config.Instance.DataFile; // "data.json";

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

			JsonSerializer serializer = new JsonSerializer();
			using (StreamReader sReader = new StreamReader(_file))
			using (JsonReader jReader = new JsonTextReader(sReader))
			{
				Books = serializer.Deserialize<List<Book>>(jReader);
			}
			//var jsonString = File.ReadAllText(_file);
			//Books = JsonConvert.DeserializeObject<List<Book>>(jsonString);
		}

		/// <summary>
		/// SaveChanges
		/// </summary>
		public void SaveChanges()
		{
			JsonSerializer serializer = new JsonSerializer();
			using (StreamWriter sWriter = new StreamWriter(_file))
			using (JsonWriter jWriter = new JsonTextWriter(sWriter))
			{
				serializer.Serialize(jWriter, Books);
			}
			//var jsonString = JsonConvert.SerializeObject(Books);
			//File.WriteAllText(_file, jsonString);
		}
	}
}