using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class ReplyKeyboardMarkup {
		[DataMember (Name = "keyboard")] public string[][] Keyboard{ get; set; }

		[DataMember (Name = "resize_keyboard", IsRequired = false)] public bool ResizeKeyboard{ get; set; }

		[DataMember (Name = "one_time_keyboard", IsRequired = false)] public bool OneTimeKeyboard{ get; set; }

		[DataMember (Name = "selective", IsRequired = false)] public bool Selective{ get; set; }
	}
}
