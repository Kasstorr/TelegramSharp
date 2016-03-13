using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
	/// <summary>
	/// Chat.
	/// </summary>
	[DataContract]
	public class Chat {
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[DataMember (Name = "id")] public int Id{ get; set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		[DataMember (Name = "type")] public string Type{ get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		[DataMember (Name = "title", IsRequired = false)] public string Title{ get; set; }

		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		/// <value>The first name.</value>
		[DataMember (Name = "first_name", IsRequired = false)] public string FirstName{ get; set; }

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>The last name.</value>
		[DataMember (Name = "last_name", IsRequired = false)] public string LastName{ get; set; }

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>The username.</value>
		[DataMember (Name = "username", IsRequired = false)] public string Username{ get; set; }
	}
}
