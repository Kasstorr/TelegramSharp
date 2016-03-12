using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class ForceReply {
		[DataMember (Name = "force_reply")] public bool forceReply{ get { return true; } }

		[DataMember (Name = "name", IsRequired = false)] public bool Selective{ get; set; }
	}
}
