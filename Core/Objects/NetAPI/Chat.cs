using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class Chat {
		[DataMember (Name = "id")] public int Id{ get; set; }

		[DataMember (Name = "type")] public string Type{ get; set; }

		[DataMember (Name = "title", IsRequired = false)] public string Title{ get; set; }

		[DataMember (Name = "first_name", IsRequired = false)] public string FirstName{ get; set; }

		[DataMember (Name = "last_name", IsRequired = false)] public string LastName{ get; set; }

		[DataMember (Name = "username", IsRequired = false)] public string Username{ get; set; }
	}
}
