using System;

namespace Core.Objects.NetAPI {
	public class LoggableMessage:Message {
		public bool Logged = false;
		public User FromBot = new User ();

		public LoggableMessage (Message msg, User bot) {
			MessageId = msg.MessageId;
			From = msg.From;
			Date = msg.Date;
			Chat = msg.Chat;
			ForwardFrom = msg.ForwardFrom;
			ForwardDate = msg.ForwardDate;
			ReplyToMessage = msg.ReplyToMessage;
			Text = msg.Text;
			Audio = msg.Audio;
			Document = msg.Document;
			Photo = msg.Photo;
			Sticker = msg.Sticker;
			Video = msg.Video;
			Voice = msg.Voice;
			Caption = msg.Caption;
			Contact = msg.Contact;
			Location = msg.Location;
			NewChatParticipant = msg.NewChatParticipant;
			LeftChatParticipant = msg.LeftChatParticipant;
			NewChatTitle = msg.NewChatTitle;
			NewChatPhoto = msg.NewChatPhoto;
			DeleteChatPhoto = msg.DeleteChatPhoto;
			GroupChatCreated = msg.GroupChatCreated;
			SuperGroupChatCreated = msg.SuperGroupChatCreated;
			ChannelChatCreated = msg.ChannelChatCreated;
			MigrateToChatId = msg.MigrateToChatId;
			MigrateFromChatId = msg.MigrateFromChatId;

			Logged = false;
			FromBot = bot;
		}
	}
}

