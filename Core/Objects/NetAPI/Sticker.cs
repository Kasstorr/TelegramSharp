using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class Sticker {
		[DataMember (Name = "file_id")] public string FileId{ get; set; }

		[DataMember (Name = "width")] public int Width{ get; set; }

		[DataMember (Name = "height")] public int Height{ get; set; }

		[DataMember (Name = "thumb", IsRequired = false)] public PhotoSize Thumb{ get; set; }

		[DataMember (Name = "file_size", IsRequired = false)] public int FileSize{ get; set; }
	}
}
