using System;
using System.Runtime.Serialization;
using System.Configuration;
using Core.Objects.NetAPI;

namespace Modules.Logger {
	[DataContract]
	public class LoggedMessage {
		[DataMember] int userID;
		[DataMember] string userName;
		[DataMember] string displayName;
		[DataMember] int chatID;
		[DataMember] string chatName;
		[DataMember] int unixTimeSent;
		[DataMember] string msgText;

		public int UserID {
			get {
				return userID;
			}
			set {
				userID = value;
			}
		}

		public string UserName {
			get {
				return userName;
			}
			set {
				userName = value;
			}
		}

		public string DisplayName {
			get {
				return displayName;
			}
			set {
				displayName = value;
			}
		}

		public int ChatID {
			get {
				return chatID;
			}
			set {
				chatID = value;
			}
		}

		public string ChatName {
			get {
				return chatName;
			}
			set {
				chatName = value;
			}
		}

		public int UnixTimeSent {
			get {
				return unixTimeSent;
			}
			set {
				unixTimeSent = value;
			}
		}

		public string MsgText {
			get {
				return msgText;
			}
			set {
				msgText = value;
			}
		}

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