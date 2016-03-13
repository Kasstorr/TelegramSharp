using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
	/// <summary>
	/// Reply keyboard hide.
	/// </summary>
	[DataContract]
	public class ReplyKeyboardHide {
		[DataMember (Name = "hide_keyboard")] private bool _hideKeyboard = true;
		[DataMember (Name = "selective", IsRequired = false)] private bool _selective;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ReplyKeyboardHide"/> hide keyboard.
		/// </summary>
		/// <value><c>true</c> if hide keyboard; otherwise, <c>false</c>.</value>
		public bool HideKeyboard {
			get {
				return _hideKeyboard;
			}

			set {
				_hideKeyboard = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ReplyKeyboardHide"/> is selective.
		/// </summary>
		/// <value><c>true</c> if selective; otherwise, <c>false</c>.</value>
		public bool Selective {
			get {
				return _selective;
			}

			set {
				_selective = value;
			}
		}
	}
}
