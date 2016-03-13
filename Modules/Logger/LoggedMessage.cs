using System;
using System.Runtime.Serialization;
using System.Configuration;
using Core.Objects.NetAPI;

namespace Modules.Logger {
	/// <summary>
	/// Logged message.
	/// </summary>
	[DataContract]
	public class LoggedMessage {
		[DataMember] int userID;
		[DataMember] string userName;
		[DataMember] string displayName;
		[DataMember] int chatID;
		[DataMember] string chatName;
		[DataMember] int unixTimeSent;
		[DataMember] string msgText;

		/// <summary>
		/// Gets or sets the user ID.
		/// </summary>
		/// <value>The user I.</value>
		public int UserID {
			get {
				return userID;
			}
			set {
				userID = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public string UserName {
			get {
				return userName;
			}
			set {
				userName = value;
			}
		}

		/// <summary>
		/// Gets or sets the display name.
		/// </summary>
		/// <value>The display name.</value>
		public string DisplayName {
			get {
				return displayName;
			}
			set {
				displayName = value;
			}
		}

		/// <summary>
		/// Gets or sets the chat ID.
		/// </summary>
		/// <value>The chat I.</value>
		public int ChatID {
			get {
				return chatID;
			}
			set {
				chatID = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the chat.
		/// </summary>
		/// <value>The name of the chat.</value>
		public string ChatName {
			get {
				return chatName;
			}
			set {
				chatName = value;
			}
		}

		/// <summary>
		/// Gets or sets the unix time when the message was sent.
		/// </summary>
		/// <value>The unix time sent.</value>
		public int UnixTimeSent {
			get {
				return unixTimeSent;
			}
			set {
				unixTimeSent = value;
			}
		}

		/// <summary>
		/// Gets or sets the message text.
		/// </summary>
		/// <value>The message text.</value>
		public string MsgText {
			get {
				return msgText;
			}
			set {
				msgText = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Modules.Logger.LoggedMessage"/> class.
		/// </summary>
		/// <param name="toLog">To log.</param>
		public LoggedMessage (Message toLog) {
			UserID = toLog.From.Id;
			UserName = toLog.From.Username;
			DisplayName = toLog.From.FirstName + " " + toLog.From.LastName;
			ChatID = toLog.Chat.Id;
			ChatName = toLog.Chat.FirstName + " " + toLog.Chat.LastName + "/" + toLog.Chat.Title;
			UnixTimeSent = toLog.Date;
			MsgText = toLog.Text;

		}
	}
}