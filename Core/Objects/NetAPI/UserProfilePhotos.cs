using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	/// <summary>
	/// User profile photos.
	/// </summary>
	[DataContract]
	public class UserProfilePhotos {
		/// <summary>
		/// Gets or sets the total count.
		/// </summary>
		/// <value>The total count.</value>
		[DataMember (Name = "total_count")] public int TotalCount{ get; set; }

		/// <summary>
		/// Gets or sets the photos.
		/// </summary>
		/// <value>The photos.</value>
		[DataMember (Name = "photos")] public PhotoSize[][] Photos{ get; set; }
	}
}
