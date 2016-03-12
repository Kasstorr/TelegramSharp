using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class GetMeServerUpdate {
		[DataMember] public bool Ok{ get; set; }

		[DataMember (Name = "result", IsRequired = false)] public User GetMe{ get; set; }
	}
}