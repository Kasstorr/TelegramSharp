using System.Collections.Generic;
using System.Runtime.Serialization;
using Modules.QChat;

namespace Core.Objects {
	[DataContract]
	public class BotSetup {
		[DataMember (Name = "BotToken")] public string BotToken{ get; set; }

		[DataMember (Name = "QChatModule")] public List<QChatAnswer> QChatModule{ get; set; }

		[DataMember (Name = "OwnerId")] public int OwnerId{ get; set; }
	}
}
