using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
	/// <summary>
	/// Reply keyboard markup.
	/// </summary>
	[DataContract]
	public class ReplyKeyboardMarkup {
		/// <summary>
		/// Gets or sets the keyboard.
		/// </summary>
		/// <value>The keyboard.</value>
		[DataMember (Name = "keyboard")] public string[][] Keyboard{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ReplyKeyboardMarkup"/> resize keyboard.
		/// </summary>
		/// <value><c>true</c> if resize keyboard; otherwise, <c>false</c>.</value>
		[DataMember (Name = "resize_keyboard", IsRequired = false)] public bool ResizeKeyboard{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ReplyKeyboardMarkup"/> one time keyboard.
		/// </summary>
		/// <value><c>true</c> if one time keyboard; otherwise, <c>false</c>.</value>
		[DataMember (Name = "one_time_keyboard", IsRequired = false)] public bool OneTimeKeyboard{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ReplyKeyboardMarkup"/> is selective.
		/// </summary>
		/// <value><c>true</c> if selective; otherwise, <c>false</c>.</value>
		[DataMember (Name = "selective", IsRequired = false)] public bool Selective{ get; set; }
	}
}
