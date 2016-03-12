using System.Collections.Generic;
using System.Runtime.Serialization;
using Modules.QChat;

namespace Core.Objects {
	[DataContract]
	public class BotSetup {
		[DataMember] public string BotToken{ get; set; }

		[DataMember] public List<QChatAnswer> QChatModule{ get; set; }

		[DataMember] public int OwnerId{ get; set; }

		[DataMember] public bool MeEnabled{ get; set; }

		[DataMember] public bool BotStatsEnabled{ get; set; }

		[DataMember] public bool QChatAnswersEnabled{ get; set; }
	}
}
