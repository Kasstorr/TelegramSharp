using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class Location {
		[DataMember (Name = "longitude")] public float Longitude{ get; set; }

		[DataMember (Name = "latitude")] public float Latitude{ get; set; }
	}
}
