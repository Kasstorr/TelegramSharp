using System;

namespace TelegramSharp.Core.Objects.NetAPI {
	/// <summary>
	/// Loggable message.
	/// </summary>
	public class LoggableMessage:Message {
		/// <summary>
		/// Signs if the message have been logged.
		/// </summary>
		public bool Logged = false;
		/// <summary>
		/// Bot that have received this message.
		/// </summary>
		public User FromBot = new User ();

		/// <summary>
		/// Initializes a new instance of the <see cref="Core.Objects.NetAPI.LoggableMessage"/> class.
		/// </summary>
		/// <param name="msg">Message to log.</param>
		/// <param name="bot">Bot that received this message.</param>
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

