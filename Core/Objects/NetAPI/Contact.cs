using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
	/// <summary>
	/// Contact.
	/// </summary>
	[DataContract]
	public class Contact {
		/// <summary>
		/// The phone number.
		/// </summary>
		[DataMember (Name = "phone_number")] public string PhoneNumber;
		/// <summary>
		/// The first name.
		/// </summary>
		[DataMember (Name = "first_name")] public string FirstName;
		/// <summary>
		/// The last name.
		/// </summary>
		[DataMember (Name = "last_name", IsRequired = false)] public string LastName;
		/// <summary>
		/// The user identifier.
		/// </summary>
		[DataMember (Name = "user_id", IsRequired = false)] public int UserId;
	}
}
