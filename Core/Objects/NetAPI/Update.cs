using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class Update {
		[DataMember (Name = "update_id")] public int UpdateId{ get; set; }

		[DataMember (Name = "message", IsRequired = false)] public Message Message{ get; set; }

		[DataMember (Name = "bot_info", IsRequired = false)] public User BotInfo{ get; set; }
	}
}
