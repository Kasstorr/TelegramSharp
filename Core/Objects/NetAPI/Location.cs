using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	/// <summary>
	/// Location.
	/// </summary>
	[DataContract]
	public class Location {
		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>The longitude.</value>
		[DataMember (Name = "longitude")] public float Longitude{ get; set; }

		/// <summary>
		/// Gets or sets the latitude.
		/// </summary>
		/// <value>The latitude.</value>
		[DataMember (Name = "latitude")] public float Latitude{ get; set; }
	}
}
