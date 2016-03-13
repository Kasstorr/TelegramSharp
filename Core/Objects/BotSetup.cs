using System.Collections.Generic;
using System.Runtime.Serialization;
using TelegramSharp.Modules.QChat;

namespace TelegramSharp.Core.Objects {
	/// <summary>
	/// Bot configuration.
	/// </summary>
	[DataContract]
	public class BotSetup {
		/// <summary>
		/// Gets or sets the bot token.
		/// </summary>
		/// <value>The bot token.</value>
		[DataMember] public string BotToken{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.BotSetup"/> Q chat answers enabled.
		/// </summary>
		/// <value><c>true</c> if Q chat answers enabled; otherwise, <c>false</c>.</value>
		[DataMember] public bool QChatAnswersEnabled{ get; set; }


		/// <summary>
		/// Gets or sets the Qchatmodule.
		/// </summary>
		/// <value>The Q chat module.</value>
		[DataMember] public List<QChatAnswer> QChatModule{ get; set; }

		/// <summary>
		/// Gets or sets the owner identifier.
		/// </summary>
		/// <value>The owner identifier.</value>
		[DataMember] public int OwnerId{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.BotSetup"/> me enabled.
		/// </summary>
		/// <value><c>true</c> if me enabled; otherwise, <c>false</c>.</value>
		[DataMember] public bool MeEnabled{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.BotSetup"/> bot stats enabled.
		/// </summary>
		/// <value><c>true</c> if bot stats enabled; otherwise, <c>false</c>.</value>
		[DataMember] public bool BotStatsEnabled{ get; set; }

	}
}
