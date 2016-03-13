using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	/// <summary>
	/// Video.
	/// </summary>
	[DataContract]
	public class Video {
		/// <summary>
		/// Gets or sets the file identifier.
		/// </summary>
		/// <value>The file identifier.</value>
		[DataMember (Name = "file_id")] public string FileId{ get; set; }

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>The width.</value>
		[DataMember (Name = "width")] public int Width{ get; set; }

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		[DataMember (Name = "height")] public int Height{ get; set; }

		/// <summary>
		/// Gets or sets the duration.
		/// </summary>
		/// <value>The duration.</value>
		[DataMember (Name = "duration")] public int Duration{ get; set; }

		/// <summary>
		/// Gets or sets the thumb.
		/// </summary>
		/// <value>The thumb.</value>
		[DataMember (Name = "thumb", IsRequired = false)] public PhotoSize Thumb{ get; set; }

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
