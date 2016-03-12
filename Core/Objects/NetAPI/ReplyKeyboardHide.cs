using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class ReplyKeyboardHide {
		[DataMember (Name = "hide_keyboard")] private bool _hideKeyboard = true;
		[DataMember (Name = "selective", IsRequired = false)] private bool _selective;

		public bool HideKeyboard {
			get {
				return _hideKeyboard;
			}

			set {
				_hideKeyboard = value;
			}
		}

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
