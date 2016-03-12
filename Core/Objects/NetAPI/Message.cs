using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class Message {
		[DataMember (Name = "message_id")] public int MessageId{ get; set; }

		[DataMember (Name = "from")] public User From{ get; set; }

		[DataMember (Name = "date")] public int Date{ get; set; }

		[DataMember (Name = "chat")] public Chat Chat{ get; set; }

		[DataMember (Name = "forward_from", IsRequired = false)] public User ForwardFrom{ get; set; }

		[DataMember (Name = "forward_date", IsRequired = false)] public int ForwardDate{ get; set; }

		[DataMember (Name = "reply_to_message", IsRequired = false)] public Message ReplyToMessage{ get; set; }

		[DataMember (Name = "text", IsRequired = false)] public string Text{ get; set; }

		[DataMember (Name = "audio", IsRequired = false)] public Audio Audio{ get; set; }

		[DataMember (Name = "document", IsRequired = false)] public Document Document{ get; set; }

		[DataMember (Name = "photo", IsRequired = false)] public PhotoSize[] Photo{ get; set; }

		[DataMember (Name = "sticker", IsRequired = false)] public Sticker Sticker{ get; set; }

		[DataMember (Name = "video", IsRequired = false)] public Video Video{ get; set; }

		[DataMember (Name = "voice", IsRequired = false)] public Voice Voice{ get; set; }

		[DataMember (Name = "caption", IsRequired = false)] public string Caption{ get; set; }

		[DataMember (Name = "contact", IsRequired = false)] public Contact Contact{ get; set; }

		[DataMember (Name = "location", IsRequired = false)] public Location Location{ get; set; }

		[DataMember (Name = "new_chat_partecipant", IsRequired = false)] public User NewChatParticipant{ get; set; }

		[DataMember (Name = "left_chat_partecipant", IsRequired = false)] public User LeftChatParticipant{ get; set; }

		[DataMember (Name = "new_chat_title", IsRequired = false)] public string NewChatTitle{ get; set; }

		[DataMember (Name = "new_chat_photo", IsRequired = false)] public PhotoSize[] NewChatPhoto{ get; set; }

		[DataMember (Name = "delete_chat_photo", IsRequired = false)] public bool DeleteChatPhoto{ get; set; }

		[DataMember (Name = "group_chat_created", IsRequired = false)] public bool GroupChatCreated{ get; set; }

		[DataMember (Name = "super_group_chat_created", IsRequired = false)] public bool SuperGroupChatCreated{ get ; set; }

		[DataMember (Name = "channel_chat_created", IsRequired = false)] public bool ChannelChatCreated{ get ; set; }

		[DataMember (Name = "migrate_to_chat_id", IsRequired = false)] public int MigrateToChatId{ get; set; }

		[DataMember (Name = "migrate_from_chat_id", IsRequired = false)] public int MigrateFromChatId{ get; set; }
	}
}