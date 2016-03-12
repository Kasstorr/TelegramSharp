using System;
using System.Runtime.Serialization;

namespace Core.Objects {
	public enum ParseMode {
		MarkDown
	}

	[DataContract]
	public class OutgoingMessage {
		[DataMember (Name = "chat_id")] private int _chatId;
		[DataMember (Name = "text")] private string _text;
		[DataMember (Name = "parse_mode")] private ParseMode _parseMode;
		[DataMember (Name = "disable_web_page_preview")] private bool _disableWebPagePreview;
		[DataMember (Name = "reply_to_message_id")] private int _replyToMessageId;

		public int ChatId {
			get {
				return _chatId;
			}

			set {
				_chatId = value;
			}
		}

		public string Text {
			get {
				return _text;
			}

			set {
				_text = value;
			}
		}

		public string ParseMode {
			get {
				if (_parseMode == Objects.ParseMode.MarkDown)
					return _parseMode.ToString ();
				return "";
			}

			set {
				_parseMode = (ParseMode)Enum.Parse (typeof(ParseMode), value, true);
			}
		}

		public bool DisableWebPagePreview {
			get {
				return _disableWebPagePreview;
			}

			set {
				_disableWebPagePreview = value;
			}
		}

		public int ReplyToMessageId {
			get {
				return _replyToMessageId;
			}

			set {
				_replyToMessageId = value;
			}
		}
	}
}
