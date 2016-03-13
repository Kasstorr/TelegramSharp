using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
	/// <summary>
	/// Update.
	/// </summary>
	[DataContract]
	public class Update {
		/// <summary>
		/// Gets or sets the update identifier.
		/// </summary>
		/// <value>The update identifier.</value>
		[DataMember (Name = "update_id")] public int UpdateId{ get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		[DataMember (Name = "message", IsRequired = false)] public Message Message{ get; set; }

		/// <summary>
		/// Gets or sets the bot info.
		/// </summary>
		/// <value>The bot info.</value>
		[DataMember (Name = "bot_info", IsRequired = false)] public User BotInfo{ get; set; }
	}
}
