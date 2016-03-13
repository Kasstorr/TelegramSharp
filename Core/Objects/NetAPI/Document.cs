using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
	/// <summary>
	/// Document.
	/// </summary>
	[DataContract]
	public class Document {
		/// <summary>
		/// Gets or sets the file identifier.
		/// </summary>
		/// <value>The file identifier.</value>
		[DataMember (Name = "file_id")] public string FileId{ get; set; }

		/// <summary>
		/// Gets or sets the thumb.
		/// </summary>
		/// <value>The thumb.</value>
		[DataMember (Name = "thumb", IsRequired = false)] public PhotoSize Thumb{ get; set; }

		/// <summary>
		/// Gets or sets the name of the file.
		/// </summary>
		/// <value>The name of the file.</value>
		[DataMember (Name = "file_name", IsRequired = false)] public string FileName{ get; set; }

		/// <summary>
		/// Gets or sets the type of the MIME.
		/// </summary>
		/// <value>The type of the MIME.</value>
		[DataMember (Name = "mime_type", IsRequired = false)] public string MimeType{ get; set; }

		/// <summary>
		/// Gets or sets the size of the file.
		/// </summary>
		/// <value>The size of the file.</value>
		[DataMember (Name = "file_size", IsRequired = false)] public int FileSize{ get; set; }
	}
}
