using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class Document {
		[DataMember (Name = "file_id")] public string FileId{ get; set; }

		[DataMember (Name = "thumb", IsRequired = false)] public PhotoSize Thumb{ get; set; }

		[DataMember (Name = "file_name", IsRequired = false)] public string FileName{ get; set; }

		[DataMember (Name = "mime_type", IsRequired = false)] public string MimeType{ get; set; }

		[DataMember (Name = "file_size", IsRequired = false)] public int FileSize{ get; set; }
	}
}
