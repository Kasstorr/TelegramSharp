//TelegramSharp - A library to make telegram bots
//Copyright (C) 2016  Samuele Lorefice
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Runtime.Serialization;
using System.Configuration;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Modules.Logger {
	/// <summary>
	/// Logged message.
	/// </summary>
	[DataContract]
	public class LoggedMessage {
		[DataMember] int userID;
		[DataMember] string userName;
		[DataMember] string displayName;
		[DataMember] long chatID;
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
		public long ChatID {
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