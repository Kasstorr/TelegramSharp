using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class Audio {
		[DataMember (Name = "file_id")] public string FileId{ get; set; }

		[DataMember (Name = "duration")] public int Duration{ get; set; }

		[DataMember (Name = "performer", IsRequired = false)] public string Performer{ get; set; }

		[DataMember (Name = "title", IsRequired = false)] public string Title{ get; set; }

		[DataMember (Name = "mime_type", IsRequired = false)] public string MimeType{ get; set; }

		[DataMember (Name = "file_size", IsRequired = false)] public int FileSize{ get; set; }
	}
}
