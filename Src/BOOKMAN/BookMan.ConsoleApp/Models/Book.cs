namespace BookMan.ConsoleApp.Models
{
	/// <summary>
	/// Lớp mô tả sách điện tử
	/// </summary>
	public class Book
	{
		private int _id = 1;
		/// <summary>
		/// Số định dinh duy nhất cho mỗi object
		/// </summary>
		public int Id
		{
			get { return _id; }
			set { if (value >= 1) _id = value; }
		}

		private string _authors = "Unknown authors";
		/// <summary>
		/// Tên tác giả hoặc nhóm tác giả, Không nhận xâu rỗng
		/// </summary>
		public string Authors
		{
			get { return _authors; }
			set { if (!string.IsNullOrEmpty(value)) _authors = value; }
		}

		private string _title = "A new book";
		/// <summary>
		/// Tiêu đề sách, Không nhận xâu rỗng
		/// </summary>
		public string Title
		{
			get { return _title; }
			set { if (!string.IsNullOrEmpty(value)) _title = value; }
		}

		private string _publisher = "Unknown publisher";
		/// <summary>
		/// Nhà xuất bản, không nhận xâu rỗng
		/// </summary>
		public string Publisher
		{
			get { return _publisher; }
			set { if (!string.IsNullOrEmpty(value)) _publisher = value; }
		}

		private int _year = 2021;
		/// <summary>
		/// Năm xuất bản, không nhỏ hơn 1950
		/// </summary>
		public int Year
		{
			get { return _year; }
			set { if (value >= 1950) _year = value; }
		}

		private int _edition = 1;
		/// <summary>
		/// Lần tái bản, không nhỏ hơn 1
		/// </summary>
		public int Edition
		{
			get { return _edition; }
			set { if (value >= 1) _edition = value; }
		}
		/// <summary>
		/// Mã số quốc tế
		/// </summary>
		public string Isbn { get; set; } = "";

		/// <summary>
		/// Từ khóa mô tả nội dung / thể loại
		/// </summary>
		public string Tags { get; set; } = "";

		/// <summary>
		/// Mô tả tóm tắt nội dung
		/// </summary>
		public string Description { get; set; } = "A new book";

		/// <summary>
		/// Đánh giá cá nhân, giá trị từ 1 đến 5
		/// </summary>
		private int _rating = 1;
		public int Rating
		{
			get { return _rating = 1; }
			set { if (value >= 1 && value <= 5) _rating = value; }
		}

		/// <summary>
		/// Đánh dấu là đang đọc
		/// </summary>
		public bool Reading = false;

		private string _file;

		/// <summary>
		/// File sách (gồm dường dẫn)
		/// </summary>
		public string File
		{
			get { return _file; }
			set { if (System.IO.File.Exists(value)) _file = value; }
		}

		/// <summary>
		/// File sách (không có đường dẫn)
		/// </summary>
		public string FileName
		{
			get { return System.IO.Path.GetFileName(_file); }
		}

	}
}