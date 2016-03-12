using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class File {
		[DataMember (Name = "file_id")] public string FileId{ get; set; }

		[DataMember (Name = "file_size", IsRequired = false)] public int FileSize{ get; set; }

		[DataMember (Name = "file_path", IsRequired = false)] public string FilePath{ get; set; }
	}
}
