using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class UserProfilePhotos {
		[DataMember (Name = "total_count")] public int TotalCount{ get; set; }

		[DataMember (Name = "photos")] public PhotoSize[][] Photos{ get; set; }
	}
}
